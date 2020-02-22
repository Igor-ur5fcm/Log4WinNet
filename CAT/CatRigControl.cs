using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
//using Log4WinNet.DAC;
using Log4WinNet.Log.Forms;
using WeifenLuo.WinFormsUI.Docking;
using CookComputing.XmlRpc;
using System.Threading;
using Log4WinNet.Log.Properties;
using Log4WinNet.Log.Data;
using System.IO;
using System.Net;

namespace Log4WinNet.Log.CAT
{
    public partial class CatRigControl : DockContent
    {

        IHRadio rd;
        //DAC dc = new DAC();
        public CatRigControl()
        {
            //CwGet.CwGetX cw = new CwGet.CwGetX();
            InitializeComponent();
            this.Text = "Rig:";
            StepBox.Items.With(s =>
                {
                    s.Clear();
                    s.Add("1");
                    s.Add("5");
                    s.Add("10");
                    s.Add("15");
                    s.Add("20");
                });
            StepBox.Text = "10";
            //ListFreq.Items.With(l =>
            //    {
            //        l.Add("1840.0");

            LoadListFreqs();
            //    });

            rd = new Radio();
        }
        /// <summary>
        /// Load List possible Frequencies
        /// </summary>
        private void LoadListFreqs()
        {
            ListFreq.Items.Clear();
            var result = Hans.BandPlanData.Where(s =>
                s.Mode.StartsWith("PSK") || s.Mode.Equals("RTTY")).OrderBy(q => q.Band);
            result.Cast<BandPlan>().ToList().
                ForEach(s => ListFreq.Items.Add(s.LowFrequency.ToFormatFrequency()));

        }
        /// <summary>
        /// GetProces of flRig
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        private bool GetProcess(string Name)
        {
            bool blnPoc = false;
            Process[] proc = Process.GetProcesses();
            foreach (Process process in proc)
            {
                //Console.WriteLine(process.ProcessName);
                if (process.ProcessName == Name)
                {

                    int pID = process.Id;
                    string pName = Name;
                    blnPoc = true;
                }
            }
            return blnPoc;
        }
        private void Log4WinEvents_OnDoubleClicked(string c, double freq)
        {
            MainFrequency = freq;
            //lblFreq.Text = MainFrequency.ToFormatFrequency();
            rig.RigSetFreq(MainFrequency * 1E3);
        }
        private void ListFreq_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            rd.SetFrequency(ListFreq.GetItemText(ListFreq.SelectedItem).ToDouble());
        }
        private string SetModeToRadio(double freq)
        {
            return "";
        }
        private void Log4WinEvents_FrequencyChanged(double fr)
        {
            if (!fr.Equals(MainFrequency))
            {
                MainFrequency = fr * 1E3d;
                //lblFreq.Text = MainFrequency.ToFormatFrequency();
                rig.RigSetFreq(MainFrequency * 1E3);
            }
        }
        protected override void OnLoad(EventArgs e)
        {
            Log4WinEvents.FrequencyChanged+=
                new Log4WinEvents.FrequencyChangedEventHandler(Log4WinEvents_FrequencyChanged);
            Log4WinEvents.OnDoubleClicked+=new Log4WinEvents.SCPEventHandler(Log4WinEvents_OnDoubleClicked);
           ListFreq.MouseDoubleClick+=new MouseEventHandler(ListFreq_MouseDoubleClick);
            try
            {
                //clsFcm.MainFrm.cat
                string Flpath = Settings.Default.FlRig_path;
                if (Flpath.IsNullOrEmpty())
                {
                    throw new ArgumentNullException("Flpath", "Please set path to FlRig software!");
                }
                if (!File.Exists(Flpath))
                {
                    throw new FileNotFoundException("Path to FlRig software not found!");
                }
                string proname = System.IO.Path.GetFileNameWithoutExtension(Flpath);
                if (!GetProcess(proname))
                {
                    Process p = Process.Start(Flpath);
                    //p.WaitForInputIdle(16000);
                }

                bool b = false;
                while (!b)
                {
                    b = GetProcess(proname);
                }
                rd = clsFcm.mRadio;
                rig = XmlRpcProxyGen.Create<IFlRig>();
                
                RadioTimer.Enabled = true;
                Isconnected = true;
                rd.IsConnected = true;
                //string[] modes = rig.RigGetModes();
                //modes.Cast<string>().ToList().ForEach(s => ModeBox.Items.Add(s));
                //FreqRig = rig.RigGetVfo();
                //MainFrequency = (FreqRig.ToDouble() / 1000d);
                //lblFreq.Text = (FreqRig.ToDouble() / 1000d).ToFormatFrequency();
                MainFrequency = CommonFunctions.Freq;
                lblFreq.Text = MainFrequency.ToFormatFrequency();
                rig.RigSetFreq(MainFrequency * 1E3);
                rig.RigSetMode(Settings.Default.RadioMode);

                rd.SetRig<IFlRig>(rig);
            }
            catch (FileNotFoundException fx) {
                clsFcm.MyMessage(fx.Message, false, "FlRig error!!!");
            }
            catch { }
            //    tflrig = new Thread(GetDataRig);
            //Done = Isconnected;
           
            //tflrig.Start();
            
            base.OnLoad(e);
        }
       
        void SetVfo(string vfo)
        {
            chkA.Checked = vfo == "A";
            chkB.Checked = vfo == "B";

            
        }
        void GetPtt(int ptt)
        {
            if (ptt == 0)
            {
                bPtt.BackColor = Control.DefaultBackColor;
            }
            else
            {
                bPtt.BackColor = SetNoRadioColor();
            }
        }
        
        bool Isconnected = false;
        string FreqRig = "";
        double MainFrequency;
        IFlRig rig;
        //Thread tflrig;
        protected override void OnMouseWheel(MouseEventArgs e)
        {
            int StepkHz = Convert.ToInt32(StepBox.Text);
            if (e.Delta < 0)
            {
                MainFrequency = MainFrequency + StepkHz;
            }
            else
            {
                MainFrequency = MainFrequency - StepkHz;
            }

            rig.RigSetFreq(MainFrequency * 1000d);

            base.OnMouseWheel(e);
        }
        public delegate void RadioFreqChangedHandler(double dFreq);
        public static event RadioFreqChangedHandler Radio_FreqChange;
        public static void OnRadioFreqChange(double aFreq)
        {
            if (Radio_FreqChange != null) Radio_FreqChange(aFreq);
        }
        int Power = 0;
        void GetNewFreq(string aFreq)
        {
            if (!aFreq.Equals(FreqRig))
            {
                lblFreq.Text = (aFreq.ToDouble() / 1000d).ToFormatFrequency();
                FreqRig = aFreq;
                MainFrequency = (aFreq.ToDouble() / 1000d);
                //Log4WinEvents.OnFrequencyChnged(MainFrequency / 1000d);
                Radio_FreqChange(MainFrequency);
            }
        }
        void GetModeRadio(string mode)
        {
            if (!mode.Equals(lblMode.Text))
            {
                lblMode.Text = mode;
            }
        }
        void GetParams(Tuple<string, string> tp)
        {
            string pwr = tp.Item1;
            if (!pwr.Equals(lblPwr.Text))
            {
                lblPwr.Text = tp.Item1;
                panel3.Refresh();
            }

            string Name = "Rig: " + tp.Item2;
            if (!Name.Equals(this.Text))
            {
                this.Text =  Name;
                rd.GetNoRadio(tp.Item2);
                NoRadio = rd.noRadio;
            }
           
        }
        private bool NoRadio = false;
        void GetDataRig()
        {
            try
            {
                //FreqRig=rig.RigGetVfo();
                string strMode = "";
                string rigName = "";
                string info = "";
                string Freq = "";
                string AorB = rig.RigGetAB();
                int ptt = rig.RigGetPtt();
                //MethodInvoker mi = delegate()
                //{

                //};

                //while (Done)
                //{
                //lock (Power) ;
                strMode = rig.Rig_get_mode();
                rigName = rig.RigGetXcvr();
                ptt = rig.RigGetPtt();
                info = rig.RigGetInfo();
                Freq = rig.RigGetVfo();
                Power = rig.RigGetPower();
                AorB = rig.RigGetAB();
                GetModeRadio(strMode);

                Tuple<string, string> tp = Tuple.Create(Power.ToString(), rigName);
                GetParams(tp);


                GetNewFreq(Freq);
                pttstate = ptt;
                SetVfo(AorB);
                GetPtt(ptt);

                //this.Invoke(mi);
            }
            catch (WebException)
            {
                RadioTimer.Enabled = false;
                this.Close();
            }
            catch { }
            //}
        }
       //volatile bool Done = false;
        protected override void OnClosing(CancelEventArgs e)
        {
            Log4WinEvents.OnDoubleClicked -= (Log4WinEvents_OnDoubleClicked);
            Log4WinEvents.FrequencyChanged -= Log4WinEvents_FrequencyChanged;
            rd.IsConnected = false;
            try
            {
                //Done = false;
                RadioTimer.Enabled = false;
                //tflrig.Abort();
                GC.SuppressFinalize(rig);

                rig = null;
            }
            catch { }
            base.OnClosing(e);
        }
      
         //~IFlRig(){}
        private void button3_Click(object sender, EventArgs e)
        {
           //rig.RigSetAB("A");
            //double freq = 14086d; rig.RigSetFreq(freq * 1000).ToString();
           // txtFreq.Text= 
            //rig.RigSetMode("CW");
        }
        int pttstate = 0;
        private void chkA_CheckedChanged(object sender, EventArgs e)
        {
            chkB.Checked = !chkA.Checked;
            rig.RigSetAB("A");
            //chkA.Checked = false;
            //chkA.BackColor = Control.DefaultBackColor;
            //chkB.Checked = false;
            //chkB.BackColor = Control.DefaultBackColor;
            //switch (vfo)
            //{
            //    case "A":
            //        chkA.Checked = true;
            //        chkA.BackColor = Color.Lime;
            //        break;
            //    case "B":
            //        chkB.Checked = true;
            //        chkB.BackColor = Color.Lime;
            //        break;
            //}
        }
        Color SetNoRadioColor()
        {
            if (NoRadio)
            {
                return Color.Yellow;
            }
            else
            {
                return Color.Lime;
            }
        }
        private void chkA_CheckStateChanged(object sender, EventArgs e)
        {
            chkA.BackColor = Control.DefaultBackColor;
            if (chkA.Checked)
            {
                chkA.BackColor = SetNoRadioColor();
            }
        }

        private void chkB_CheckedChanged(object sender, EventArgs e)
        {
            chkA.Checked = !chkB.Checked;
            rig.RigSetAB("B");
        }

        private void chkB_CheckStateChanged(object sender, EventArgs e)
        {
            chkB.BackColor = Control.DefaultBackColor;
            if (chkB.Checked)
            {
                chkB.BackColor = SetNoRadioColor();
            }
        }

        private void bPtt_Click(object sender, EventArgs e)
        {
            int x = pttstate == 0 ? 1 : 0;
            rig.RigSetPtt(x);
        }

        private void ModeBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //rig.RigSetMode(ModeBox.GetItemText(ModeBox.SelectedItem));
        }

        private void ModeBox_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void lblFreq_MouseClick(object sender, MouseEventArgs e)
        {
            int StepkHz = Convert.ToInt32(StepBox.Text);
            if (e.Button==MouseButtons.Left)
            {
                MainFrequency = MainFrequency + StepkHz;
            }
            else
            {
                MainFrequency = MainFrequency - StepkHz;
            }

            rig.RigSetFreq(MainFrequency * 1000d);
        }

        private void tableLayoutPanel1_MouseClick(object sender, MouseEventArgs e)
        {
            //this.Focus();
        }

        

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(panel3.BackColor);
            g.DrawLine(new Pen(Color.Blue), new Point(0, panel3.Height / 2),
                new Point(200, panel3.Height / 2));
            int j = 0;
            int x = 0;
            int y1 = panel3.Height / 2;
            for (int i = 0; i < 200; i = i + 2)
            {
                g.DrawLine(new Pen(Color.Blue), new Point(i, y1+5),
                                new Point(i, y1));
                if ((j / 10)*10 == j)
                {
                    g.DrawLine(new Pen(Color.Blue), new Point(i, y1 + 12),
                                new Point(i, y1));
                    
                }
                if ((j / 5) * 5 == j)
                {
                    g.DrawLine(new Pen(Color.Blue), new Point(i, y1 + 8),
                                new Point(i, y1));
                }

               
                j++;
                //x = x + 1;
            }
            System.Drawing.Font fnt = new System.Drawing.Font("Arial", 8.25f, FontStyle.Bold);
            int x1 = 0;
            for (x = 0; x < 200; x = x + 1)
            {

                if ((x / 40) * 40 == x)
                {
                    string p = "";
                    if (x == 0)
                    {
                        p = "P0";
                        x1 = x;
                    }
                    else
                    {
                        p = x.ToString();
                        x1 = x -10;
                    }
                    g.DrawString(p, fnt, Brushes.Black, x1, y1 + 15);
                }
            }
            g.DrawLine(new Pen(Color.Black, 3), new Point(0, y1)
            , new Point(Power, y1-20));
        }

        private void panel3_MouseClick(object sender, MouseEventArgs e)
        {
            //lblPwr.Text = e.X.ToString();
            //panel3.Refresh();
        }
        protected override void OnResize(EventArgs e)
        {
            panel3.Refresh();
            base.OnResize(e);
        }
        private void RadioTimer_Tick(object sender, EventArgs e)
        {
            GetDataRig();
        }

        
    }

   
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Log4WinNet.Log.Properties;
using System.Windows.Forms;

namespace Log4WinNet.Log.CAT
{
    internal class Radio: IDisposable, IHRadio
    {
        //private Timer tmr = new Timer();
        public bool IsConnected = false;
        public IFlRig _myRig;
        public bool noRadio = true;
        public void SetRig(IFlRig myrig)
        {
            this._myRig = myrig;
        }
        public void GetNoRadio(string radio)
        {
            noRadio = radio.IsNullOrEmpty();
        }
        public void SetMode(string aMode)
        {
            if (!IsConnected) return;
            string rMode = aMode;
            bool bb = clsFcm.IsDigiMode(aMode);
            if (clsFcm.IsDigiMode(aMode))
            {
                rMode = Settings.Default.RadioMode;

            }
            //else
            //{
               
           
            if (this._myRig != null)
            {
                this._myRig.RigSetMode(rMode);
            }
          
        }
        public void SetFrequency(double aFreq)
        {
            if (!IsConnected) return;
            if (this._myRig != null)
            {
                this._myRig.RigSetFreq(aFreq * 1e3d);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
            _myRig = null;
            GC.SuppressFinalize(this);
        }
        ~Radio() { Dispose(); }


        bool IHRadio.IsConnected
        {
            get
            {
                return IsConnected;
            }
            set
            {
                IsConnected=value;
            }
        }

        bool IHRadio.noRadio
        {
            get
            {
                return noRadio;
            }
            set
            {
                noRadio = value;
            }
        }

        //public int CatType()
        //{
        //    throw new NotImplementedException();
        //}

        public void SetRig<T>(T myrig)
        {
            if (Settings.Default.CatType.Equals(1))
            {
                _myRig = myrig as IFlRig;
            }
            //throw new NotImplementedException();
        }
    }

    public interface IHRadio
    {
         void SetRig<T>(T myrig);
        bool IsConnected { get; set; }
        bool noRadio { get; set; }
        void GetNoRadio(string radio);
        void SetMode(string aMode);
        void SetFrequency(double aFreq);
        //int CatType();
    }
}

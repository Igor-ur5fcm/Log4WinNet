namespace Log4WinNet.Log.CAT
{
    partial class CatRigControl
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.bPtt = new System.Windows.Forms.ToolStripStatusLabel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblMode = new System.Windows.Forms.Label();
            this.lblFreq = new System.Windows.Forms.Label();
            this.chkB = new System.Windows.Forms.CheckBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.chkA = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.StepBox = new System.Windows.Forms.ComboBox();
            this.button3 = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblPwr = new System.Windows.Forms.Label();
            this.ListFreq = new System.Windows.Forms.ListBox();
            this.RadioTimer = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bPtt});
            this.statusStrip1.Location = new System.Drawing.Point(0, 215);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(395, 22);
            this.statusStrip1.TabIndex = 12;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // bPtt
            // 
            this.bPtt.Name = "bPtt";
            this.bPtt.Size = new System.Drawing.Size(28, 17);
            this.bPtt.Text = "PTT";
            this.bPtt.Click += new System.EventHandler(this.bPtt_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 61.51899F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 38.48101F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.button3, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.ListFreq, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 71F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 73F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(395, 215);
            this.tableLayoutPanel1.TabIndex = 13;
            this.tableLayoutPanel1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tableLayoutPanel1_MouseClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblMode);
            this.panel1.Controls.Add(this.lblFreq);
            this.panel1.Controls.Add(this.chkB);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.chkA);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(237, 65);
            this.panel1.TabIndex = 12;
            // 
            // lblMode
            // 
            this.lblMode.BackColor = System.Drawing.Color.Azure;
            this.lblMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblMode.Location = new System.Drawing.Point(151, 3);
            this.lblMode.Name = "lblMode";
            this.lblMode.Size = new System.Drawing.Size(52, 23);
            this.lblMode.TabIndex = 24;
            // 
            // lblFreq
            // 
            this.lblFreq.BackColor = System.Drawing.Color.Azure;
            this.lblFreq.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblFreq.Location = new System.Drawing.Point(3, 3);
            this.lblFreq.Name = "lblFreq";
            this.lblFreq.Size = new System.Drawing.Size(142, 26);
            this.lblFreq.TabIndex = 23;
            this.lblFreq.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lblFreq_MouseClick);
            // 
            // chkB
            // 
            this.chkB.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkB.AutoSize = true;
            this.chkB.Location = new System.Drawing.Point(33, 42);
            this.chkB.Name = "chkB";
            this.chkB.Size = new System.Drawing.Size(39, 23);
            this.chkB.TabIndex = 19;
            this.chkB.Text = "vfoB";
            this.chkB.UseVisualStyleBackColor = true;
            this.chkB.CheckedChanged += new System.EventHandler(this.chkB_CheckedChanged);
            this.chkB.CheckStateChanged += new System.EventHandler(this.chkB_CheckStateChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Azure;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(237, 42);
            this.pictureBox1.TabIndex = 22;
            this.pictureBox1.TabStop = false;
            // 
            // chkA
            // 
            this.chkA.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkA.AutoSize = true;
            this.chkA.Location = new System.Drawing.Point(-3, 42);
            this.chkA.Name = "chkA";
            this.chkA.Size = new System.Drawing.Size(39, 23);
            this.chkA.TabIndex = 18;
            this.chkA.Text = "vfoA";
            this.chkA.UseVisualStyleBackColor = true;
            this.chkA.CheckedChanged += new System.EventHandler(this.chkA_CheckedChanged);
            this.chkA.CheckStateChanged += new System.EventHandler(this.chkA_CheckStateChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.StepBox);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(246, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(146, 65);
            this.panel2.TabIndex = 18;
            // 
            // StepBox
            // 
            this.StepBox.BackColor = System.Drawing.Color.Honeydew;
            this.StepBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.StepBox.ForeColor = System.Drawing.Color.DarkBlue;
            this.StepBox.FormattingEnabled = true;
            this.StepBox.Location = new System.Drawing.Point(3, 3);
            this.StepBox.Name = "StepBox";
            this.StepBox.Size = new System.Drawing.Size(94, 23);
            this.StepBox.TabIndex = 21;
            this.StepBox.TabStop = false;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(246, 74);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(63, 23);
            this.button3.TabIndex = 14;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Visible = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FloralWhite;
            this.panel3.Controls.Add(this.lblPwr);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 74);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(237, 65);
            this.panel3.TabIndex = 20;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            this.panel3.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panel3_MouseClick);
            // 
            // lblPwr
            // 
            this.lblPwr.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblPwr.Location = new System.Drawing.Point(3, 0);
            this.lblPwr.Name = "lblPwr";
            this.lblPwr.Size = new System.Drawing.Size(43, 13);
            this.lblPwr.TabIndex = 21;
            // 
            // ListFreq
            // 
            this.ListFreq.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListFreq.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ListFreq.FormattingEnabled = true;
            this.ListFreq.ItemHeight = 15;
            this.ListFreq.Location = new System.Drawing.Point(3, 145);
            this.ListFreq.MultiColumn = true;
            this.ListFreq.Name = "ListFreq";
            this.ListFreq.Size = new System.Drawing.Size(237, 67);
            this.ListFreq.TabIndex = 21;
            // 
            // RadioTimer
            // 
            this.RadioTimer.Interval = 2000;
            this.RadioTimer.Tick += new System.EventHandler(this.RadioTimer_Tick);
            // 
            // CatRigControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(395, 237);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.statusStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MaximizeBox = false;
            this.Name = "CatRigControl";
            this.Text = "Form2";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox chkA;
        private System.Windows.Forms.CheckBox chkB;
        private System.Windows.Forms.ComboBox StepBox;
        private System.Windows.Forms.ToolStripStatusLabel bPtt;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblFreq;
        private System.Windows.Forms.Label lblMode;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblPwr;
        private System.Windows.Forms.ListBox ListFreq;
        private System.Windows.Forms.Timer RadioTimer;
    }
}
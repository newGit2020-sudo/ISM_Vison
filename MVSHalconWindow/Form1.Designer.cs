
namespace MVSHalconWindow
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.bnEnum = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.bnTriggerExec = new System.Windows.Forms.Button();
            this.cbSoftTrigger = new System.Windows.Forms.CheckBox();
            this.bnStopGrab = new System.Windows.Forms.Button();
            this.bnStartGrab = new System.Windows.Forms.Button();
            this.bnTriggerMode = new System.Windows.Forms.RadioButton();
            this.bnContinuesMode = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.bnClose = new System.Windows.Forms.Button();
            this.bnOpen = new System.Windows.Forms.Button();
            this.cbDeviceList = new System.Windows.Forms.ComboBox();
            this.tbExposure = new System.Windows.Forms.TextBox();
            this.bnGetParam = new System.Windows.Forms.Button();
            this.tbGain = new System.Windows.Forms.TextBox();
            this.bnSetParam = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.pictureBox1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pictureBox1.Location = new System.Drawing.Point(10, 48);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(714, 523);
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // bnEnum
            // 
            this.bnEnum.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bnEnum.Location = new System.Drawing.Point(20, 29);
            this.bnEnum.Name = "bnEnum";
            this.bnEnum.Size = new System.Drawing.Size(161, 23);
            this.bnEnum.TabIndex = 0;
            this.bnEnum.Text = "查找设备";
            this.bnEnum.UseVisualStyleBackColor = true;
            this.bnEnum.Click += new System.EventHandler(this.bnEnum_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.bnTriggerExec);
            this.groupBox2.Controls.Add(this.cbSoftTrigger);
            this.groupBox2.Controls.Add(this.bnStopGrab);
            this.groupBox2.Controls.Add(this.bnStartGrab);
            this.groupBox2.Controls.Add(this.bnTriggerMode);
            this.groupBox2.Controls.Add(this.bnContinuesMode);
            this.groupBox2.Location = new System.Drawing.Point(730, 143);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 162);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "采集图像";
            // 
            // bnTriggerExec
            // 
            this.bnTriggerExec.Enabled = false;
            this.bnTriggerExec.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bnTriggerExec.Location = new System.Drawing.Point(106, 102);
            this.bnTriggerExec.Name = "bnTriggerExec";
            this.bnTriggerExec.Size = new System.Drawing.Size(75, 23);
            this.bnTriggerExec.TabIndex = 5;
            this.bnTriggerExec.Text = "软触发一次";
            this.bnTriggerExec.UseVisualStyleBackColor = true;
            // 
            // cbSoftTrigger
            // 
            this.cbSoftTrigger.AutoSize = true;
            this.cbSoftTrigger.Enabled = false;
            this.cbSoftTrigger.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cbSoftTrigger.Location = new System.Drawing.Point(20, 109);
            this.cbSoftTrigger.Name = "cbSoftTrigger";
            this.cbSoftTrigger.Size = new System.Drawing.Size(60, 16);
            this.cbSoftTrigger.TabIndex = 4;
            this.cbSoftTrigger.Text = "软触发";
            this.cbSoftTrigger.UseVisualStyleBackColor = true;
            this.cbSoftTrigger.Click += new System.EventHandler(this.cbSoftTrigger_CheckedChanged);
            // 
            // bnStopGrab
            // 
            this.bnStopGrab.Enabled = false;
            this.bnStopGrab.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bnStopGrab.Location = new System.Drawing.Point(106, 69);
            this.bnStopGrab.Name = "bnStopGrab";
            this.bnStopGrab.Size = new System.Drawing.Size(75, 23);
            this.bnStopGrab.TabIndex = 3;
            this.bnStopGrab.Text = "停止采集";
            this.bnStopGrab.UseVisualStyleBackColor = true;
            this.bnStopGrab.Click += new System.EventHandler(this.bnStopGrab_Click);
            // 
            // bnStartGrab
            // 
            this.bnStartGrab.Enabled = false;
            this.bnStartGrab.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bnStartGrab.Location = new System.Drawing.Point(20, 69);
            this.bnStartGrab.Name = "bnStartGrab";
            this.bnStartGrab.Size = new System.Drawing.Size(75, 23);
            this.bnStartGrab.TabIndex = 2;
            this.bnStartGrab.Text = "开始采集";
            this.bnStartGrab.UseVisualStyleBackColor = true;
            this.bnStartGrab.Click += new System.EventHandler(this.bnStartGrab_Click);
            // 
            // bnTriggerMode
            // 
            this.bnTriggerMode.AutoSize = true;
            this.bnTriggerMode.Enabled = false;
            this.bnTriggerMode.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bnTriggerMode.Location = new System.Drawing.Point(110, 42);
            this.bnTriggerMode.Name = "bnTriggerMode";
            this.bnTriggerMode.Size = new System.Drawing.Size(71, 16);
            this.bnTriggerMode.TabIndex = 1;
            this.bnTriggerMode.TabStop = true;
            this.bnTriggerMode.Text = "触发模式";
            this.bnTriggerMode.UseVisualStyleBackColor = true;
            this.bnTriggerMode.Click += new System.EventHandler(this.bnTriggerMode_CheckedChanged);
            // 
            // bnContinuesMode
            // 
            this.bnContinuesMode.AutoSize = true;
            this.bnContinuesMode.Enabled = false;
            this.bnContinuesMode.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bnContinuesMode.Location = new System.Drawing.Point(20, 42);
            this.bnContinuesMode.Name = "bnContinuesMode";
            this.bnContinuesMode.Size = new System.Drawing.Size(71, 16);
            this.bnContinuesMode.TabIndex = 0;
            this.bnContinuesMode.TabStop = true;
            this.bnContinuesMode.Text = "连续模式";
            this.bnContinuesMode.UseVisualStyleBackColor = true;
            this.bnContinuesMode.Click += new System.EventHandler(this.bnContinuesMode_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.bnClose);
            this.groupBox1.Controls.Add(this.bnOpen);
            this.groupBox1.Controls.Add(this.bnEnum);
            this.groupBox1.Location = new System.Drawing.Point(730, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 125);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "初始化";
            // 
            // bnClose
            // 
            this.bnClose.Enabled = false;
            this.bnClose.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bnClose.Location = new System.Drawing.Point(106, 80);
            this.bnClose.Name = "bnClose";
            this.bnClose.Size = new System.Drawing.Size(75, 23);
            this.bnClose.TabIndex = 2;
            this.bnClose.Text = "关闭设备";
            this.bnClose.UseVisualStyleBackColor = true;
            this.bnClose.Click += new System.EventHandler(this.bnClose_Click);
            // 
            // bnOpen
            // 
            this.bnOpen.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bnOpen.Location = new System.Drawing.Point(20, 80);
            this.bnOpen.Name = "bnOpen";
            this.bnOpen.Size = new System.Drawing.Size(75, 23);
            this.bnOpen.TabIndex = 1;
            this.bnOpen.Text = "打开设备";
            this.bnOpen.UseVisualStyleBackColor = true;
            this.bnOpen.Click += new System.EventHandler(this.bnOpen_Click);
            // 
            // cbDeviceList
            // 
            this.cbDeviceList.FormattingEnabled = true;
            this.cbDeviceList.Location = new System.Drawing.Point(10, 11);
            this.cbDeviceList.Name = "cbDeviceList";
            this.cbDeviceList.Size = new System.Drawing.Size(714, 20);
            this.cbDeviceList.TabIndex = 10;
            // 
            // tbExposure
            // 
            this.tbExposure.Location = new System.Drawing.Point(50, 42);
            this.tbExposure.Name = "tbExposure";
            this.tbExposure.Size = new System.Drawing.Size(98, 21);
            this.tbExposure.TabIndex = 10;
            // 
            // bnGetParam
            // 
            this.bnGetParam.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bnGetParam.Location = new System.Drawing.Point(17, 183);
            this.bnGetParam.Name = "bnGetParam";
            this.bnGetParam.Size = new System.Drawing.Size(74, 23);
            this.bnGetParam.TabIndex = 8;
            this.bnGetParam.Text = "获取参数";
            this.bnGetParam.UseVisualStyleBackColor = true;
            this.bnGetParam.Click += new System.EventHandler(this.bnGetParam_Click);
            // 
            // tbGain
            // 
            this.tbGain.Location = new System.Drawing.Point(50, 98);
            this.tbGain.Name = "tbGain";
            this.tbGain.Size = new System.Drawing.Size(98, 21);
            this.tbGain.TabIndex = 11;
            // 
            // bnSetParam
            // 
            this.bnSetParam.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bnSetParam.Location = new System.Drawing.Point(106, 183);
            this.bnSetParam.Name = "bnSetParam";
            this.bnSetParam.Size = new System.Drawing.Size(75, 23);
            this.bnSetParam.TabIndex = 9;
            this.bnSetParam.Text = "设置参数";
            this.bnSetParam.UseVisualStyleBackColor = true;
            this.bnSetParam.Click += new System.EventHandler(this.bnSetParam_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.bnSetParam);
            this.groupBox3.Controls.Add(this.tbGain);
            this.groupBox3.Controls.Add(this.bnGetParam);
            this.groupBox3.Controls.Add(this.tbExposure);
            this.groupBox3.Location = new System.Drawing.Point(730, 311);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(200, 260);
            this.groupBox3.TabIndex = 14;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "相机参数";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(52, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 12;
            this.label2.Text = "Gain";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(54, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 12;
            this.label1.Text = "ExposureTime";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(942, 601);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cbDeviceList);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button bnEnum;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button bnTriggerExec;
        private System.Windows.Forms.CheckBox cbSoftTrigger;
        private System.Windows.Forms.Button bnStopGrab;
        private System.Windows.Forms.Button bnStartGrab;
        private System.Windows.Forms.RadioButton bnTriggerMode;
        private System.Windows.Forms.RadioButton bnContinuesMode;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button bnClose;
        private System.Windows.Forms.Button bnOpen;
        private System.Windows.Forms.ComboBox cbDeviceList;
        private System.Windows.Forms.TextBox tbExposure;
        private System.Windows.Forms.Button bnGetParam;
        private System.Windows.Forms.TextBox tbGain;
        private System.Windows.Forms.Button bnSetParam;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}


namespace DarboLaikoSkaiciavimoSistema.Views
{
    partial class VideoSourceView
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
            this.localizationControl1 = new DarboLaikoSkaiciavimoSistema.Controls.LocalizationControl();
            this.userInfoControl1 = new DarboLaikoSkaiciavimoSistema.Controls.UserInfoControl();
            this.backNavigatorControl1 = new DarboLaikoSkaiciavimoSistema.Controls.BackNavigatorControl();
            this.lblChannel = new System.Windows.Forms.Label();
            this.lblStartTime = new System.Windows.Forms.Label();
            this.lblEndTime = new System.Windows.Forms.Label();
            this.dtStartTime = new System.Windows.Forms.DateTimePicker();
            this.dtEndTime = new System.Windows.Forms.DateTimePicker();
            this.lblVideoSource = new System.Windows.Forms.Label();
            this.btnSelect = new System.Windows.Forms.Button();
            this.numChannel = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numChannel)).BeginInit();
            this.SuspendLayout();
            // 
            // localizationControl1
            // 
            this.localizationControl1.Location = new System.Drawing.Point(12, 12);
            this.localizationControl1.Name = "localizationControl1";
            this.localizationControl1.Size = new System.Drawing.Size(110, 45);
            this.localizationControl1.TabIndex = 0;
            // 
            // userInfoControl1
            // 
            this.userInfoControl1.Location = new System.Drawing.Point(441, 12);
            this.userInfoControl1.Name = "userInfoControl1";
            this.userInfoControl1.Size = new System.Drawing.Size(285, 44);
            this.userInfoControl1.TabIndex = 1;
            // 
            // backNavigatorControl1
            // 
            this.backNavigatorControl1.Location = new System.Drawing.Point(12, 307);
            this.backNavigatorControl1.Name = "backNavigatorControl1";
            this.backNavigatorControl1.Size = new System.Drawing.Size(143, 45);
            this.backNavigatorControl1.TabIndex = 2;
            // 
            // lblChannel
            // 
            this.lblChannel.AutoSize = true;
            this.lblChannel.Location = new System.Drawing.Point(21, 117);
            this.lblChannel.Name = "lblChannel";
            this.lblChannel.Size = new System.Drawing.Size(35, 13);
            this.lblChannel.TabIndex = 3;
            this.lblChannel.Text = "label1";
            // 
            // lblStartTime
            // 
            this.lblStartTime.AutoSize = true;
            this.lblStartTime.Location = new System.Drawing.Point(21, 177);
            this.lblStartTime.Name = "lblStartTime";
            this.lblStartTime.Size = new System.Drawing.Size(35, 13);
            this.lblStartTime.TabIndex = 4;
            this.lblStartTime.Text = "label1";
            // 
            // lblEndTime
            // 
            this.lblEndTime.AutoSize = true;
            this.lblEndTime.Location = new System.Drawing.Point(333, 177);
            this.lblEndTime.Name = "lblEndTime";
            this.lblEndTime.Size = new System.Drawing.Size(35, 13);
            this.lblEndTime.TabIndex = 5;
            this.lblEndTime.Text = "label1";
            // 
            // dtStartTime
            // 
            this.dtStartTime.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtStartTime.Location = new System.Drawing.Point(24, 193);
            this.dtStartTime.Name = "dtStartTime";
            this.dtStartTime.Size = new System.Drawing.Size(200, 20);
            this.dtStartTime.TabIndex = 6;
            // 
            // dtEndTime
            // 
            this.dtEndTime.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtEndTime.Location = new System.Drawing.Point(336, 193);
            this.dtEndTime.Name = "dtEndTime";
            this.dtEndTime.Size = new System.Drawing.Size(200, 20);
            this.dtEndTime.TabIndex = 7;
            // 
            // lblVideoSource
            // 
            this.lblVideoSource.AutoSize = true;
            this.lblVideoSource.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVideoSource.Location = new System.Drawing.Point(12, 60);
            this.lblVideoSource.Name = "lblVideoSource";
            this.lblVideoSource.Size = new System.Drawing.Size(51, 16);
            this.lblVideoSource.TabIndex = 10;
            this.lblVideoSource.Text = "label1";
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(562, 314);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(164, 38);
            this.btnSelect.TabIndex = 9;
            this.btnSelect.Text = "button1";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // numChannel
            // 
            this.numChannel.Location = new System.Drawing.Point(24, 133);
            this.numChannel.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numChannel.Name = "numChannel";
            this.numChannel.Size = new System.Drawing.Size(200, 20);
            this.numChannel.TabIndex = 11;
            // 
            // VideoSourceView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(738, 364);
            this.Controls.Add(this.numChannel);
            this.Controls.Add(this.lblVideoSource);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.dtEndTime);
            this.Controls.Add(this.dtStartTime);
            this.Controls.Add(this.lblEndTime);
            this.Controls.Add(this.lblStartTime);
            this.Controls.Add(this.lblChannel);
            this.Controls.Add(this.backNavigatorControl1);
            this.Controls.Add(this.userInfoControl1);
            this.Controls.Add(this.localizationControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "VideoSourceView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VideoSourceView";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.VideoSourceView_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.numChannel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controls.LocalizationControl localizationControl1;
        private Controls.UserInfoControl userInfoControl1;
        private Controls.BackNavigatorControl backNavigatorControl1;
        private System.Windows.Forms.Label lblChannel;
        private System.Windows.Forms.Label lblStartTime;
        private System.Windows.Forms.Label lblEndTime;
        private System.Windows.Forms.DateTimePicker dtStartTime;
        private System.Windows.Forms.DateTimePicker dtEndTime;
        private System.Windows.Forms.Label lblVideoSource;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.NumericUpDown numChannel;
    }
}
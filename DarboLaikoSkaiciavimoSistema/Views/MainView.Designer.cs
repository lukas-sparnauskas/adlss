namespace DarboLaikoSkaiciavimoSistema.Views
{
    partial class MainView
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
            this.localizationControl1 = new DarboLaikoSkaiciavimoSistema.Controls.LocalizationControl();
            this.btnStatistics = new System.Windows.Forms.Button();
            this.lblRemainingTimeLabel = new System.Windows.Forms.Label();
            this.btnUsers = new System.Windows.Forms.Button();
            this.btnRecordings = new System.Windows.Forms.Button();
            this.btnLiveFeed = new System.Windows.Forms.Button();
            this.btnSettings = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.userInfoControl1 = new DarboLaikoSkaiciavimoSistema.Controls.UserInfoControl();
            this.btnRegisterUser = new System.Windows.Forms.Button();
            this.lblRemainingTime = new System.Windows.Forms.Label();
            this.timerRemainingWorktimeToday = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // localizationControl1
            // 
            this.localizationControl1.Location = new System.Drawing.Point(13, 13);
            this.localizationControl1.Name = "localizationControl1";
            this.localizationControl1.Size = new System.Drawing.Size(110, 45);
            this.localizationControl1.TabIndex = 0;
            // 
            // btnStatistics
            // 
            this.btnStatistics.Location = new System.Drawing.Point(354, 62);
            this.btnStatistics.Name = "btnStatistics";
            this.btnStatistics.Size = new System.Drawing.Size(240, 36);
            this.btnStatistics.TabIndex = 1;
            this.btnStatistics.Text = "button1";
            this.btnStatistics.UseVisualStyleBackColor = true;
            this.btnStatistics.Click += new System.EventHandler(this.btnStatistics_Click);
            // 
            // lblRemainingTimeLabel
            // 
            this.lblRemainingTimeLabel.AutoSize = true;
            this.lblRemainingTimeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRemainingTimeLabel.Location = new System.Drawing.Point(21, 96);
            this.lblRemainingTimeLabel.Name = "lblRemainingTimeLabel";
            this.lblRemainingTimeLabel.Size = new System.Drawing.Size(41, 13);
            this.lblRemainingTimeLabel.TabIndex = 3;
            this.lblRemainingTimeLabel.Text = "label1";
            // 
            // btnUsers
            // 
            this.btnUsers.Location = new System.Drawing.Point(354, 150);
            this.btnUsers.Name = "btnUsers";
            this.btnUsers.Size = new System.Drawing.Size(240, 36);
            this.btnUsers.TabIndex = 5;
            this.btnUsers.Text = "button1";
            this.btnUsers.UseVisualStyleBackColor = true;
            this.btnUsers.Click += new System.EventHandler(this.btnUsers_Click);
            // 
            // btnRecordings
            // 
            this.btnRecordings.Location = new System.Drawing.Point(354, 192);
            this.btnRecordings.Name = "btnRecordings";
            this.btnRecordings.Size = new System.Drawing.Size(240, 36);
            this.btnRecordings.TabIndex = 6;
            this.btnRecordings.Text = "button1";
            this.btnRecordings.UseVisualStyleBackColor = true;
            this.btnRecordings.Click += new System.EventHandler(this.btnRecordings_Click);
            // 
            // btnLiveFeed
            // 
            this.btnLiveFeed.Location = new System.Drawing.Point(354, 234);
            this.btnLiveFeed.Name = "btnLiveFeed";
            this.btnLiveFeed.Size = new System.Drawing.Size(240, 36);
            this.btnLiveFeed.TabIndex = 7;
            this.btnLiveFeed.Text = "button1";
            this.btnLiveFeed.UseVisualStyleBackColor = true;
            this.btnLiveFeed.Click += new System.EventHandler(this.btnLiveFeed_Click);
            // 
            // btnSettings
            // 
            this.btnSettings.Location = new System.Drawing.Point(354, 276);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(240, 36);
            this.btnSettings.TabIndex = 8;
            this.btnSettings.Text = "button1";
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(24, 276);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(135, 36);
            this.btnLogout.TabIndex = 10;
            this.btnLogout.Text = "button1";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // userInfoControl1
            // 
            this.userInfoControl1.Location = new System.Drawing.Point(317, 12);
            this.userInfoControl1.Name = "userInfoControl1";
            this.userInfoControl1.Size = new System.Drawing.Size(285, 44);
            this.userInfoControl1.TabIndex = 11;
            // 
            // btnRegisterUser
            // 
            this.btnRegisterUser.Location = new System.Drawing.Point(354, 106);
            this.btnRegisterUser.Name = "btnRegisterUser";
            this.btnRegisterUser.Size = new System.Drawing.Size(240, 36);
            this.btnRegisterUser.TabIndex = 12;
            this.btnRegisterUser.Text = "button1";
            this.btnRegisterUser.UseVisualStyleBackColor = true;
            this.btnRegisterUser.Click += new System.EventHandler(this.btnRegisterUser_Click);
            // 
            // lblRemainingTime
            // 
            this.lblRemainingTime.AutoSize = true;
            this.lblRemainingTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRemainingTime.Location = new System.Drawing.Point(19, 109);
            this.lblRemainingTime.Name = "lblRemainingTime";
            this.lblRemainingTime.Size = new System.Drawing.Size(76, 25);
            this.lblRemainingTime.TabIndex = 4;
            this.lblRemainingTime.Text = "label1";
            // 
            // timerRemainingWorktimeToday
            // 
            this.timerRemainingWorktimeToday.Interval = 1000;
            this.timerRemainingWorktimeToday.Tick += new System.EventHandler(this.timerRemainingWorktimeToday_Tick_1);
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(614, 324);
            this.Controls.Add(this.btnRegisterUser);
            this.Controls.Add(this.userInfoControl1);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnSettings);
            this.Controls.Add(this.btnLiveFeed);
            this.Controls.Add(this.btnRecordings);
            this.Controls.Add(this.btnUsers);
            this.Controls.Add(this.lblRemainingTime);
            this.Controls.Add(this.lblRemainingTimeLabel);
            this.Controls.Add(this.btnStatistics);
            this.Controls.Add(this.localizationControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainView";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainView_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controls.LocalizationControl localizationControl1;
        private System.Windows.Forms.Button btnStatistics;
        private System.Windows.Forms.Label lblRemainingTimeLabel;
        private System.Windows.Forms.Button btnUsers;
        private System.Windows.Forms.Button btnRecordings;
        private System.Windows.Forms.Button btnLiveFeed;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Button btnLogout;
        private Controls.UserInfoControl userInfoControl1;
        private System.Windows.Forms.Button btnRegisterUser;
        private System.Windows.Forms.Label lblRemainingTime;
        private System.Windows.Forms.Timer timerRemainingWorktimeToday;
    }
}
namespace DarboLaikoSkaiciavimoSistema.Views
{
    partial class PasswordResetEmailView
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
            this.backNavigatorControl1 = new DarboLaikoSkaiciavimoSistema.Controls.BackNavigatorControl();
            this.localizationControl1 = new DarboLaikoSkaiciavimoSistema.Controls.LocalizationControl();
            this.lblResetPassword = new System.Windows.Forms.Label();
            this.btnCheckEmail = new System.Windows.Forms.Button();
            this.tbEmail = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblResetCodeInfo = new System.Windows.Forms.Label();
            this.lblResetCode = new System.Windows.Forms.Label();
            this.tbResetCode = new System.Windows.Forms.TextBox();
            this.btnSendCode = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // backNavigatorControl1
            // 
            this.backNavigatorControl1.Location = new System.Drawing.Point(12, 279);
            this.backNavigatorControl1.Name = "backNavigatorControl1";
            this.backNavigatorControl1.Size = new System.Drawing.Size(143, 45);
            this.backNavigatorControl1.TabIndex = 4;
            // 
            // localizationControl1
            // 
            this.localizationControl1.Location = new System.Drawing.Point(13, 13);
            this.localizationControl1.Name = "localizationControl1";
            this.localizationControl1.Size = new System.Drawing.Size(110, 45);
            this.localizationControl1.TabIndex = 3;
            // 
            // lblResetPassword
            // 
            this.lblResetPassword.AutoSize = true;
            this.lblResetPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResetPassword.Location = new System.Drawing.Point(24, 61);
            this.lblResetPassword.Name = "lblResetPassword";
            this.lblResetPassword.Size = new System.Drawing.Size(51, 16);
            this.lblResetPassword.TabIndex = 8;
            this.lblResetPassword.Text = "label1";
            // 
            // btnCheckEmail
            // 
            this.btnCheckEmail.Location = new System.Drawing.Point(510, 284);
            this.btnCheckEmail.Name = "btnCheckEmail";
            this.btnCheckEmail.Size = new System.Drawing.Size(134, 36);
            this.btnCheckEmail.TabIndex = 9;
            this.btnCheckEmail.Text = "button1";
            this.btnCheckEmail.UseVisualStyleBackColor = true;
            this.btnCheckEmail.Click += new System.EventHandler(this.btnCheckEmail_Click);
            // 
            // tbEmail
            // 
            this.tbEmail.Location = new System.Drawing.Point(145, 128);
            this.tbEmail.Name = "tbEmail";
            this.tbEmail.Size = new System.Drawing.Size(299, 20);
            this.tbEmail.TabIndex = 13;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(142, 112);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(35, 13);
            this.lblEmail.TabIndex = 12;
            this.lblEmail.Text = "label1";
            // 
            // lblResetCodeInfo
            // 
            this.lblResetCodeInfo.AutoSize = true;
            this.lblResetCodeInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResetCodeInfo.Location = new System.Drawing.Point(142, 151);
            this.lblResetCodeInfo.Name = "lblResetCodeInfo";
            this.lblResetCodeInfo.Size = new System.Drawing.Size(41, 13);
            this.lblResetCodeInfo.TabIndex = 14;
            this.lblResetCodeInfo.Text = "label1";
            // 
            // lblResetCode
            // 
            this.lblResetCode.AutoSize = true;
            this.lblResetCode.Location = new System.Drawing.Point(142, 196);
            this.lblResetCode.Name = "lblResetCode";
            this.lblResetCode.Size = new System.Drawing.Size(35, 13);
            this.lblResetCode.TabIndex = 24;
            this.lblResetCode.Text = "label1";
            // 
            // tbResetCode
            // 
            this.tbResetCode.Location = new System.Drawing.Point(145, 212);
            this.tbResetCode.Name = "tbResetCode";
            this.tbResetCode.Size = new System.Drawing.Size(127, 20);
            this.tbResetCode.TabIndex = 23;
            // 
            // btnSendCode
            // 
            this.btnSendCode.Location = new System.Drawing.Point(461, 121);
            this.btnSendCode.Name = "btnSendCode";
            this.btnSendCode.Size = new System.Drawing.Size(108, 27);
            this.btnSendCode.TabIndex = 25;
            this.btnSendCode.Text = "button1";
            this.btnSendCode.UseVisualStyleBackColor = true;
            this.btnSendCode.Click += new System.EventHandler(this.btnSendCode_Click);
            // 
            // PasswordResetEmailView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(661, 333);
            this.Controls.Add(this.btnSendCode);
            this.Controls.Add(this.lblResetCode);
            this.Controls.Add(this.tbResetCode);
            this.Controls.Add(this.lblResetCodeInfo);
            this.Controls.Add(this.tbEmail);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.btnCheckEmail);
            this.Controls.Add(this.lblResetPassword);
            this.Controls.Add(this.backNavigatorControl1);
            this.Controls.Add(this.localizationControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "PasswordResetEmailView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PasswordResetEmailView";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PasswordResetEmailView_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Controls.BackNavigatorControl backNavigatorControl1;
        private Controls.LocalizationControl localizationControl1;
        private System.Windows.Forms.Label lblResetPassword;
        private System.Windows.Forms.Button btnCheckEmail;
        private System.Windows.Forms.TextBox tbEmail;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblResetCodeInfo;
        private System.Windows.Forms.Label lblResetCode;
        private System.Windows.Forms.TextBox tbResetCode;
        private System.Windows.Forms.Button btnSendCode;
    }
}
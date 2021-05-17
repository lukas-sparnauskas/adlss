namespace DarboLaikoSkaiciavimoSistema.Views
{
    partial class PasswordResetView
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
            this.lblConfirmPassword = new System.Windows.Forms.Label();
            this.tbConfirmPassword = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.btnResetPassword = new System.Windows.Forms.Button();
            this.lblPasswordRequirements = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // backNavigatorControl1
            // 
            this.backNavigatorControl1.Location = new System.Drawing.Point(12, 279);
            this.backNavigatorControl1.Name = "backNavigatorControl1";
            this.backNavigatorControl1.Size = new System.Drawing.Size(143, 45);
            this.backNavigatorControl1.TabIndex = 7;
            // 
            // localizationControl1
            // 
            this.localizationControl1.Location = new System.Drawing.Point(13, 13);
            this.localizationControl1.Name = "localizationControl1";
            this.localizationControl1.Size = new System.Drawing.Size(110, 45);
            this.localizationControl1.TabIndex = 6;
            // 
            // lblResetPassword
            // 
            this.lblResetPassword.AutoSize = true;
            this.lblResetPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResetPassword.Location = new System.Drawing.Point(25, 61);
            this.lblResetPassword.Name = "lblResetPassword";
            this.lblResetPassword.Size = new System.Drawing.Size(51, 16);
            this.lblResetPassword.TabIndex = 9;
            this.lblResetPassword.Text = "label1";
            // 
            // lblConfirmPassword
            // 
            this.lblConfirmPassword.AutoSize = true;
            this.lblConfirmPassword.Location = new System.Drawing.Point(25, 169);
            this.lblConfirmPassword.Name = "lblConfirmPassword";
            this.lblConfirmPassword.Size = new System.Drawing.Size(35, 13);
            this.lblConfirmPassword.TabIndex = 18;
            this.lblConfirmPassword.Text = "label1";
            // 
            // tbConfirmPassword
            // 
            this.tbConfirmPassword.Location = new System.Drawing.Point(28, 185);
            this.tbConfirmPassword.Name = "tbConfirmPassword";
            this.tbConfirmPassword.PasswordChar = '•';
            this.tbConfirmPassword.Size = new System.Drawing.Size(258, 20);
            this.tbConfirmPassword.TabIndex = 17;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(25, 124);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(35, 13);
            this.lblPassword.TabIndex = 16;
            this.lblPassword.Text = "label1";
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(28, 140);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.PasswordChar = '•';
            this.tbPassword.Size = new System.Drawing.Size(258, 20);
            this.tbPassword.TabIndex = 15;
            // 
            // btnResetPassword
            // 
            this.btnResetPassword.Location = new System.Drawing.Point(543, 282);
            this.btnResetPassword.Name = "btnResetPassword";
            this.btnResetPassword.Size = new System.Drawing.Size(134, 36);
            this.btnResetPassword.TabIndex = 19;
            this.btnResetPassword.Text = "button1";
            this.btnResetPassword.UseVisualStyleBackColor = true;
            this.btnResetPassword.Click += new System.EventHandler(this.btnResetPassword_Click);
            // 
            // lblPasswordRequirements
            // 
            this.lblPasswordRequirements.AutoSize = true;
            this.lblPasswordRequirements.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPasswordRequirements.Location = new System.Drawing.Point(348, 124);
            this.lblPasswordRequirements.Name = "lblPasswordRequirements";
            this.lblPasswordRequirements.Size = new System.Drawing.Size(41, 13);
            this.lblPasswordRequirements.TabIndex = 20;
            this.lblPasswordRequirements.Text = "label1";
            // 
            // PasswordResetView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(689, 336);
            this.Controls.Add(this.lblPasswordRequirements);
            this.Controls.Add(this.btnResetPassword);
            this.Controls.Add(this.lblConfirmPassword);
            this.Controls.Add(this.tbConfirmPassword);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.tbPassword);
            this.Controls.Add(this.lblResetPassword);
            this.Controls.Add(this.backNavigatorControl1);
            this.Controls.Add(this.localizationControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "PasswordResetView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PasswordResetView";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PasswordResetView_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Controls.BackNavigatorControl backNavigatorControl1;
        private Controls.LocalizationControl localizationControl1;
        private System.Windows.Forms.Label lblResetPassword;
        private System.Windows.Forms.Label lblConfirmPassword;
        private System.Windows.Forms.TextBox tbConfirmPassword;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.Button btnResetPassword;
        private System.Windows.Forms.Label lblPasswordRequirements;
    }
}
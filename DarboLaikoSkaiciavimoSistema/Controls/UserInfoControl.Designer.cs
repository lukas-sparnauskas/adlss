namespace DarboLaikoSkaiciavimoSistema.Controls
{
    partial class UserInfoControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblAccessLevel = new System.Windows.Forms.Label();
            this.lblNameSurname = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblAccessLevel
            // 
            this.lblAccessLevel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAccessLevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAccessLevel.Location = new System.Drawing.Point(3, 4);
            this.lblAccessLevel.Name = "lblAccessLevel";
            this.lblAccessLevel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblAccessLevel.Size = new System.Drawing.Size(280, 15);
            this.lblAccessLevel.TabIndex = 0;
            this.lblAccessLevel.Text = "label1";
            this.lblAccessLevel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblNameSurname
            // 
            this.lblNameSurname.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNameSurname.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNameSurname.Location = new System.Drawing.Point(3, 19);
            this.lblNameSurname.Name = "lblNameSurname";
            this.lblNameSurname.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblNameSurname.Size = new System.Drawing.Size(279, 25);
            this.lblNameSurname.TabIndex = 1;
            this.lblNameSurname.Text = "label2";
            this.lblNameSurname.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // UserInfoControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblNameSurname);
            this.Controls.Add(this.lblAccessLevel);
            this.Name = "UserInfoControl";
            this.Size = new System.Drawing.Size(285, 44);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblAccessLevel;
        private System.Windows.Forms.Label lblNameSurname;
    }
}

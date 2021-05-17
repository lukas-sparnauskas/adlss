namespace DarboLaikoSkaiciavimoSistema.Controls
{
    partial class LocalizationControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LocalizationControl));
            this.btnLithuanian = new System.Windows.Forms.Button();
            this.btnEnglish = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnLithuanian
            // 
            this.btnLithuanian.Image = ((System.Drawing.Image)(resources.GetObject("btnLithuanian.Image")));
            this.btnLithuanian.Location = new System.Drawing.Point(4, 4);
            this.btnLithuanian.Name = "btnLithuanian";
            this.btnLithuanian.Size = new System.Drawing.Size(47, 37);
            this.btnLithuanian.TabIndex = 0;
            this.btnLithuanian.UseVisualStyleBackColor = true;
            this.btnLithuanian.Click += new System.EventHandler(this.btnLithuanian_Click);
            // 
            // btnEnglish
            // 
            this.btnEnglish.Image = ((System.Drawing.Image)(resources.GetObject("btnEnglish.Image")));
            this.btnEnglish.Location = new System.Drawing.Point(58, 4);
            this.btnEnglish.Name = "btnEnglish";
            this.btnEnglish.Size = new System.Drawing.Size(47, 37);
            this.btnEnglish.TabIndex = 1;
            this.btnEnglish.UseVisualStyleBackColor = true;
            this.btnEnglish.Click += new System.EventHandler(this.btnEnglish_Click);
            // 
            // LocalizationControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnEnglish);
            this.Controls.Add(this.btnLithuanian);
            this.Name = "LocalizationControl";
            this.Size = new System.Drawing.Size(110, 45);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnLithuanian;
        private System.Windows.Forms.Button btnEnglish;
    }
}

using System.IO;

namespace DarboLaikoSkaiciavimoSistema.Views
{
    partial class VideoView
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
            this.userInfoControl1 = new DarboLaikoSkaiciavimoSistema.Controls.UserInfoControl();
            this.backNavigatorControl1 = new DarboLaikoSkaiciavimoSistema.Controls.BackNavigatorControl();
            this.pbVideo = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblVideo = new System.Windows.Forms.Label();
            this.vlcControl = new Vlc.DotNet.Forms.VlcControl();
            ((System.ComponentModel.ISupportInitialize)(this.pbVideo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vlcControl)).BeginInit();
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
            this.userInfoControl1.Location = new System.Drawing.Point(1008, 12);
            this.userInfoControl1.Name = "userInfoControl1";
            this.userInfoControl1.Size = new System.Drawing.Size(285, 44);
            this.userInfoControl1.TabIndex = 1;
            // 
            // backNavigatorControl1
            // 
            this.backNavigatorControl1.Location = new System.Drawing.Point(12, 805);
            this.backNavigatorControl1.Name = "backNavigatorControl1";
            this.backNavigatorControl1.Size = new System.Drawing.Size(143, 45);
            this.backNavigatorControl1.TabIndex = 2;
            // 
            // pbVideo
            // 
            this.pbVideo.Location = new System.Drawing.Point(12, 79);
            this.pbVideo.Name = "pbVideo";
            this.pbVideo.Size = new System.Drawing.Size(1280, 720);
            this.pbVideo.TabIndex = 3;
            this.pbVideo.TabStop = false;
            this.pbVideo.Visible = false;
            // 
            // lblVideo
            // 
            this.lblVideo.AutoSize = true;
            this.lblVideo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVideo.Location = new System.Drawing.Point(12, 60);
            this.lblVideo.Name = "lblVideo";
            this.lblVideo.Size = new System.Drawing.Size(51, 16);
            this.lblVideo.TabIndex = 7;
            this.lblVideo.Text = "label1";
            // 
            // vlcControl
            // 
            this.vlcControl.BackColor = System.Drawing.Color.Black;
            this.vlcControl.Location = new System.Drawing.Point(15, 80);
            this.vlcControl.Name = "vlcControl";
            this.vlcControl.Size = new System.Drawing.Size(1279, 719);
            this.vlcControl.Spu = -1;
            this.vlcControl.TabIndex = 8;
            this.vlcControl.Text = "vlcControl1";
            this.vlcControl.VlcLibDirectory = new DirectoryInfo(Directory.GetCurrentDirectory() + @"\libvlc\win-x64");
            this.vlcControl.VlcMediaplayerOptions = new[] { "-vv" }; ;
            // 
            // VideoView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1306, 858);
            this.Controls.Add(this.vlcControl);
            this.Controls.Add(this.lblVideo);
            this.Controls.Add(this.pbVideo);
            this.Controls.Add(this.backNavigatorControl1);
            this.Controls.Add(this.userInfoControl1);
            this.Controls.Add(this.localizationControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "VideoView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VideoView";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.VideoView_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.pbVideo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vlcControl)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controls.LocalizationControl localizationControl1;
        private Controls.UserInfoControl userInfoControl1;
        private Controls.BackNavigatorControl backNavigatorControl1;
        private System.Windows.Forms.PictureBox pbVideo;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblVideo;
        private Vlc.DotNet.Forms.VlcControl vlcControl;
    }
}
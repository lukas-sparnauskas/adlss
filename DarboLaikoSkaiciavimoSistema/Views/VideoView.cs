using DarboLaikoSkaiciavimoSistema.Controls;
using System;
using System.Windows.Forms;
using DarboLaikoSkaiciavimoSistema.Controllers;

namespace DarboLaikoSkaiciavimoSistema.Views
{
    /// <summary>
    /// Vaizdo medžiagos peržiūros lango klasė.
    /// </summary>
    public partial class VideoView : FormLocalized
    {
        VideoMode _mode;
        int _channel;
        DateTime? _startTime;
        DateTime? _endTime;

        /// <summary>
        /// Vaizdo medžiagos peržiūros lango klasės konstruktorius.
        /// </summary>
        /// <param name="mode">Vaizdo medžiagos gavimo rėžimas</param>
        /// <param name="channel">Kameros ID</param>
        /// <param name="startTime">Vaizdo įrašo pradžios laikas</param>
        /// <param name="endTime">Vaizdo įrašo pabaigos laikas</param>
        public VideoView(VideoMode mode, int channel, DateTime? startTime = null, DateTime? endTime = null)
        {
            _mode = mode;
            _channel = channel;
            _startTime = startTime;
            _endTime = endTime;
            InitializeComponent();
            SetLocalization();

            VideoController.PlayVideo(vlcControl, _mode, channel, startTime, endTime);
        }

        /// <summary>
        /// Vaizdo medžiagos peržiūros lango teksto nustatymas.
        /// </summary>
        public override void SetLocalization()
        {
            backNavigatorControl1.Refresh();
            userInfoControl1.Refresh();
            switch (_mode)
            {
                case VideoMode.Stream:
                    this.Text = lblVideo.Text = string.Format(Properties.Strings.videoViewStreamName, _channel);
                    break;
                case VideoMode.Recording:
                    this.Text = lblVideo.Text = string.Format(Properties.Strings.videoViewRecordingName, _channel, _startTime.ToString(), _endTime.ToString());
                    break;
            }
        }

        /// <summary>
        /// Vaizdo medžiagos peržiūros lango uždarymo apdorojimas.
        /// </summary>
        private void VideoView_FormClosed(object sender, FormClosedEventArgs e)
        {
            vlcControl.Stop();
            if (((VideoView)sender).ActiveControl is BackNavigatorControl) return;
            Application.Exit();
        }
    }
}

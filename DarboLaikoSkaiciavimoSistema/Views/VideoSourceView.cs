using DarboLaikoSkaiciavimoSistema.Controls;
using System;
using System.Windows.Forms;

namespace DarboLaikoSkaiciavimoSistema.Views
{
    /// <summary>
    /// Vaizdo medžiagos šaltinio pasirinkimo lango klasė.
    /// </summary>
    public partial class VideoSourceView : FormLocalized
    {
        VideoMode _mode;
        Timer _timer = new Timer();

        /// <summary>
        /// Vaizdo medžiagos šaltinio pasirinkimo lango klasės konstruktorius.
        /// </summary>
        /// <param name="mode">Vaizdo medžiagos gavimo rėžimas</param>
        public VideoSourceView(VideoMode mode)
        {
            _mode = mode;
            InitializeComponent();
            SetLocalization();
            SetFields();
            _timer.Tick += new EventHandler(this.onTimerTick);
            _timer.Interval = 1000;
            _timer.Start();
        }

        /// <summary>
        /// Vaizdo medžiagos šaltinio pasirinkimo lango laukelių nustatymas.
        /// </summary>
        private void SetFields()
        {
            switch (_mode)
            {
                case VideoMode.Stream:
                    lblStartTime.Visible = lblEndTime.Visible = dtStartTime.Visible = dtEndTime.Visible = false;
                    break;
                case VideoMode.Recording:
                    dtStartTime.MaxDate = dtEndTime.MaxDate = DateTime.Now;
                    lblStartTime.Visible = lblEndTime.Visible = dtStartTime.Visible = dtEndTime.Visible = true;
                    break;
            }
        }

        /// <summary>
        /// Vaizdo medžiagos šaltinio pasirinkimo lango teksto nustatymas.
        /// </summary>
        public override void SetLocalization()
        {
            backNavigatorControl1.Refresh();
            userInfoControl1.Refresh();
            this.Text = lblVideoSource.Text = Properties.Strings.videoSourceViewName;
            lblChannel.Text = Properties.Strings.lblChannel;
            lblStartTime.Text = Properties.Strings.lblStartTime;
            lblEndTime.Text = Properties.Strings.lblEndTime;
            btnSelect.Text = Properties.Strings.btnSelect;
        }

        /// <summary>
        /// Mygtuko 'Pasirinkti' paspaudimo apdorojimas.
        /// </summary>
        private void btnSelect_Click(object sender, EventArgs e) 
        {
            switch (_mode)
            {
                case VideoMode.Stream:
                    this.Hide();
                    VideoView videoViewStream = new VideoView(VideoMode.Stream, (int)numChannel.Value);
                    videoViewStream.ShowDialog(this);
                    videoViewStream.Dispose();
                    break;
                case VideoMode.Recording:
                    if (dtStartTime.Value >= dtEndTime.Value)
                    {
                        MessageBox.Show(Properties.Strings.errTime, Properties.Strings.errTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    } 
                    this.Hide();
                    VideoView videoViewRec = new VideoView(VideoMode.Recording, (int)numChannel.Value, dtStartTime.Value, dtEndTime.Value);
                    videoViewRec.ShowDialog(this);
                    videoViewRec.Dispose();
                    break;
            }
        }

        /// <summary>
        /// Maksimalaus vaizdo įrašo pradžios ir pabaigos laiko atnaujinimą atliekančio laikmačio sutiksėjimo apdorojimas.
        /// </summary>
        private void onTimerTick(object sender, EventArgs e)
        {
            dtStartTime.MaxDate = dtEndTime.MaxDate = DateTime.Now;
        }

        /// <summary>
        /// Vaizdo medžiagos šaltinio pasirinkimo lango uždarymo apdorojimas.
        /// </summary>
        private void VideoSourceView_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (((VideoSourceView)sender).ActiveControl is BackNavigatorControl) return;
            Application.Exit();
        }
    }
}

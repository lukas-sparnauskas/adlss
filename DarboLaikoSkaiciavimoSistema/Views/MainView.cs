using DarboLaikoSkaiciavimoSistema.Cache;
using DarboLaikoSkaiciavimoSistema.Controllers;
using DarboLaikoSkaiciavimoSistema.Models;
using System;
using System.Windows.Forms;

namespace DarboLaikoSkaiciavimoSistema.Views
{
    /// <summary>
    /// Pagrindinio lango klasė.
    /// </summary>
    public partial class MainView : FormLocalized
    {
        TimeSpan? _remainingWorkingTimeToday = null;

        /// <summary>
        /// Pagrindinio lango klasės konstruktorius.
        /// </summary>
        public MainView()
        {
            InitializeComponent();
            SetLocalization();
            SetPermissions();
            RefreshWorkingTime();
            timerRemainingWorktimeToday.Start();
        }

        /// <summary>
        /// Pagrindinio lango teksto nustatymas.
        /// </summary>
        public override void SetLocalization()
        {
            userInfoControl1.Refresh();
            this.Text = Properties.Strings.mainViewName;
            btnStatistics.Text = Properties.Strings.btnStatistics;
            btnRegisterUser.Text = Properties.Strings.btnRegisterUser;
            btnUsers.Text = Properties.Strings.btnUsers;
            btnRecordings.Text = Properties.Strings.btnRecordings;
            btnLiveFeed.Text = Properties.Strings.btnLiveFeed;
            btnSettings.Text = Properties.Strings.btnSettings;
            btnLogout.Text = Properties.Strings.btnLogout;
            lblRemainingTimeLabel.Text = Properties.Strings.lblRemainingTimeTodayLabel;
        }

        /// <summary>
        /// Pagrindinio lango mygtukų matomumo nustatymas pagal naudotojo rolę.
        /// </summary>
        private void SetPermissions()
        {
            User user = UserController.GetUserByID(LocalCache.GetLastUserId());
            switch (user.access_level)
            {
                case (int)AccessLevelEN.Employee:
                    btnRegisterUser.Visible = false;
                    btnUsers.Visible = false;
                    btnRecordings.Visible = false;
                    btnLiveFeed.Visible = false;
                    goto case (int)AccessLevelEN.Manager;
                case (int)AccessLevelEN.Manager:
                    btnSettings.Visible = false;
                    break;
            }
        }

        /// <summary>
        /// Darbo laiko statistikos mygtuko paspaudimo apdorojimas.
        /// </summary>
        private void btnStatistics_Click(object sender, EventArgs e)
        {
            this.Hide();
            StatisticsView statView = new StatisticsView();
            statView.ShowDialog(this);
            statView.Dispose();
        }

        /// <summary>
        /// Naudotojų sąrašo mygtuko paspaudimo apdorojimas.
        /// </summary>
        private void btnUsers_Click(object sender, EventArgs e)
        {
            this.Hide();
            UserListView userListView = new UserListView();
            userListView.ShowDialog(this);
            userListView.Dispose();
        }

        /// <summary>
        /// Vaizdo įrašų peržiūros mygtuko paspaudimo apdorojimas.
        /// </summary>
        private void btnRecordings_Click(object sender, EventArgs e)
        {
            this.Hide();
            VideoSourceView videoSourceView = new VideoSourceView(VideoMode.Recording);
            videoSourceView.ShowDialog(this);
            videoSourceView.Dispose();
        }

        /// <summary>
        /// Tiesioginio vaizdo peržiūros mygtuko paspaudimo apdorojimas.
        /// </summary>
        private void btnLiveFeed_Click(object sender, EventArgs e)
        {
            this.Hide();
            VideoSourceView videoSourceView = new VideoSourceView(VideoMode.Stream);
            videoSourceView.ShowDialog(this);
            videoSourceView.Dispose();
        }

        /// <summary>
        /// Sistemo nustatymų mygtuko paspaudimo apdorojimas.
        /// </summary>
        private void btnSettings_Click(object sender, EventArgs e)
        {
            this.Hide();
            SettingsView settingsView = new SettingsView();
            settingsView.ShowDialog(this);
            settingsView.Dispose();
        }

        /// <summary>
        /// Atsijungimo mygtuko paspaudimo apdorojimas.
        /// </summary>
        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(Properties.Strings.warningLogout, Properties.Strings.warningTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No) return;
            this.Hide();
            LocalCache.SaveUserId(-1);
            new LoginView().ShowDialog();
            this.Close();
        }

        /// <summary>
        /// Pagrindinio lango uždarymo apdorojimas.
        /// </summary>
        private void MainView_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Darbuotojo registracijos mygtuko paspaudimo apdorojimas.
        /// </summary>
        private void btnRegisterUser_Click(object sender, EventArgs e)
        {
            this.Hide();
            UserRegistrationView userRegistrationView = new UserRegistrationView();
            userRegistrationView.ShowDialog(this);
            userRegistrationView.Dispose();
        }
        
        /// <summary>
        /// Likusio darbo laiko šiandien apskaičiavimo laikmačio sutiksėjimo apdorojimas.
        /// </summary>
        private void timerRemainingWorktimeToday_Tick_1(object sender, EventArgs e)
        {
            RefreshWorkingTime();
        }

        /// <summary>
        /// Likusio darbo laiko šiandien atnaujinimas.
        /// </summary>
        private void RefreshWorkingTime()
        {
            _remainingWorkingTimeToday = WorkingTimeController.RemainingWorktimeToday(_remainingWorkingTimeToday);
            if (_remainingWorkingTimeToday == TimeSpan.MaxValue) lblRemainingTime.Text = Properties.Strings.errDatabase;
            else lblRemainingTime.Text = _remainingWorkingTimeToday > new TimeSpan(0) ? WorktimeFormat(_remainingWorkingTimeToday.Value) : new TimeSpan(0).ToString();
        }

        /// <summary>
        /// Darbo laiko atvaizdavimo formatavimas.
        /// </summary>
        /// <param name="worktime">Darbo laikas</param>
        /// <returns>Formatuotas, atvaizdavimui pritaikytas, darbo laikas.</returns>
        private string WorktimeFormat(TimeSpan worktime)
        {
            return worktime.Days * 24 + worktime.Hours + ":" + worktime.Minutes.ToString("D2") + ":" + worktime.Seconds.ToString("D2");
        }
    }
}

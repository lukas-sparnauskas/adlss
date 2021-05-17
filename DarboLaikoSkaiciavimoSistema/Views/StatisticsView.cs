using DarboLaikoSkaiciavimoSistema.Controllers;
using DarboLaikoSkaiciavimoSistema.Controls;
using System;
using System.Windows.Forms;

namespace DarboLaikoSkaiciavimoSistema.Views
{
    /// <summary>
    /// Darbo laiko statistikos lango klasė.
    /// </summary>
    public partial class StatisticsView : FormLocalized
    {
        TimeSpan? _remainingWorkingTimeToday = null;
        TimeSpan? _remainingWorkingTimeWeek = null;
        TimeSpan? _remainingWorkingTimeMonth = null;
        TimeSpan? _extraTimeMonth = null;

        /// <summary>
        /// Darbo laiko statistikos lango klasės konstruktorius.
        /// </summary>
        public StatisticsView()
        {
            InitializeComponent();
            SetLocalization();
            RefreshWorkingTime();
            timerStatistics.Start();
        }

        /// <summary>
        /// Darbo laiko statistikos lango teksto nustatymas.
        /// </summary>
        public override void SetLocalization()
        {
            backNavigatorControl1.Refresh();
            userInfoControl1.Refresh();
            this.Text = lblStatisticsLabel.Text = Properties.Strings.statisticsViewName;
            lblRemainingTimeTodayLabel.Text = Properties.Strings.lblRemainingTimeTodayLabel;
            lblRemainingTimeWeekLabel.Text = Properties.Strings.lblRemainingTimeWeekLabel;
            lblRemainingTimeMonthLabel.Text = Properties.Strings.lblRemainingTimeMonthLabel;
            lblExtraTimeMonthLabel.Text = Properties.Strings.lblExtraTimeMonthLabel;
        }

        /// <summary>
        /// Darbo laiko statistikos atnaujinimas.
        /// </summary>
        private void RefreshWorkingTime()
        {
            _remainingWorkingTimeToday = WorkingTimeController.RemainingWorktimeToday(_remainingWorkingTimeToday);

            if (_remainingWorkingTimeToday == TimeSpan.MaxValue)
            {
                lblRemainingTimeToday.Text = lblRemainingTimeMonth.Text = lblRemainingTimeWeek.Text = lblExtraTimeMonth.Text = Properties.Strings.errDatabase;
                return;
            }

            _remainingWorkingTimeWeek = WorkingTimeController.RemainingWorktimeWeek(_remainingWorkingTimeWeek);
            _remainingWorkingTimeMonth = WorkingTimeController.RemainingWorktimeMonth(_remainingWorkingTimeMonth);
            _extraTimeMonth = _remainingWorkingTimeMonth < new TimeSpan(0) ? -_remainingWorkingTimeMonth : new TimeSpan(0);

            lblRemainingTimeToday.Text = _remainingWorkingTimeToday > new TimeSpan(0) ? WorktimeFormat(_remainingWorkingTimeToday.Value) : new TimeSpan(0).ToString();
            lblRemainingTimeWeek.Text = _remainingWorkingTimeWeek > new TimeSpan(0) ? WorktimeFormat(_remainingWorkingTimeWeek.Value) : new TimeSpan(0).ToString();
            lblRemainingTimeMonth.Text = _remainingWorkingTimeMonth > new TimeSpan(0) ? WorktimeFormat(_remainingWorkingTimeMonth.Value) : new TimeSpan(0).ToString();
            lblExtraTimeMonth.Text = WorktimeFormat(_extraTimeMonth.Value);
        }

        /// <summary>
        /// Darbo laiko statistikos atnaujinimo laikmačio sutiksėjimo apdorojimas.
        /// </summary>
        private void timerStatistics_Tick(object sender, EventArgs e)
        {
            RefreshWorkingTime();
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

        /// <summary>
        /// Darbo laiko statistikos lango uždarymo apdorojimas.
        /// </summary>
        private void StatisticsView_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (((StatisticsView)sender).ActiveControl is BackNavigatorControl) return;
            Application.Exit();
        }
    }
}

using DarboLaikoSkaiciavimoSistema.Controllers;
using DarboLaikoSkaiciavimoSistema.Controls;
using DarboLaikoSkaiciavimoSistema.Models;
using System;
using System.Windows.Forms;

namespace DarboLaikoSkaiciavimoSistema.Views
{
    /// <summary>
    /// Sistemos nustatymų lango klasė.
    /// </summary>
    public partial class SettingsView : FormLocalized
    {
        Settings _settings;

        /// <summary>
        /// Sistemos nustatymų lango klasės konstruktorius.
        /// </summary>
        public SettingsView()
        {
            InitializeComponent();
            SetLocalization();

            _settings = SettingsController.GetSettings();
            SetFieldValues();
        }

        /// <summary>
        /// Sistemos nustatymų lango teksto nustatymas.
        /// </summary>
        public override void SetLocalization()
        {
            backNavigatorControl1.Refresh();
            userInfoControl1.Refresh();
            this.Text = lblSettingsLabel.Text = Properties.Strings.settingsViewName;
            lblNVRIP.Text = Properties.Strings.lblNVRIP;
            lblNVRPort.Text = Properties.Strings.lblNVRPort;
            lblNVRUsername.Text = Properties.Strings.lblNVRUsername;
            lblNVRPassword.Text = Properties.Strings.lblNVRPassword;
            lblAccessControllerIP.Text = Properties.Strings.lblAccessControllerIP;
            lblAccessControllerPort.Text = Properties.Strings.lblAccessControllerPort;
            lblAccessControllerUsername.Text = Properties.Strings.lblAccessControllerUsername;
            lblAccessControllerPassword.Text = Properties.Strings.lblAccessControllerPassword;
            btnSave.Text = Properties.Strings.btnSave;
        }

        /// <summary>
        /// Išsaugojimo mygtuko paspaudimo apdorojimas.
        /// </summary>
        private void btnSave_Click(object sender, EventArgs e)
        {
            btnSave.Enabled = false;
            if (!CheckForEmptyFields())
            {
                MessageBox.Show(Properties.Strings.errEmptyFields, Properties.Strings.errTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSave.Enabled = true;
                return;
            }

            Settings newSettings = new Settings()
            {
                NVRIP = tbNVRIP.Text.Trim(),
                NVRPort = (int)numNVRPort.Value,
                NVRUsername = tbNVRUsername.Text,
                NVRPassword = tbNVRPassword.Text,
                AccessControllerIP = tbAccessControllerIP.Text.Trim(),
                AccessControllerPort = (int)numAccessControllerPort.Value,
                AccessControllerUsername = tbAccessControllerUsername.Text,
                AccessControllerPassword = tbAccessControllerPassword.Text
            };

            SettingsController.SaveSettings(newSettings);
            btnSave.Enabled = true;
            MessageBox.Show(Properties.Strings.infoSettingsSaved, Properties.Strings.infoTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            backNavigatorControl1.PerformClick();
        }

        /// <summary>
        /// Patikrinimas, ar visi duomenys įvesti.
        /// </summary>
        /// <returns>True - visi duomenys įvesti, false - ne visi duomenys įvesti.</returns>
        private bool CheckForEmptyFields()
        {
            return tbNVRIP.Text.Length > 0 && tbNVRUsername.Text.Length > 0 && tbNVRPassword.Text.Length > 0 && 
                tbAccessControllerIP.Text.Length > 0 && tbAccessControllerUsername.Text.Length > 0 && tbAccessControllerPassword.Text.Length > 0;
        }

        /// <summary>
        /// Sistemos nustatymų laukelių užpildymas esamais duomenimis.
        /// </summary>
        private void SetFieldValues()
        {
            tbNVRIP.Text = _settings.NVRIP;
            numNVRPort.Value = _settings.NVRPort != null ? (decimal)_settings.NVRPort : 0;
            tbNVRUsername.Text = _settings.NVRUsername;
            tbNVRPassword.Text = _settings.NVRPassword;
            tbAccessControllerIP.Text = _settings.AccessControllerIP;
            numAccessControllerPort.Value = _settings.AccessControllerPort != null ? (decimal)_settings.AccessControllerPort : 0;
            tbAccessControllerUsername.Text = _settings.AccessControllerUsername;
            tbAccessControllerPassword.Text = _settings.AccessControllerPassword;
        }

        /// <summary>
        /// Sistemos nustatymų lango uždarymo apdorojimas.
        /// </summary>
        private void SettingsView_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (((SettingsView)sender).ActiveControl is BackNavigatorControl) return;
            Application.Exit();
        }
    }
}

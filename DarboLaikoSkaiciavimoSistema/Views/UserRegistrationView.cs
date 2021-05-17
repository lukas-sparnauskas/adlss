using DarboLaikoSkaiciavimoSistema.Cache;
using DarboLaikoSkaiciavimoSistema.Controllers;
using DarboLaikoSkaiciavimoSistema.Controls;
using DarboLaikoSkaiciavimoSistema.Models;
using System;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;

namespace DarboLaikoSkaiciavimoSistema.Views
{
    /// <summary>
    /// Naudotojo registracijos lango klasė.
    /// </summary>
    public partial class UserRegistrationView : FormLocalized
    {
        /// <summary>
        /// Naudotojo registracijos lango klasės konstruktorius.
        /// </summary>
        public UserRegistrationView()
        {
            InitializeComponent();
            SetLocalization();
            SetAvailableAccessLevels();
        }

        /// <summary>
        /// Naudotojo registracijos lango teksto nustatymas.
        /// </summary>
        public override void SetLocalization()
        {
            backNavigatorControl1.Refresh();
            userInfoControl1.Refresh();
            this.Text = lblUserRegistrationLabel.Text = Properties.Strings.userRegistrationViewName;
            lblName.Text = Properties.Strings.lblName;
            lblSurname.Text = Properties.Strings.lblSurname;
            lblUsername.Text = Properties.Strings.lblUsername;
            lblPassword.Text = Properties.Strings.lblPassword;
            lblConfirmPassword.Text = Properties.Strings.lblConfirmPassword;
            lblEmail.Text = Properties.Strings.lblEmail;
            lblAccessLevel.Text = Properties.Strings.lblAccessLevel;
            lblCardNumber.Text = Properties.Strings.lblCardNumber;
            lblWorkHoursPerWeek.Text = Properties.Strings.lblWorkHoursPerWeek;
            lblPasswordRequirements.Text = Properties.Strings.lblPasswordRequirements;
            btnRegister.Text = Properties.Strings.btnRegister;
        }

        /// <summary>
        /// Registracijos mygtuko paspaudimo apdorojimas.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRegister_Click(object sender, EventArgs e)
        {
            btnRegister.Enabled = false;
            if (!CheckForEmptyFields())
            {
                MessageBox.Show(Properties.Strings.errEmptyFields, Properties.Strings.errTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnRegister.Enabled = true;
                return;
            }
            if (!UserController.CheckEmail(tbEmail.Text))
            {
                MessageBox.Show(Properties.Strings.errInvalidEmail, Properties.Strings.errTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnRegister.Enabled = true;
                return;
            }
            if (UserController.UsernameExists(tbUsername.Text))
            {
                MessageBox.Show(Properties.Strings.errUsernameTaken, Properties.Strings.errTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnRegister.Enabled = true;
                return;
            }
            if (UserController.CardIdIsTaken(tbCardNumber.Text))
            {
                MessageBox.Show(Properties.Strings.errCardIdTaken, Properties.Strings.errTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnRegister.Enabled = true;
                return;
            }
            if (tbPassword.Text != tbConfirmPassword.Text)
            {
                MessageBox.Show(Properties.Strings.errPasswordsDoNotMatch, Properties.Strings.errTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnRegister.Enabled = true;
                return;
            }
            if (!UserController.CheckPassword(tbPassword.Text))
            {
                MessageBox.Show(Properties.Strings.errPasswordTooWeak, Properties.Strings.errTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnRegister.Enabled = true;
                return;
            }

            User user = new User()
            {
                name = tbName.Text,
                surname = tbSurname.Text,
                username = tbUsername.Text,
                password = tbPassword.Text,
                email = tbEmail.Text,
                card_id = tbCardNumber.Text,
                access_level = cbAccessLevel.SelectedIndex,
                work_hours_in_week = (int)numWorkHoursPerWeek.Value
            };
            
            bool register = UserController.RegisterUser(user);
            btnRegister.Enabled = true;
            if (!register)
            {
                MessageBox.Show(Properties.Strings.errAccessController, Properties.Strings.errTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show(Properties.Strings.infoUserRegistered, Properties.Strings.infoTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.backNavigatorControl1.PerformClick();
        }

        /// <summary>
        /// Galimų rolių pasirinkimo nustatymas rolės pasirinkimo laukelyje.
        /// </summary>
        private void SetAvailableAccessLevels()
        {
            User user = UserController.GetUserByID(LocalCache.GetLastUserId());
            switch (user.access_level)
            {
                case (int)AccessLevelEN.Manager:
                    if (Thread.CurrentThread.CurrentUICulture == CultureInfo.GetCultureInfo("lt-LT"))
                    {
                        cbAccessLevel.Items.Add(AccessLevelLT.Darbuotojas);
                        cbAccessLevel.Items.Add(AccessLevelLT.Vadovas);
                    }
                    else
                    {
                        cbAccessLevel.Items.Add(AccessLevelEN.Employee);
                        cbAccessLevel.Items.Add(AccessLevelEN.Manager);
                    }
                    break;
                case (int)AccessLevelEN.Administrator:
                    if (Thread.CurrentThread.CurrentUICulture == CultureInfo.GetCultureInfo("lt-LT"))
                    {
                        cbAccessLevel.Items.Add(AccessLevelLT.Darbuotojas);
                        cbAccessLevel.Items.Add(AccessLevelLT.Vadovas);
                        cbAccessLevel.Items.Add(AccessLevelLT.Administratorius);
                    }
                    else
                    {
                        cbAccessLevel.Items.Add(AccessLevelEN.Employee);
                        cbAccessLevel.Items.Add(AccessLevelEN.Manager);
                        cbAccessLevel.Items.Add(AccessLevelEN.Administrator);
                    }
                    break;
            }
        }

        /// <summary>
        /// Patikrinimas, ar visi duomenys įvesti.
        /// </summary>
        /// <returns>True - visi duomenys įvesti, false - ne visi duomenys įvesti.</returns>
        private bool CheckForEmptyFields()
        {
            return tbName.Text.Length > 0 && tbSurname.Text.Length > 0 && tbUsername.Text.Length > 0
                && tbPassword.Text.Length > 0 && tbConfirmPassword.Text.Length > 0 && tbEmail.Text.Length > 0
                && tbCardNumber.Text.Length > 0 && cbAccessLevel.SelectedIndex  != -1;
        }

        /// <summary>
        /// Naudotojo registracijos lango uždarymo apdorojimas.
        /// </summary>
        private void UserRegistrationView_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (((UserRegistrationView)sender).ActiveControl is BackNavigatorControl) return;
            Application.Exit();
        }
    }
}

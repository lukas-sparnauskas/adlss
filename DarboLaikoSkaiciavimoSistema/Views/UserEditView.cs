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
    /// Naudotojo duomenų keitimo lango klasė.
    /// </summary>
    public partial class UserEditView : FormLocalized
    {
        User _user;

        /// <summary>
        /// Naudotojo duomenų keitimo lango klasės konstruktorius.
        /// </summary>
        /// <param name="user">Naudotojas, kurio duomenys keičiami</param>
        public UserEditView(User user)
        {
            InitializeComponent();
            SetLocalization();
            SetAvailableAccessLevels();

            _user = user;
            SetFieldValues();
        }

        /// <summary>
        /// Naudotojo duomenų keitimo lango teksto nustatymas.
        /// </summary>
        public override void SetLocalization()
        {
            backNavigatorControl1.Refresh();
            userInfoControl1.Refresh();
            this.Text = lblUserEditLabel.Text = Properties.Strings.userEditViewName;
            lblName.Text = Properties.Strings.lblName;
            lblSurname.Text = Properties.Strings.lblSurname;
            lblUsername.Text = Properties.Strings.lblUsername;
            lblNewPassword.Text = Properties.Strings.lblNewPassword;
            lblConfirmNewPassword.Text = Properties.Strings.lblConfirmNewPassword;
            lblEmail.Text = Properties.Strings.lblEmail;
            lblAccessLevel.Text = Properties.Strings.lblAccessLevel;
            lblCardNumber.Text = Properties.Strings.lblCardNumber;
            lblWorkHoursPerWeek.Text = Properties.Strings.lblWorkHoursPerWeek;
            lblPasswordRequirements.Text = Properties.Strings.lblPasswordRequirements;
            btnSave.Text = Properties.Strings.btnSave;
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
        /// Naudotojo duomenų keitimo lango uždarymo apdorojimas.
        /// </summary>
        private void UserEditView_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (((UserEditView)sender).ActiveControl is BackNavigatorControl) return;
            Application.Exit();
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
            if (!UserController.CheckEmail(tbEmail.Text))
            {
                MessageBox.Show(Properties.Strings.errInvalidEmail, Properties.Strings.errTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSave.Enabled = true;
                return;
            }
            if (!_user.card_id.Equals(tbCardNumber.Text) && UserController.CardIdIsTaken(tbCardNumber.Text))
            {
                MessageBox.Show(Properties.Strings.errCardIdTaken, Properties.Strings.errTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSave.Enabled = true;
                return;
            }
            if (NewPasswordIsEntered() && tbNewPassword.Text != tbConfirmNewPassword.Text)
            {
                MessageBox.Show(Properties.Strings.errPasswordsDoNotMatch, Properties.Strings.errTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSave.Enabled = true;
                return;
            }
            if (NewPasswordIsEntered() && !UserController.CheckPassword(tbNewPassword.Text))
            {
                MessageBox.Show(Properties.Strings.errPasswordTooWeak, Properties.Strings.errTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSave.Enabled = true;
                return;
            }

            if (MessageBox.Show(Properties.Strings.warningEditUser, Properties.Strings.warningTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No) return;

            User user = new User()
            {
                id = _user.id,
                name = tbName.Text,
                surname = tbSurname.Text,
                username = tbUsername.Text,
                password = NewPasswordIsEntered() ? tbNewPassword.Text : _user.password,
                email = tbEmail.Text,
                card_id = tbCardNumber.Text,
                access_level = cbAccessLevel.SelectedIndex,
                work_hours_in_week = (int)numWorkHoursPerWeek.Value
            };

            bool update = UserController.UpdateUser(user, this.Handle);
            btnSave.Enabled = true;
            if (!update)
            {
                MessageBox.Show(Properties.Strings.errAccessController, Properties.Strings.errTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            this.Owner.Refresh();
            backNavigatorControl1.PerformClick();
        }

        /// <summary>
        /// Patikrinimas, ar visi reikalingi duomenys įvesti.
        /// </summary>
        /// <returns>True - visi reikalingi duomenys įvesti, false - ne visi reikalingi duomenys įvesti.</returns>
        private bool CheckForEmptyFields()
        {
            return tbName.Text.Length > 0 && tbSurname.Text.Length > 0 && tbEmail.Text.Length > 0
                && tbCardNumber.Text.Length > 0 && cbAccessLevel.SelectedIndex >= 0;
        }

        /// <summary>
        /// Patikrinimas, ar įvestas naujas slaptažodis.
        /// </summary>
        /// <returns>True - įvestas naujas slaptažodis, false - neįvestas naujas slaptažodis.</returns>
        private bool NewPasswordIsEntered()
        {
            return tbNewPassword.Text.Length > 0;
        }

        /// <summary>
        /// Naudotojo duomenų laukelių užpildymas esamais duomenimis.
        /// </summary>
        private void SetFieldValues()
        {
            tbName.Text = _user.name;
            tbSurname.Text = _user.surname;
            tbUsername.Text = _user.username;
            tbEmail.Text = _user.email;
            tbCardNumber.Text = _user.card_id;
            cbAccessLevel.SelectedIndex = _user.access_level;
            numWorkHoursPerWeek.Value = _user.work_hours_in_week;
        }
    }
}

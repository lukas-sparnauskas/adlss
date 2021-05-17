using DarboLaikoSkaiciavimoSistema.Controllers;
using DarboLaikoSkaiciavimoSistema.Controls;
using DarboLaikoSkaiciavimoSistema.Models;
using System;
using System.Windows.Forms;

namespace DarboLaikoSkaiciavimoSistema.Views
{
    /// <summary>
    /// Slaptažodžio keitimo lango klasė.
    /// </summary>
    public partial class PasswordResetView : FormLocalized
    {
        User _user;

        /// <summary>
        /// Slaptažodžio keitimo lango klasės konstruktorius.
        /// </summary>
        /// <param name="user">Naudotojas, kurio slaptažodis keičiamas</param>
        public PasswordResetView(User user)
        {
            _user = user;
            InitializeComponent();
            SetLocalization();
        }

        /// <summary>
        /// Slaptažodžio keitimo lango teksto nustatymas.
        /// </summary>
        public override void SetLocalization()
        {
            this.backNavigatorControl1.Refresh();
            this.Text = lblResetPassword.Text = Properties.Strings.passwordResetViewName;
            lblPasswordRequirements.Text = Properties.Strings.lblPasswordRequirements;
            lblPassword.Text = Properties.Strings.lblPassword;
            lblConfirmPassword.Text = Properties.Strings.lblConfirmPassword;
            btnResetPassword.Text = Properties.Strings.btnSave;
        }

        /// <summary>
        /// Slaptažodžio pakeitimo mygtuko paspaudimo apdorojimas.
        /// </summary>
        private void btnResetPassword_Click(object sender, EventArgs e)
        {
            btnResetPassword.Enabled = false;
            if (!CheckForEmptyFields())
            {
                MessageBox.Show(Properties.Strings.errEmptyFields, Properties.Strings.errTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnResetPassword.Enabled = true;
                return;
            }
            if (tbPassword.Text != tbConfirmPassword.Text)
            {
                MessageBox.Show(Properties.Strings.errPasswordsDoNotMatch, Properties.Strings.errTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnResetPassword.Enabled = true;
                return;
            }
            if (!UserController.CheckPassword(tbPassword.Text))
            {
                MessageBox.Show(Properties.Strings.errPasswordTooWeak, Properties.Strings.errTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnResetPassword.Enabled = true;
                return;
            }

            UserController.UpdateUserPassword(_user.id, tbPassword.Text);
            btnResetPassword.Enabled = true;
            MessageBox.Show(Properties.Strings.infoPasswordChanged, Properties.Strings.infoTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.Close();
        }

        /// <summary>
        /// Patikrinimas, ar visi duomenys įvesti.
        /// </summary>
        /// <returns>True - visi duomenys įvesti, false - ne visi duomenys įvesti.</returns>
        private bool CheckForEmptyFields()
        {
            return tbPassword.Text.Length > 0 && tbConfirmPassword.Text.Length > 0;
        }

        /// <summary>
        /// Slaptažodžio keitimo lango uždarymo apdorojimas.
        /// </summary>
        private void PasswordResetView_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (((PasswordResetView)sender).ActiveControl is BackNavigatorControl) return;
            this.Owner.Close();
        }
    }
}

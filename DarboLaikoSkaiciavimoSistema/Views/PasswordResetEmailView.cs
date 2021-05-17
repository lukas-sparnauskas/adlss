using DarboLaikoSkaiciavimoSistema.Controllers;
using DarboLaikoSkaiciavimoSistema.Controls;
using DarboLaikoSkaiciavimoSistema.Models;
using System;
using System.Windows.Forms;

namespace DarboLaikoSkaiciavimoSistema.Views
{
    /// <summary>
    /// Slaptažodžio keitimui reikalingo el. pašto įvedimo lango klasė.
    /// </summary>
    public partial class PasswordResetEmailView : FormLocalized
    {
        User _user;
        string _resetCode;

        /// <summary>
        /// Slaptažodžio keitimui reikalingo el. pašto įvedimo lango klasės konstruktorius.
        /// </summary>
        public PasswordResetEmailView()
        {
            InitializeComponent();
            SetLocalization();
            btnCheckEmail.Enabled = false;
            lblResetCodeInfo.Visible = lblResetCode.Visible = tbResetCode.Visible = false;
        }

        /// <summary>
        /// Slaptažodžio keitimui reikalingo el. pašto įvedimo lango teksto nustatymas.
        /// </summary>
        public override void SetLocalization()
        {
            this.backNavigatorControl1.Refresh();
            this.Text = lblResetPassword.Text = Properties.Strings.passwordResetViewName;
            lblEmail.Text = Properties.Strings.lblEmail;
            lblResetCodeInfo.Text = Properties.Strings.lblResetCodeInfo;
            lblResetCode.Text = Properties.Strings.lblResetCode;
            btnCheckEmail.Text = Properties.Strings.btnResetPassword;
            btnSendCode.Text = Properties.Strings.btnSendCode;
        }

        /// <summary>
        /// El. pašto patikrinimo mygtuko paspaudimo apdorojimas.
        /// </summary>
        private void btnCheckEmail_Click(object sender, EventArgs e)
        {
            if (_resetCode != tbResetCode.Text.Trim())
            {
                MessageBox.Show(Properties.Strings.errResetCode, Properties.Strings.errTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnCheckEmail.Enabled = true;
                return;
            }

            this.Hide();
            PasswordResetView passwordResetView = new PasswordResetView(_user);
            passwordResetView.ShowDialog(this);
            passwordResetView.Dispose();
        }

        /// <summary>
        /// Slaptažodžio atkūrimo kodo siuntimo mygtuko paspaudimo apdorojimas.
        /// </summary>
        private void btnSendCode_Click(object sender, EventArgs e)
        {
            btnSendCode.Enabled = false;
            if (tbEmail.TextLength == 0)
            {
                MessageBox.Show(Properties.Strings.errEmptyFields, Properties.Strings.errTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSendCode.Enabled = true;
                return;
            }
            if (!UserController.CheckEmail(tbEmail.Text))
            {
                MessageBox.Show(Properties.Strings.errInvalidEmail, Properties.Strings.errTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSendCode.Enabled = true;
                return;
            }

            MessageBox.Show(Properties.Strings.infoCodeSent, Properties.Strings.infoTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnSendCode.Enabled = true;
            btnCheckEmail.Enabled = true;
            lblResetCodeInfo.Visible = lblResetCode.Visible = tbResetCode.Visible = true;

            User user = UserController.GetUserByEmail(tbEmail.Text.Trim());
            if (user != null && user.id > 0)
            {
                _resetCode = UserController.SendPasswordResetCode(tbEmail.Text.Trim());
                _user = user;
            }
        }

        /// <summary>
        /// Slaptažodžio keitimui reikalingo el. pašto įvedimo lango uždarymo apdorojimas.
        /// </summary>
        private void PasswordResetEmailView_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (((PasswordResetEmailView)sender).ActiveControl is BackNavigatorControl) return;
            this.Owner.Show();
            this.Close();
        }
    }
}

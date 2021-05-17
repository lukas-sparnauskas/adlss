using DarboLaikoSkaiciavimoSistema.Cache;
using DarboLaikoSkaiciavimoSistema.Controllers;
using System;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace DarboLaikoSkaiciavimoSistema.Views
{
    /// <summary>
    /// Prisijungimo lango klasė.
    /// </summary>
    public partial class LoginView : FormLocalized
    {
        /// <summary>
        /// Prisijungimo lango klasės konstruktorius.
        /// </summary>
        public LoginView()
        {
            try
            {
                LocalCache.SetDBAccess();
                LocalCache.InitLocalCache();
                int saved_user_id = LocalCache.GetSavedUserId();
                Locale saved_locale = LocalCache.GetSavedLocale();
                switch (saved_locale)
                {
                    case Locale.EN:
                        Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("en-GB");
                        break;
                    case Locale.LT:
                        Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("lt-LT");
                        break;
                }

                InitializeComponent();
                SetLocalization();

                if (saved_user_id != -1 && LoginController.CheckUserByID(saved_user_id) == 0)
                {
                    this.Hide();
                    MainView mainView = new MainView();
                    mainView.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                File.AppendAllText(Directory.GetCurrentDirectory() + @"\log.txt", ex.Message);
            }
        }

        /// <summary>
        /// Prisijungimo lango teksto nustatymas.
        /// </summary>
        public override void SetLocalization()
        {
            this.Text = Properties.Strings.loginViewName;
            lblTitle.Text = Properties.Strings.appName;
            lblUsername.Text = Properties.Strings.lblUsername;
            lblPassword.Text = Properties.Strings.lblPassword;
            cbRememberMe.Text = Properties.Strings.cbRememberMe;
            btnForgotPassword.Text = Properties.Strings.btnForgotPassword;
            btnLogin.Text = Properties.Strings.btnLogin;
        }

        /// <summary>
        /// Prisijungimo mygtuko paspaudimo apdorojimas.
        /// </summary>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            switch (LoginController.Login(tbUsername.Text, tbPassword.Text, cbRememberMe.Checked))
            {
                case 0:
                    LocalCache.SaveLastUserId(LoginController.GetUserID(tbUsername.Text));
                    this.Hide();
                    new MainView().ShowDialog();
                    this.Close();
                    break;
                case 1:
                    MessageBox.Show(Properties.Strings.errWrongCredentials, Properties.Strings.errTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }

        /// <summary>
        /// 'Enter' mygtuko paspaudimo slaptažodžio įvedimo laukelyje apdorojimo metodas.
        /// </summary>
        private void tbPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) btnLogin.PerformClick();
        }

        /// <summary>
        /// Slaptažodžio priminimo mygtuko paspaudimo apdorojimo metodas.
        /// </summary>
        private void btnForgotPassword_Click(object sender, EventArgs e)
        {
            this.Hide();
            PasswordResetEmailView passwordResetEmailView = new PasswordResetEmailView();
            passwordResetEmailView.ShowDialog(this);
            passwordResetEmailView.Dispose();
        }
    }
}

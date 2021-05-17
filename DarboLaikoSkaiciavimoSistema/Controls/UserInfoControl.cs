using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DarboLaikoSkaiciavimoSistema.Controllers;
using DarboLaikoSkaiciavimoSistema.Models;
using DarboLaikoSkaiciavimoSistema.Cache;
using System.Threading;
using System.Globalization;

namespace DarboLaikoSkaiciavimoSistema.Controls
{
    /// <summary>
    /// Vartotojo sąsajos naudotojo informacijos atvaizdavimo kontrolės klasė.
    /// </summary>
    public partial class UserInfoControl : UserControl
    {
        /// <summary>
        /// Vartotojo sąsajos naudotojo informacijos atvaizdavimo kontrolės klasės konstruktorius.
        /// </summary>
        public UserInfoControl()
        {
            InitializeComponent();
            try
            {
                SetText();
            }
            catch
            { }
        }

        /// <summary>
        /// Vartotojo sąsajos naudotojo informacijos atvaizdavimo kontrolės klasės atnaujinimo metodas.
        /// </summary>
        public override void Refresh()
        {
            base.Refresh();
            SetText();
        }

        /// <summary>
        /// Naudotojo informacijos teksto atvaizdavimas.
        /// </summary>
        private void SetText()
        {
            User user = UserController.GetUserByID(LocalCache.GetLastUserId());
            lblNameSurname.Text = user.name + " " + user.surname;
            if (Thread.CurrentThread.CurrentUICulture == CultureInfo.GetCultureInfo("lt-LT"))
            {
                lblAccessLevel.Text = Enum.GetName(typeof(AccessLevelLT), user.access_level);
            }
            else
            {
                lblAccessLevel.Text = Enum.GetName(typeof(AccessLevelEN), user.access_level);
            }
        }
    }
}

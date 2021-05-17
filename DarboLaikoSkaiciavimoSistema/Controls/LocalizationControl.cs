using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Globalization;
using DarboLaikoSkaiciavimoSistema.Cache;

namespace DarboLaikoSkaiciavimoSistema.Controls
{
    /// <summary>
    /// Vartotojo sąsajos kalbos pasirinkimo kontrolės klasė.
    /// </summary>
    public partial class LocalizationControl : UserControl
    {
        /// <summary>
        /// Vartotojo sąsajos kalbos pasirinkimo kontrolės klasės konstruktorius.
        /// </summary>
        public LocalizationControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Lietuvių kalbos mygtuko paspaudimo apdorojimo metodas.
        /// </summary>
        private void btnLithuanian_Click(object sender, EventArgs e)
        {
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("lt-LT");
            LocalCache.SaveLocale(Locale.LT);
            FormLocalized parent = this.Parent as FormLocalized;
            if (parent != null)
            {
                parent.SetLocalization();
            }
        }

        /// <summary>
        /// Anglų kalbos mygtuko paspaudimo apdorojimo metodas.
        /// </summary>
        private void btnEnglish_Click(object sender, EventArgs e)
        {
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("en-GB");
            LocalCache.SaveLocale(Locale.EN);
            FormLocalized parent = this.Parent as FormLocalized;
            if (parent != null)
            {
                parent.SetLocalization();
            }
        }
    }
}

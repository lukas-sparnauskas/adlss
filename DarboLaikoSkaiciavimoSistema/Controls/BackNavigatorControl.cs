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

namespace DarboLaikoSkaiciavimoSistema.Controls
{
    /// <summary>
    /// Vartotojo sąsajos mygtuko 'Atgal' kontrolė.
    /// </summary>
    public partial class BackNavigatorControl : UserControl
    {
        /// <summary>
        /// Vartotojo sąsajos mygtuko 'Atgal' kontrolės konstruktorius
        /// </summary>
        public BackNavigatorControl()
        {
            InitializeComponent();
            btnBack.Text = Properties.Strings.btnBack;
        }

        /// <summary>
        /// 'Atgal' mygtuko paspaudimo apdorojimo metodas.
        /// </summary>
        private void btnBack_Click(object sender, EventArgs e)
        {
            FormLocalized form = this.Parent as FormLocalized;
            form.Owner.Show();
            form.Owner.Refresh();
            form.ActiveControl = this;
            form.Close();
        }

        /// <summary>
        /// Vartotojo sąsajos mygtuko 'Atgal' kontrolės atnaujinimo metodas.
        /// </summary>
        public override void Refresh()
        {
            base.Refresh();
            btnBack.Text = Properties.Strings.btnBack;
        }

        /// <summary>
        /// 'Atgal' mygtuko paspaudimo įvykdymo metodas.
        /// </summary>
        public void PerformClick()
        {
            btnBack.PerformClick();
        }
    }
}

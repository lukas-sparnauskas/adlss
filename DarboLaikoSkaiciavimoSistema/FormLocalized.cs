using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DarboLaikoSkaiciavimoSistema
{
#if DEBUG
    /// <summary>
    /// Vartotojo sąsajos lango klasė su kalbos nustatymo galimybe.
    /// </summary>
    public class FormLocalized : Form
    {
#else
    public abstract class FormLocalized : Form
    {
#endif

#if DEBUG
        /// <summary>
        /// Lokalizuoto teksto nustatymo metodas.
        /// </summary>
        public virtual void SetLocalization()
        {
            return;
        }
#else
        public abstract void SetLocalization();
#endif


    }
}

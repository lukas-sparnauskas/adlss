using System;
using System.IO;
using System.Windows.Forms;
using DarboLaikoSkaiciavimoSistema.Views;

namespace DarboLaikoSkaiciavimoSistema
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new LoginView());
            }
            catch (Exception ex)
            {
                File.AppendAllText(Directory.GetCurrentDirectory() + @"\log.txt", ex.Message);
            }
        }
    }
}

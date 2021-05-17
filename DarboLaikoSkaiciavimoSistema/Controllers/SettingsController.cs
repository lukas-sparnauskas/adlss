using DarboLaikoSkaiciavimoSistema.Models;
using System;
using System.Linq;

namespace DarboLaikoSkaiciavimoSistema.Controllers
{
    /// <summary>
    /// Sistemos nustatymų prieigos ir saugojimo klasė.
    /// </summary>
    public class SettingsController
    {
        /// <summary>
        /// Sistemos nustatymų gavimas iš duomenų bazės.
        /// </summary>
        /// <returns>Sistemos nustatymai.</returns>
        public static Settings GetSettings()
        {
            try
            {
                using (dlssdb db = new dlssdb())
                {
                    Settings settings = db.Settings.FirstOrDefault();
                    return settings;
                }
            }
            catch
            { }
            return new Settings();
        }

        /// <summary>
        /// Sistemos nustatymų išsaugojimas duomenų bazėje.
        /// </summary>
        /// <param name="settings">Įšsaugomi sistemos nustatymai</param>
        public static void SaveSettings(Settings settings)
        {
            try
            {
                using (dlssdb db = new dlssdb())
                {
                    Settings settingsExisting = db.Settings.FirstOrDefault();
                    settingsExisting.NVRIP = settings.NVRIP;
                    settingsExisting.NVRPort = settings.NVRPort;
                    settingsExisting.NVRUsername = settings.NVRUsername;
                    settingsExisting.NVRPassword = settings.NVRPassword;
                    settingsExisting.AccessControllerIP = settings.AccessControllerIP;
                    settingsExisting.AccessControllerPort = settings.AccessControllerPort;
                    settingsExisting.AccessControllerUsername = settings.AccessControllerUsername;
                    settingsExisting.AccessControllerPassword = settings.AccessControllerPassword;
                    db.SaveChanges();
                }
            }
            catch
            { }
        }
    }
}

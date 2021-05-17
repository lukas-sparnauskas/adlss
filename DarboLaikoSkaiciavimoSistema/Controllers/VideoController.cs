using DarboLaikoSkaiciavimoSistema.Models;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vlc.DotNet.Forms;

namespace DarboLaikoSkaiciavimoSistema.Controllers
{
    /// <summary>
    /// Vaizdo medžiagos gavimo ir atvaizdavimo klasė.
    /// </summary>
    public class VideoController
    {
        /// <summary>
        /// Vaizdo medžiagos gavimas ir atvaizdavimas.
        /// </summary>
        /// <param name="vlcControl">Vaizdo grotuvo kontrolė</param>
        /// <param name="mode">Vaizdo medžiagos rėžimas</param>
        /// <param name="channel">Kameros ID</param>
        /// <param name="startTime">Vaizdo įrašo pradžios laikas</param>
        /// <param name="endTime">Vaizdo įrašo pabaigos laikas</param>
        public static void PlayVideo(VlcControl vlcControl, VideoMode mode, int channel, DateTime? startTime, DateTime? endTime)
        {
            string sourceURL = "";
            Settings settings = SettingsController.GetSettings();

            switch (mode)
            {
                case VideoMode.Stream:
                    sourceURL = string.Format(Properties.Resources.streamURL, settings.NVRUsername, settings.NVRPassword, settings.NVRIP, settings.NVRPort, channel);
                    break;
                case VideoMode.Recording:
                    string startTimeString = startTime.Value.ToString("yyyyMMddTHHmmssZ");
                    string endTimeString = endTime.Value.ToString("yyyyMMddTHHmmssZ");
                    sourceURL = string.Format(Properties.Resources.recordingURL, settings.NVRUsername, settings.NVRPassword, settings.NVRIP, settings.NVRPort, channel, startTimeString, endTimeString);
                    break;
            }

            try
            {
                var task = Task.Run(() =>
                {
                    vlcControl.SetMedia(new Uri(sourceURL));
                    vlcControl.Play();
                });

                if (task.Wait(TimeSpan.FromSeconds(10)))
                {
                    return;
                }
                else
                {
                    MessageBox.Show(Properties.Strings.errNoVideo, Properties.Strings.errTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {
                MessageBox.Show(Properties.Strings.errNoVideo, Properties.Strings.errTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

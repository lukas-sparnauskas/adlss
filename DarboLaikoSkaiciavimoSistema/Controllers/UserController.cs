using CardManagement;
using DarboLaikoSkaiciavimoSistema.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace DarboLaikoSkaiciavimoSistema.Controllers
{
    /// <summary>
    /// Naudotojo duomenų prieigos ir išsaugojimo klasė.
    /// </summary>
    public class UserController
    {
        //TODO: test card 0007464386 / 0007472620

        /// <summary>
        /// Naudotojo duomenų gavimas pagal naudotojo ID.
        /// </summary>
        /// <param name="user_id">Naudotojo ID</param>
        /// <returns>Naudotojo duomenys</returns>
        public static User GetUserByID(int user_id)
        {
            try
            {
                using (dlssdb db = new dlssdb())
                {
                    User user = db.Users.Where(x => x.id == user_id).FirstOrDefault();
                    return user;
                }
            }
            catch
            {
                MessageBox.Show(Properties.Strings.errUser, Properties.Strings.errTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new User();
            }
        }

        /// <summary>
        /// Naudotojo duomenų gavimas pagal el. paštą.
        /// </summary>
        /// <param name="email">Naudotojo el. paštas</param>
        /// <returns>Naudotojo duomenys</returns>
        public static User GetUserByEmail(string email)
        {
            try
            {
                using (dlssdb db = new dlssdb())
                {
                    User user = db.Users.Where(x => x.email == email).FirstOrDefault();
                    return user;
                }
            }
            catch
            {
                MessageBox.Show(Properties.Strings.errUser, Properties.Strings.errTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new User();
            }
        }

        /// <summary>
        /// Naudotojo egzistavimo duomenų bazėje patikrinimas pagal naudotojo prisijungimo vardą.
        /// </summary>
        /// <param name="username">Naudotojo prisijungimo vardas</param>
        /// <returns>True - naudotojas egzistuoja, false - naudotojas neegzistuoja.</returns>
        public static bool UsernameExists(string username)
        {
            try
            {
                using (dlssdb db = new dlssdb())
                {
                    User user = db.Users.Where(x => x.username == username).FirstOrDefault();
                    if (user != null) return true;
                }
            }
            catch
            { }
            return false;
        }

        /// <summary>
        /// Slaptažodžio atkūrimo kodo siuntimas naudotojo el. pašto adresu.
        /// </summary>
        /// <param name="email">Naudotojo el. paštas</param>
        /// <returns>Nusiųstas slaptažodžio atkūrimo kodas.</returns>
        public static string SendPasswordResetCode(string email)
        {
            Random rnd = new Random();
            string resetCode = rnd.Next(0, 1000000).ToString("D6");

            SmtpClient mailClient = new SmtpClient();
            mailClient.Host = Properties.Resources.mailServer;
            mailClient.Port = int.Parse(Properties.Resources.mailPortTLS);
            mailClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            mailClient.UseDefaultCredentials = false;
            mailClient.EnableSsl = true;
            mailClient.Credentials = new NetworkCredential(Properties.Resources.mailUsername, Properties.Resources.mailPassword);

            MailMessage message = new MailMessage();
            message.From = new MailAddress(Properties.Resources.mailUsername);
            message.To.Add(email);
            message.Subject = Properties.Resources.mailSubject;
            message.IsBodyHtml = true;
            message.Body = string.Format(Properties.Resources.mailBody, resetCode);
            message.BodyEncoding = Encoding.UTF8;
            message.SubjectEncoding = Encoding.Default;
            message.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(string.Format(Properties.Resources.mailBody, resetCode), new ContentType("text/html")));

            mailClient.Send(message);
            return resetCode;
        }

        /// <summary>
        /// Patikrinimas, ar įėjimo kortelės numeris jau naudojamas.
        /// </summary>
        /// <param name="card_id">Įėjimo kortelės numeris</param>
        /// <returns>True - kortelės numeris naudojamas, false - kortelės numeris nenaudojamas.</returns>
        public static bool CardIdIsTaken(string card_id)
        {
            try
            {
                using (dlssdb db = new dlssdb())
                {
                    User user = db.Users.Where(x => x.card_id == card_id).FirstOrDefault();
                    if (user != null) return true;
                }
            }
            catch
            { }
            return false;
        }

        /// <summary>
        /// Patikrinimas, ar slaptažodis atitinka reikalavimus.
        /// </summary>
        /// <param name="password">Slaptažodis</param>
        /// <returns>True - slaptažodis reikalavimus atitinka, false - slaptažodis reikalavimų neatitinka.</returns>
        public static bool CheckPassword(string password)
        {
            return password.Length >= 8 && password.Any(char.IsUpper) && password.Any(char.IsLower) && password.Any(char.IsDigit);
        }

        /// <summary>
        /// Patikrinimas, ar el. pašto adresas taisyklingas.
        /// </summary>
        /// <param name="email">El. pašto adresas</param>
        /// <returns>True - el. pašto adresas taisyklingas, false - el. pašto adresas netaisyklingas.</returns>
        public static bool CheckEmail(string email)
        {
            return email.Contains('@') && email.Contains('.') && email.IndexOf('@') > 0 && email.IndexOf('@') == email.LastIndexOf('@') 
                && email.LastIndexOf('.') > email.LastIndexOf('@');
        }

        /// <summary>
        /// Naujo naudotojo užregistravimas.
        /// </summary>
        /// <param name="user">Registruojamas naudotoas</param>
        /// <returns>True - naudotojas užregistruotas sėkmingai, false - naudotojas neužregistruotas.</returns>
        public static bool RegisterUser(User user)
        {
            user.id = GetNewID();
            user.password = BCrypt.Net.BCrypt.EnhancedHashPassword(user.password);

            int accessController_user_id = AccessControllerLogin();
            if (accessController_user_id != -1)
            {
                AccessControllerAddUser(user, accessController_user_id);
                InsertNewUserDB(user);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Naudotojo duomenų atnaujinimas.
        /// </summary>
        /// <param name="user">Atnaujinamas naudotojas</param>
        /// <param name="handle">Naudotojo išsaugojimui įeigos kontrolės įrenginyje reikalinga reikšmė</param>
        /// <returns>True - naudotojas atnaujintas sėkmingai, false - naudotojas neišsaugotas.</returns>
        public static bool UpdateUser(User user, IntPtr handle)
        {
            user.password = BCrypt.Net.BCrypt.EnhancedHashPassword(user.password);

            User existingUser = GetUserByID(user.id);
            if (existingUser.card_id != user.card_id)
            {
                int accessController_user_id = AccessControllerLogin();
                if (accessController_user_id != -1)
                {
                    AccessControllerDeleteUser(existingUser, accessController_user_id, handle);
                    accessController_user_id = AccessControllerLogin();
                    AccessControllerAddUser(user, accessController_user_id);
                }
                else
                {
                    return false;
                }
            }
            UpdateUserDB(user);
            return true;
        }

        /// <summary>
        /// Naudotojo slaptažodžio atnaujinimas.
        /// </summary>
        /// <param name="user_id">Naudotojo ID</param>
        /// <param name="password">Naujas naudotojo slaptažodis</param>
        public static void UpdateUserPassword(int user_id, string password)
        {
            try
            {
                using (dlssdb db = new dlssdb())
                {
                    User user = db.Users.Where(x => x.id == user_id).FirstOrDefault();
                    user.password = BCrypt.Net.BCrypt.EnhancedHashPassword(password);
                    db.SaveChanges();
                }
            }
            catch
            { }
        }

        /// <summary>
        /// Naujo naudotojo išsaugojimas duomenų bazėje.
        /// </summary>
        /// <param name="user">Išsaugomas naudotojas</param>
        private static void InsertNewUserDB(User user)
        {
            try
            {
                using (dlssdb db = new dlssdb())
                {
                    db.Users.Add(user);
                    db.SaveChanges();
                }
            }
            catch
            {
                MessageBox.Show(Properties.Strings.errUser, Properties.Strings.errTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Naudotojo atnaujinimas duomenų bazėje.
        /// </summary>
        /// <param name="user">Atnaujinamas naudotojas</param>
        private static void UpdateUserDB(User user)
        {
            try
            {
                using (dlssdb db = new dlssdb())
                {
                    User existingUser = db.Users.Where(x => x.id == user.id).FirstOrDefault();

                    List<Entry> entries = db.Entries.Where(x => x.card_id == existingUser.card_id).ToList();
                    foreach (var entry in entries)
                    {
                        entry.card_id = user.card_id;
                    }

                    existingUser.name = user.name;
                    existingUser.surname = user.surname;
                    existingUser.password = user.password;
                    existingUser.email = user.email;
                    existingUser.card_id = user.card_id;
                    existingUser.access_level = user.access_level;
                    existingUser.work_hours_in_week = user.work_hours_in_week;

                    db.SaveChanges();
                }
            }
            catch
            {
                MessageBox.Show(Properties.Strings.errUser, Properties.Strings.errTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Naudotojo duomenų pašalinimas.
        /// </summary>
        /// <param name="user">Pašalinamas naudotojas</param>
        /// <param name="handle">Naudotojo pašalinimui iš įeigos kontrolės įrenginio reikalinga reikšmė</param>
        /// <returns>True - naudotojas sėkmingai pašalintas, false - naudotojas nepašalintas.</returns>
        public static bool RemoveUser(User user, IntPtr handle)
        {
            int accessController_user_id = AccessControllerLogin();
            if (accessController_user_id != -1)
            {
                AccessControllerDeleteUser(user, accessController_user_id, handle);
                RemoveUserDB(user);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Naudotojo pašalinimas iš duomenų bazės.
        /// </summary>
        /// <param name="user">Pašalinamas naudotojas</param>
        public static void RemoveUserDB(User user)
        {
            try
            {
                using (dlssdb db = new dlssdb())
                {
                    List<Entry> entries = db.Entries.Where(x => x.card_id == user.card_id).ToList();
                    db.Entries.RemoveRange(entries);
                    User existingUser = db.Users.Where(x => x.card_id == user.card_id).FirstOrDefault();
                    db.Users.Remove(existingUser);
                    db.SaveChanges();
                }
            }
            catch
            {
                MessageBox.Show(Properties.Strings.errUser, Properties.Strings.errTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Naujo naudotojo ID gavimas.
        /// </summary>
        /// <returns>Naujas naudotojo ID</returns>
        private static int GetNewID()
        {
            try
            {
                using (dlssdb db = new dlssdb())
                {
                    int last_id = db.Users.OrderByDescending(x => x.id).Select(x => x.id).FirstOrDefault();
                    return last_id + 1;
                }
            }
            catch
            {
                MessageBox.Show(Properties.Strings.errUser, Properties.Strings.errTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }

        /// <summary>
        /// Prisijungimas prie įeigos kontrolės įrenginio.
        /// </summary>
        /// <returns>Įeigos kontrolės įrenginio naudotojo ID. -1 jeigu nepavyko prisijungti prie įrenginio.</returns>
        public static int AccessControllerLogin()
        {
            Settings _settings = SettingsController.GetSettings();

            if (CHCNetSDK.NET_DVR_Init() == false)
            {
                return -1;
            }
            CHCNetSDK.NET_DVR_SetLogToFile(3, "./", false);

            CHCNetSDK.NET_DVR_USER_LOGIN_INFO struLoginInfo = new CHCNetSDK.NET_DVR_USER_LOGIN_INFO();
            CHCNetSDK.NET_DVR_DEVICEINFO_V40 struDeviceInfoV40 = new CHCNetSDK.NET_DVR_DEVICEINFO_V40();
            struDeviceInfoV40.struDeviceV30.sSerialNumber = new byte[CHCNetSDK.SERIALNO_LEN];

            struLoginInfo.sDeviceAddress = _settings.AccessControllerIP;
            struLoginInfo.sUserName = _settings.AccessControllerUsername;
            struLoginInfo.sPassword = _settings.AccessControllerPassword;
            ushort.TryParse(_settings.AccessControllerPort.ToString(), out struLoginInfo.wPort);

            int lUserID = -1;
            lUserID = CHCNetSDK.NET_DVR_Login_V40(ref struLoginInfo, ref struDeviceInfoV40);
            if (lUserID >= 0)
            {
                return lUserID;
            }
            return -1;
        }

        /// <summary>
        /// Naujo naudotojo užregistravimas įeigos kontrolės įrenginyje.
        /// </summary>
        /// <param name="user">Registruojamas naudotojas</param>
        /// <param name="accessController_user_id">Įeigos kontrolės įrenginio naudotojo ID</param>
        private static void AccessControllerAddUser(User user, int accessController_user_id)
        {
            Int32 setCardCfgHandle = -1;
            CHCNetSDK.NET_DVR_CARD_COND struCond = new CHCNetSDK.NET_DVR_CARD_COND();
            struCond.Init();
            struCond.dwSize = (uint)Marshal.SizeOf(struCond);
            struCond.dwCardNum = 1;
            IntPtr ptrStruCond = Marshal.AllocHGlobal((int)struCond.dwSize);
            Marshal.StructureToPtr(struCond, ptrStruCond, false);

            setCardCfgHandle = CHCNetSDK.NET_DVR_StartRemoteConfig(accessController_user_id, CHCNetSDK.NET_DVR_SET_CARD, ptrStruCond, (int)struCond.dwSize, null, IntPtr.Zero);
            if (setCardCfgHandle < 0)
            {
                Marshal.FreeHGlobal(ptrStruCond);
                return;
            }
            else
            {
                SendCardDataToAccessController(user, setCardCfgHandle);
                Marshal.FreeHGlobal(ptrStruCond);
            }
            CHCNetSDK.NET_DVR_Logout_V30(accessController_user_id);
            CHCNetSDK.NET_DVR_Cleanup();
        }

        /// <summary>
        /// Naudotojo pašalinimas iš įeigos kontrolės įrenginio.
        /// </summary>
        /// <param name="user">Pašalinimas naudotojas</param>
        /// <param name="accessController_user_id">Įeigos kontrolės įrenginio naudotojo ID</param>
        /// <param name="handle">Naudotojo pašalinimui iš įeigos kontrolės įrenginio reikalinga reikšmė</param>
        private static void AccessControllerDeleteUser(User user, int accessController_user_id, IntPtr handle)
        {
            Int32 setCardCfgHandle = -1;
            CHCNetSDK.NET_DVR_CARD_COND struCond = new CHCNetSDK.NET_DVR_CARD_COND();
            struCond.Init();
            struCond.dwSize = (uint)Marshal.SizeOf(struCond);
            struCond.dwCardNum = 1;
            IntPtr ptrStruCond = Marshal.AllocHGlobal((int)struCond.dwSize);
            Marshal.StructureToPtr(struCond, ptrStruCond, false);

            CHCNetSDK.NET_DVR_CARD_SEND_DATA struSendData = new CHCNetSDK.NET_DVR_CARD_SEND_DATA();
            struSendData.Init();
            struSendData.dwSize = (uint)Marshal.SizeOf(struSendData);
            byte[] byTempCardNo = new byte[CHCNetSDK.ACS_CARD_NO_LEN];
            byTempCardNo = System.Text.Encoding.UTF8.GetBytes(user.card_id);
            for (int i = 0; i < byTempCardNo.Length; i++)
            {
                struSendData.byCardNo[i] = byTempCardNo[i];
            }
            IntPtr ptrStruSendData = Marshal.AllocHGlobal((int)struSendData.dwSize);
            Marshal.StructureToPtr(struSendData, ptrStruSendData, false);

            CHCNetSDK.NET_DVR_CARD_STATUS struStatus = new CHCNetSDK.NET_DVR_CARD_STATUS();
            struStatus.Init();
            struStatus.dwSize = (uint)Marshal.SizeOf(struStatus);
            IntPtr ptrdwState = Marshal.AllocHGlobal((int)struStatus.dwSize);
            Marshal.StructureToPtr(struStatus, ptrdwState, false);

            setCardCfgHandle = CHCNetSDK.NET_DVR_StartRemoteConfig(accessController_user_id, CHCNetSDK.NET_DVR_DEL_CARD, ptrStruCond, (int)struCond.dwSize, null, handle);
            if (setCardCfgHandle < 0)
            {
                Marshal.FreeHGlobal(ptrStruCond);
                return;
            }
            else
            {
                int dwState = (int)CHCNetSDK.NET_SDK_SENDWITHRECV_STATUS.NET_SDK_CONFIG_STATUS_SUCCESS;
                uint dwReturned = 0;
                while (true)
                {
                    dwState = CHCNetSDK.NET_DVR_SendWithRecvRemoteConfig(setCardCfgHandle, ptrStruSendData, struSendData.dwSize, ptrdwState, struStatus.dwSize, ref dwReturned);
                    if (dwState == (int)CHCNetSDK.NET_SDK_SENDWITHRECV_STATUS.NET_SDK_CONFIG_STATUS_NEEDWAIT)
                    {
                        Thread.Sleep(10);
                        continue;
                    }
                    else if (dwState == (int)CHCNetSDK.NET_SDK_SENDWITHRECV_STATUS.NET_SDK_CONFIG_STATUS_FAILED)
                    {
                        continue;
                    }
                    else if (dwState == (int)CHCNetSDK.NET_SDK_SENDWITHRECV_STATUS.NET_SDK_CONFIG_STATUS_SUCCESS)
                    {
                        continue;
                    }
                    else if (dwState == (int)CHCNetSDK.NET_SDK_SENDWITHRECV_STATUS.NET_SDK_CONFIG_STATUS_FINISH)
                    {
                        break;
                    }
                    else if (dwState == (int)CHCNetSDK.NET_SDK_SENDWITHRECV_STATUS.NET_SDK_CONFIG_STATUS_EXCEPTION)
                    {
                        break;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            CHCNetSDK.NET_DVR_StopRemoteConfig(setCardCfgHandle);
            setCardCfgHandle = -1;
            Marshal.FreeHGlobal(ptrStruSendData);
            Marshal.FreeHGlobal(ptrdwState);

            CHCNetSDK.NET_DVR_Logout_V30(accessController_user_id);
            CHCNetSDK.NET_DVR_Cleanup();
        }

        /// <summary>
        /// Įeigos kortelės numerio užregistravimas įeigos kontrolės įrenginyje.
        /// </summary>
        /// <param name="user">Registruojamas darbuotojas</param>
        /// <param name="setCardCfgHandle">Naudotojo išsaugojimui įeigos kontrolės įrenginyje reikalinga reikšmė</param>
        private static void SendCardDataToAccessController(User user, Int32 setCardCfgHandle)
        {
            CHCNetSDK.NET_DVR_CARD_RECORD struData = new CHCNetSDK.NET_DVR_CARD_RECORD();
            struData.Init();
            struData.dwSize = (uint)Marshal.SizeOf(struData);
            struData.byCardType = 1;
            byte[] byTempCardNo = new byte[CHCNetSDK.ACS_CARD_NO_LEN];
            byTempCardNo = System.Text.Encoding.UTF8.GetBytes(user.card_id);
            for (int i = 0; i < byTempCardNo.Length; i++)
            {
                struData.byCardNo[i] = byTempCardNo[i];
            }
            uint.TryParse(user.id.ToString(), out struData.dwEmployeeNo);
            byte[] byTempName = new byte[CHCNetSDK.NAME_LEN];
            byTempName = System.Text.Encoding.Default.GetBytes(user.name + "_" + user.surname);
            for (int i = 0; i < byTempName.Length; i++)
            {
                struData.byName[i] = byTempName[i];
            }
            struData.struValid.byEnable = 1;
            struData.struValid.struBeginTime.wYear = 2000;
            struData.struValid.struBeginTime.byMonth = 1;
            struData.struValid.struBeginTime.byDay = 1;
            struData.struValid.struBeginTime.byHour = 11;
            struData.struValid.struBeginTime.byMinute = 11;
            struData.struValid.struBeginTime.bySecond = 11;
            struData.struValid.struEndTime.wYear = 2100;
            struData.struValid.struEndTime.byMonth = 1;
            struData.struValid.struEndTime.byDay = 1;
            struData.struValid.struEndTime.byHour = 11;
            struData.struValid.struEndTime.byMinute = 11;
            struData.struValid.struEndTime.bySecond = 11;
            struData.byDoorRight[0] = 1;
            struData.wCardRightPlan[0] = 1;
            IntPtr ptrStruData = Marshal.AllocHGlobal((int)struData.dwSize);
            Marshal.StructureToPtr(struData, ptrStruData, false);

            CHCNetSDK.NET_DVR_CARD_STATUS struStatus = new CHCNetSDK.NET_DVR_CARD_STATUS();
            struStatus.Init();
            struStatus.dwSize = (uint)Marshal.SizeOf(struStatus);
            IntPtr ptrdwState = Marshal.AllocHGlobal((int)struStatus.dwSize);
            Marshal.StructureToPtr(struStatus, ptrdwState, false);

            int dwState = (int)CHCNetSDK.NET_SDK_SENDWITHRECV_STATUS.NET_SDK_CONFIG_STATUS_SUCCESS;
            uint dwReturned = 0;
            while (true)
            {
                dwState = CHCNetSDK.NET_DVR_SendWithRecvRemoteConfig(setCardCfgHandle, ptrStruData, struData.dwSize, ptrdwState, struStatus.dwSize, ref dwReturned);
                struStatus = (CHCNetSDK.NET_DVR_CARD_STATUS)Marshal.PtrToStructure(ptrdwState, typeof(CHCNetSDK.NET_DVR_CARD_STATUS));
                if (dwState == (int)CHCNetSDK.NET_SDK_SENDWITHRECV_STATUS.NET_SDK_CONFIG_STATUS_NEEDWAIT)
                {
                    Thread.Sleep(10);
                    continue;
                }
                else if (dwState == (int)CHCNetSDK.NET_SDK_SENDWITHRECV_STATUS.NET_SDK_CONFIG_STATUS_FAILED)
                {
                    continue;
                }
                else if (dwState == (int)CHCNetSDK.NET_SDK_SENDWITHRECV_STATUS.NET_SDK_CONFIG_STATUS_SUCCESS)
                {
                    continue;
                }
                else if (dwState == (int)CHCNetSDK.NET_SDK_SENDWITHRECV_STATUS.NET_SDK_CONFIG_STATUS_FINISH)
                {
                    break;
                }
                else if (dwState == (int)CHCNetSDK.NET_SDK_SENDWITHRECV_STATUS.NET_SDK_CONFIG_STATUS_EXCEPTION)
                {
                    break;
                }
                else
                {
                    break;
                }
            }
            CHCNetSDK.NET_DVR_StopRemoteConfig(setCardCfgHandle);
            Marshal.FreeHGlobal(ptrStruData);
            Marshal.FreeHGlobal(ptrdwState);
            return;
        }
    }
}

using System;
using System.Linq;
using DarboLaikoSkaiciavimoSistema.Cache;
using DarboLaikoSkaiciavimoSistema.Models;

namespace DarboLaikoSkaiciavimoSistema.Controllers
{
    /// <summary>
    /// Naudotojo prisijungimo valdymo klasė.
    /// </summary>
    public class LoginController
    {
        /// <summary>
        /// Naudotojo prisijungimo duomenų tikrinimas.
        /// </summary>
        /// <param name="username">Naudotojo prisijungimo vardas</param>
        /// <param name="password">Naudotojo slaptažodis</param>
        /// <param name="rememberMe">Naudotojų prisijungimo duomenų išsaugojimas automatiniam prisijungimui</param>
        /// <returns>0 - prisijungimo duomenys teisingi. 1 - prisijungimo duomenys neteisingi.</returns>
        public static int Login(string username, string password, bool rememberMe)
        {
            string passwordHash = GetUserPassword(username);
            if (passwordHash != null && passwordHash != "" && BCrypt.Net.BCrypt.EnhancedVerify(password, passwordHash))
            {
                if (rememberMe)
                {
                    LocalCache.SaveUserId(GetUserID(username));
                }
                
                return 0;
            }
            return 1;
        }

        /// <summary>
        /// Naudotojo egzistavimo duomenų bazėje patikrinimas pagal ID.
        /// </summary>
        /// <param name="user_id">Naudotojo ID</param>
        /// <returns>0 - naudotojas rastas. 1 - naudotojas nerastas.</returns>
        public static int CheckUserByID(int user_id)
        {
            try 
            { 
                using (dlssdb db = new dlssdb())
                {
                    string password = db.Users.Where(x => x.id.Equals(user_id)).Select(x => x.password).FirstOrDefault();
                    if (string.IsNullOrEmpty(password))
                    {
                        return 1;
                    }
                }
            }
            catch
            { }
            return 0;
        }

        /// <summary>
        /// Naudotojo slaptažodžio gavimas pagal naudotojo vardą.
        /// </summary>
        /// <param name="username">Naudotojo prisijungimo vardas</param>
        /// <returns>Naudotojo slaptažodis. Jei naudotojas nerastas, grąžinama tuščia reikšmė.</returns>
        public static string GetUserPassword(string username)
        {
            try
            {
                using (dlssdb db = new dlssdb())
                {
                    string password = db.Users.Where(x => x.username.Equals(username)).Select(x => x.password).FirstOrDefault();
                    return password;
                }
            }
            catch
            {
                return "";
            }
        }

        /// <summary>
        /// Naudotojo ID gavimas pagal prisijungimo vardą.
        /// </summary>
        /// <param name="username">Naudotojo prisijungimo vardas</param>
        /// <returns>Naudotojo ID. Jeigu naudotojas nerastas, grąžinama reikšmė -1.</returns> 
        public static int GetUserID(string username)
        {
            try
            {
                using (dlssdb db = new dlssdb())
                {
                    int id;
                    string response = db.Users.Where(x => x.username.Equals(username)).Select(x => x.id).FirstOrDefault().ToString();
                    if (int.TryParse(response, out id))
                    {
                        return id;
                    }
                }
            }
            catch
            { }
            return -1;
        }
    }
}

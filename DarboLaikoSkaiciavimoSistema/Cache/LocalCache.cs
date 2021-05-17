using System.Configuration;
using System.Data.SqlClient;

namespace DarboLaikoSkaiciavimoSistema.Cache
{
    /// <summary>
    /// Lokalių programos duomenų įrašymo ir prieigos klasė. 
    /// </summary>
    public class LocalCache
    {
        #region Saved User ID
        /// <summary>
        /// Išsaugoto naudotojo ID gavimas.
        /// </summary>
        /// <returns>Išsaugoto naudotojo ID</returns>
        public static int GetSavedUserId()
        {
            int user_id = -1;
            var cn = new SqlConnection(LoadConnectionString());
            cn.Open();
            SqlCommand cmd = new SqlCommand("SELECT user_id FROM user_cache", cn);
                
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    int.TryParse(reader["user_id"].ToString(), out user_id);
                }
            }
            cn.Close();
            return user_id;
        }

        /// <summary>
        /// Naudotojo ID išsaugojimas.
        /// </summary>
        /// <param name="user_id">Išsaugomo naudotojo ID</param>
        public static void SaveUserId(int user_id)
        {
            var cn = new SqlConnection(LoadConnectionString());
            SqlCommand cmd = new SqlCommand("UPDATE user_cache SET user_id = @user_id", cn);
            cmd.Parameters.AddWithValue("@user_id", user_id);
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
        }
        #endregion

        #region Saved Locale
        /// <summary>
        /// Programos kalbos lokalės gavimas.
        /// </summary>
        /// <returns>Programos kalbos lokalė</returns>
        public static Locale GetSavedLocale()
        {
            string locale = "";
            var cn = new SqlConnection(LoadConnectionString());
            cn.Open();
            SqlCommand cmd = new SqlCommand("SELECT locale FROM user_cache", cn);

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    locale = reader["locale"].ToString();
                }
            }
            cn.Close();

            switch (locale)
            {
                case "EN":
                    return Locale.EN;
                case "LT":
                    return Locale.LT;
                default:
                    return Locale.LT;
            }
        }

        /// <summary>
        /// Programos kalbos lokalės išsaugojimas.
        /// </summary>
        /// <param name="locale">Išsaugoma programos kalbos lokalė</param>
        public static void SaveLocale(Locale locale)
        {
            var cn = new SqlConnection(LoadConnectionString());
            SqlCommand cmd = new SqlCommand("UPDATE user_cache SET locale = @locale", cn);
            cmd.Parameters.AddWithValue("@locale", locale.ToString());
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
        }
        #endregion

        #region Last User ID
        /// <summary>
        /// Paskutinio, prie valdymo programos prisijungusio, naudotojo ID gavimas.
        /// </summary>
        /// <returns>Paskutinio, prie valdymo programos prisijungusio, naudotojo ID</returns>
        public static int GetLastUserId()
        {
            int last_user_id = -1;
            var cn = new SqlConnection(LoadConnectionString());
            cn.Open();
            SqlCommand cmd = new SqlCommand("SELECT last_user_id FROM user_cache", cn);

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    int.TryParse(reader["last_user_id"].ToString(), out last_user_id);
                }
            }
            cn.Close();
            return last_user_id;
        }

        /// <summary>
        /// Paskutinio, prie valdymo programos prisijungusio, naudotojo ID išsaugojimas.
        /// </summary>
        /// <param name="user_id">Išsaugomas paskutinio, prie valdymo programos prisijungusio, naudotojo ID</param>
        public static void SaveLastUserId(int user_id)
        {
            var cn = new SqlConnection(LoadConnectionString());
            SqlCommand cmd = new SqlCommand("UPDATE user_cache SET last_user_id = @user_id", cn);
            cmd.Parameters.AddWithValue("@user_id", user_id);
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
        }
        #endregion

        /// <summary>
        /// Valdymo programos lokalios duomenų bazės inicializavimas.
        /// </summary>
        public static void InitLocalCache()
        {
            var cn = new SqlConnection(LoadConnectionString());
            SqlCommand cmd1 = new SqlCommand("SELECT * FROM user_cache", cn);
            SqlCommand cmd2 = new SqlCommand("INSERT INTO user_cache (user_id, locale, last_user_id) VALUES (-1, 'LT', '-1')", cn);
            cn.Open();
            using (SqlDataReader reader = cmd1.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    cn.Close();
                    return;
                }
            }
            int a = cmd2.ExecuteNonQuery();
            cn.Close();
        }

        /// <summary>
        /// Valdymo programos lokalios duomenų bazės failo kelio gavimas.
        /// </summary>
        /// <returns>Valdymo programos lokalios duomenų bazės failo kelias</returns>
        private static string LoadConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["Cache"].ConnectionString;
        }
    }
}

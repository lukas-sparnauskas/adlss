using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using WEBAPI.Models;

namespace WEBAPI.Controllers
{
    /// <summary>
    /// Sistemos nustatymų prieigos kontrolės klasė.
    /// </summary>
    public class SettingsController : ApiController
    {
        /// <summary>
        /// Sistemos nustatymų gavimas.
        /// </summary>
        /// <returns>Sistemos nustatymai</returns>
        [Route("api/settings")]
        [HttpGet]
        [AuthenticationController]
        public IEnumerable<Setting> Get()
        {
            try
            {
                using (dlssdbEntities db = new dlssdbEntities())
                {
                    Setting[] settings = db.Settings.ToArray();
                    return settings;
                }
            }
            catch
            { }
            return new Setting[] { };
        }
    }
}
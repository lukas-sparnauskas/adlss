using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using WEBAPI.Models;

namespace WEBAPI.Controllers
{
    /// <summary>
    /// Naudotojo kortelės nuskaitymo įvykių prieigos kontrolės klasė.
    /// </summary>
    public class EntryController : ApiController
    {
        /// <summary>
        /// Naudotojo kortelės nuskaitymo įvykių sąrašo gavimas.
        /// </summary>
        /// <returns>Naudotojo kortelės nuskaitymo įvykių sąrašas</returns>
        [Route("api/entries")]
        [HttpGet]
        [AuthenticationController]
        public IEnumerable<Entry> Get()
        {
            try
            {
                using (dlssdbEntities db = new dlssdbEntities())
                {
                    Entry[] entries = db.Entries.ToArray();
                    return entries;
                }
            }
            catch
            { }
            return new Entry[] { };
        }

        /// <summary>
        /// Naudotojo kortelės nuskaitymo įvykio gavimas pagal įvykio ID.
        /// </summary>
        /// <param name="id">Įvykio ID</param>
        /// <returns>Naudotojo kortelės nuskaitymo įvykis</returns>
        [Route("api/entries/{id}")]
        [HttpGet]
        [AuthenticationController]
        public Entry Get(int id)
        {
            try
            {
                using (dlssdbEntities db = new dlssdbEntities())
                {
                    Entry entriy = db.Entries.Where(x => x.id == id).FirstOrDefault();
                    return entriy;
                }
            }
            catch
            { }
            return new Entry { };
        }
    }
}
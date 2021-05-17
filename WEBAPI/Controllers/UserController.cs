using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using WEBAPI.Models;

namespace WEBAPI.Controllers
{
    /// <summary>
    /// Naudotojų duomenų sąrašo prieigos kontrolės klasė.
    /// </summary>
    public class UserController : ApiController
    {
        /// <summary>
        /// Naudotojų duomenų sąrašo gavimas.
        /// </summary>
        /// <returns>Naudotojų duomenų sąrašas</returns>
        [Route("api/users")]
        [HttpGet]
        [AuthenticationController]
        public IEnumerable<User> Get()
        {
            try
            {
                using (dlssdbEntities db = new dlssdbEntities())
                {
                    User[] users = db.Users.ToArray();
                    return users;
                }
            }
            catch
            { }
            return new User[] { };
        }

        /// <summary>
        /// Naudotojų duomenų gavimas pagal naudotojo ID.
        /// </summary>
        /// <param name="id">Naudotojo ID</param>
        /// <returns>Naudotojų duomenys</returns>
        [Route("api/users/{id}")]
        [HttpGet]
        [AuthenticationController]
        public User Get(int id)
        {
            try
            {
                using (dlssdbEntities db = new dlssdbEntities())
                {
                    User user = db.Users.Where(x => x.id == id).FirstOrDefault();
                    return user;
                }
            }
            catch
            { }
            return new User { };
        }
    }
}
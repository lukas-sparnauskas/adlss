using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using WEBAPI.Models;

namespace WEBAPI.Controllers
{
    /// <summary>
    /// WEB API autentifikacijos kontrolės klasė.
    /// </summary>
    public class AuthenticationController : AuthorizationFilterAttribute, IHttpModule
    {
        private const string Realm = "WEB API";

        /// <summary>
        /// WEB API autorizacijos kontrolės inicializavimas.
        /// </summary>
        public void Init(HttpApplication context)
        {
            context.AuthenticateRequest += OnApplicationAuthenticateRequest;
            context.EndRequest += OnApplicationEndRequest;
        }

        /// <summary>
        /// WEB API naudotojo nustatymas.
        /// </summary>
        /// <param name="principal">Naudotojas</param>
        private static void SetPrincipal(IPrincipal principal)
        {
            Thread.CurrentPrincipal = principal;
            if (HttpContext.Current != null)
            {
                HttpContext.Current.User = principal;
            }
        }

        /// <summary>
        /// Naudotojo prisijungimo duomenų patikrinimas duomenų bazėje.
        /// </summary>
        /// <param name="username">Naudotojo prisijungimo vardas</param>
        /// <param name="password">Naudotojo slaptažodis</param>
        /// <returns>True - naudotojo duomenys teisingi, false - naudotojo duomenys neteisingi.</returns>
        private static bool CheckPassword(string username, string password)
        {
            try
            {
                using (dlssdbEntities db = new dlssdbEntities())
                {
                    User user = db.Users.Where(x => x.username == username).FirstOrDefault();
                    if (user == null) return false;
                    return BCrypt.Net.BCrypt.EnhancedVerify(password, user.password);
                }
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Gautų naudotojo duomenų patikrinimas ir apdorojimas.
        /// </summary>
        /// <param name="credentials">Naudotojo prisijungimo duomenys</param>
        private static void AuthenticateUser(string credentials)
        {
            try
            {
                var encoding = Encoding.GetEncoding("iso-8859-1");
                credentials = encoding.GetString(Convert.FromBase64String(credentials));

                int separator = credentials.IndexOf(':');
                string name = credentials.Substring(0, separator);
                string password = credentials.Substring(separator + 1);

                if (CheckPassword(name, password))
                {
                    var identity = new GenericIdentity(name);
                    SetPrincipal(new GenericPrincipal(identity, null));
                }
                else
                {
                    HttpContext.Current.Response.StatusCode = 403;
                }
            }
            catch (FormatException)
            {
                HttpContext.Current.Response.StatusCode = 403;
            }
        }

        /// <summary>
        /// WEB API autentifikacijos pareikalavimo apdorojimas.
        /// </summary>
        private static void OnApplicationAuthenticateRequest(object sender, EventArgs e)
        {
            var request = HttpContext.Current.Request;
            var authHeader = request.Headers["Authorization"];
            if (authHeader != null)
            {
                var authHeaderVal = AuthenticationHeaderValue.Parse(authHeader);

                if (authHeaderVal.Scheme.Equals("basic", StringComparison.OrdinalIgnoreCase) && authHeaderVal.Parameter != null)
                {
                    AuthenticateUser(authHeaderVal.Parameter);
                }
            }
        }

        /// <summary>
        /// Neteisingo prisijungimo duomenų apdorojimas.
        /// </summary>
        private static void OnApplicationEndRequest(object sender, EventArgs e)
        {
            var response = HttpContext.Current.Response;
            if (response.StatusCode == (int)HttpStatusCode.Forbidden)
            {
                response.Headers.Add("WWW-Authenticate", string.Format("Basic realm=\"{0}\"", Realm));
            }
        }

        /// <summary>
        /// Gautų prisijungimo duomenų apdorojimas.
        /// </summary>
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (actionContext.Request.Headers.Authorization == null)
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Forbidden);
                if (actionContext.Response.StatusCode == HttpStatusCode.Forbidden)
                {
                    actionContext.Response.Headers.Add("WWW-Authenticate", string.Format("Basic realm=\"{0}\"", Realm));
                }
            }
            else
            {
                AuthenticateUser(actionContext.Request.Headers.Authorization.Parameter);
            }
        }

        public void Dispose()
        {
        }
    }
}

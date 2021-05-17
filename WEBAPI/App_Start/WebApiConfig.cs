using System.Web.Http;
using WEBAPI.Controllers;

namespace WEBAPI
{
    /// <summary>
    /// WEB API konfigūracijos klasė.
    /// </summary>
    public static class WebApiConfig
    {
        /// <summary>
        /// WEB API konfigūracijos užregistravimas.
        /// </summary>
        /// <param name="config">WEB API konfigūracija</param>
        public static void Register(HttpConfiguration config)
        {
            config.Filters.Add(new AuthenticationController());
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DLSSWEBAPI",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}

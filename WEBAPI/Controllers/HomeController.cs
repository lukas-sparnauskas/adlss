using System.Web.Mvc;

namespace WEBAPI.Controllers
{
    /// <summary>
    /// WEB API pradinio puslapio kontrolės klasė.
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// WEB API pradinio puslapio rodymas.
        /// </summary>
        public ActionResult Index()
        {
            ViewBag.Title = "Automatinės darbo laiko sekimo sistemos WEB API";

            return View();
        }
    }
}

using System.Web.Mvc;

namespace MusicCatalogueWebApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Title = "About";

            return View();
        }
    }
}

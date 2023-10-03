using Microsoft.AspNetCore.Mvc;

namespace BlogSite.Demo.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

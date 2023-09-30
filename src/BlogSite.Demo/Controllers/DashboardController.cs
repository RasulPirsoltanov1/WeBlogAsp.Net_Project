using Microsoft.AspNetCore.Mvc;

namespace BlogSite.Demo.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

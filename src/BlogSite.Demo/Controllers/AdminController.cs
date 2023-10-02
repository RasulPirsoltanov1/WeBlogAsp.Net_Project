using Microsoft.AspNetCore.Mvc;

namespace BlogSite.Demo.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

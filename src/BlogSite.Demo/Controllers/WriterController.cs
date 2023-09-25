using Microsoft.AspNetCore.Mvc;

namespace BlogSite.Demo.Controllers
{
    public class WriterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace BlogSite.Demo.Controllers
{
    public class ErrorPageController : Controller
    {
        public IActionResult Error1(int code)
        {
            return View();
        }
    }
}

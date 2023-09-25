using BlogSite.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BlogSite.Demo.Controllers
{
    public class AboutController : Controller
    {
        IAboutService _aboutService;

		public AboutController(IAboutService aboutService)
		{
			_aboutService = aboutService;
		}

		public async Task<IActionResult> Index()
        {
            var about=(await _aboutService.GetAllAsync());
            return View(about[0]);
        }
    }
}

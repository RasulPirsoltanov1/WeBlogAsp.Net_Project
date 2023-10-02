using BlogSite.BusinessLayer.Abstract;
using BlogSite.EntityLayer.Concrete;
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
            List<About>? about=(await _aboutService.GetAllAsync());
            if (about != null && about.Count>0)
            {
                return View(about[0]);
            }
            return View();
        }
    }
}

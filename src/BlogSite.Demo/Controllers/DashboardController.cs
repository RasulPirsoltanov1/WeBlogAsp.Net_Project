using BlogSite.BusinessLayer.Abstract;
using BlogSite.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BlogSite.Demo.Controllers
{
    public class DashboardController : Controller
    {
        IBlogService _blogService;
        IWriterService _writerService;
        UserManager<AppUser> _userManager;

        public DashboardController(IBlogService blogService, IWriterService writerService, UserManager<AppUser> userManager)
        {
            _blogService = blogService;
            _writerService = writerService;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var writerId = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.v1 = _blogService.values.Count();
            ViewBag.v2 = _blogService.values.Where(x=>x.WriterId==1).Count();
            ViewBag.v3 = _blogService.values.Where(X=>X.CreateDate>DateTime.Now.AddDays(-7)).Count();
            return View();
        }
    }
}

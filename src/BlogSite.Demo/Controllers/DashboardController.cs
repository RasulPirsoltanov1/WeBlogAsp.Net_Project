using BlogSite.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BlogSite.Demo.Controllers
{
    public class DashboardController : Controller
    {
        IBlogService _blogService;
        IWriterService _writerService;

        public DashboardController(IBlogService blogService, IWriterService writerService)
        {
            _blogService = blogService;
            _writerService = writerService;
        }

        public async Task<IActionResult> Index()
        {
            var writerId = (await _writerService.GetByExpressionAsync(x=>x.Mail==User.Identity.Name))[0].Id;
            ViewBag.v1 = _blogService.values.Count();
            ViewBag.v2 = _blogService.values.Where(x=>x.WriterId==writerId).Count();
            ViewBag.v3 = _blogService.values.Where(X=>X.CreateDate>DateTime.Now.AddDays(-7)).Count();
            return View();
        }
    }
}

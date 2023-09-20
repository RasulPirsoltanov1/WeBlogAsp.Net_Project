using BlogSite.BusinessLayer.Abstract;
using BlogSite.DataAccessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BlogSite.Demo.Controllers
{
    public class BlogController : Controller
    {
        IBlogService _blogService;

        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _blogService.GetBlogsWithCategoryAsync());
        }
        public async Task<IActionResult> Detail(int id)
        {
            return View(await _blogService.GetByIdAsync(id));
        }
    }
}

using BlogSite.DataAccessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BlogSite.Demo.Controllers
{
    public class BlogController : Controller
    {
        IBlogRepository _blogRepository;

        public BlogController(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public async Task<IActionResult> IndexAsync()
        {
            return View(await _blogRepository.GetAllAsync());
        }
    }
}

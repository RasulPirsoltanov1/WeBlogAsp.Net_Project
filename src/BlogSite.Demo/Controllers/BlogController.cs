using BlogSite.BusinessLayer.Abstract;
using BlogSite.DataAccessLayer.Abstract;
using BlogSite.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogSite.Demo.Controllers
{
    [AllowAnonymous]
    public class BlogController : Controller
    {
        IBlogService _blogService;
        IWriterService _writerService;

        public BlogController(IBlogService blogService, IWriterService writerService)
        {
            _blogService = blogService;
            _writerService = writerService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _blogService.GetBlogsWithCategoryAsync());
        }
        public async Task<IActionResult> Detail(int id)
        {
            return View(await _blogService.GetBlogByIdWithCommentsAsync(id));
        }
        public async Task<IActionResult> BlogListByWriter(string email)
        {
            var writer = await _writerService.GetByExpressionAsync(x => x.Mail == email);
            if(writer.Count>0)
            {
                var blogs = await _blogService.values.Include(x => x.Category).Where(x => x.WriterId == writer[0].Id).ToListAsync();
                return View(blogs);
            }
            return View();
        }
    }
}

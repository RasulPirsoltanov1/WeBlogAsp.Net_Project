using BlogSite.BusinessLayer.Abstract;
using BlogSite.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogSite.Demo.ViewComponents.Writer
{
    public class WriterBlogsComponent : ViewComponent
    {
        IBlogService _blogService;
        UserManager<AppUser> _userManager;

        public WriterBlogsComponent(IBlogService blogService, UserManager<AppUser> userManager)
        {
            _blogService = blogService;
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync(int writerId)
        {

            var blogs = await _blogService.values.Take(3).OrderByDescending(x=>x.CreateDate).Include(x => x.Comments).ToListAsync();
            return View(blogs);
            //return View(new List<BlogSite.EntityLayer.Concrete.Blog>() { });
        }
    }
}

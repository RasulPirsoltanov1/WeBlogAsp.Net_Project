using BlogSite.BusinessLayer.Abstract;
using BlogSite.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogSite.Demo.ViewComponents.Writer
{
	public class WriterBlogsComponent: ViewComponent
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

            if (User?.Identity?.Name != null)
            {
                var user = await _userManager.FindByNameAsync(User?.Identity?.Name);
                if (user != null)
                {
                    var blogs = await _blogService.values.Where(x => x.WriterId == user.Id).ToListAsync();
                    return View(blogs);
                }
            }
            return View(new List<BlogSite.EntityLayer.Concrete.Blog>() { });
        }
	}
}

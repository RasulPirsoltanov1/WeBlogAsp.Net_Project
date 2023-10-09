using BlogSite.BusinessLayer.Abstract;
using BlogSite.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogSite.Demo.ViewComponents.Blog
{
    public class BlogListDashBoard : ViewComponent
    {
        IBlogService _blogService;
        IWriterService _writerService;
        UserManager<AppUser> _userManager;

        public BlogListDashBoard(IBlogService blogService, IWriterService writerService, UserManager<AppUser> userManager)
        {
            _blogService = blogService;
            _writerService = writerService;
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
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
//int writerId = (await _writerService.GetByExpressionAsync(x => x.Mail == User.Identity.Name))[0].Id;
//if (writerId == 0 || writerId == null)
//{
//    var blogs1 = await _blogService.values.OrderBy(x => x.CreateDate).Take(3).ToListAsync();
//    return View(blogs1);
//}
//var blogs = await _blogService.GetByExpressionAsync(x => x.WriterId == writerId);
//return View(blogs);
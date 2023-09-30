using BlogSite.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogSite.Demo.ViewComponents.Blog
{
    public class BlogListDashBoard : ViewComponent
    {
        IBlogService _blogService;
        IWriterService _writerService;

        public BlogListDashBoard(IBlogService blogService, IWriterService writerService)
        {
            _blogService = blogService;
            _writerService = writerService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            int writerId = (await _writerService.GetByExpressionAsync(x => x.Mail == User.Identity.Name))[0].Id;
            if (writerId == 0 || writerId == null)
            {
                var blogs1 = await _blogService.values.OrderBy(x => x.CreateDate).Take(3).ToListAsync();
                return View(blogs1);
            }
            var blogs = await _blogService.GetByExpressionAsync(x => x.WriterId == writerId);
            return View(blogs);
        }
    }
}

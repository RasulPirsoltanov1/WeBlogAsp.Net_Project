using BlogSite.BusinessLayer.Abstract;
using BlogSite.EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogSite.Demo.ViewComponents.Blog
{
    public class BlogCommentListComponent : ViewComponent
    {
        private readonly ICommentService _commentService;

        public BlogCommentListComponent(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int? id)
        {
            List<Comment> comments = await _commentService.values.Where(x => x.BlogId == id).Include(x => x.AppUser).ToListAsync();
            return View(comments);
        }
    }
}

using BlogSite.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogSite.Demo.Areas.Admin.ViewComponents.StatisticWidgets
{
    public class StatisticWidgets3 : ViewComponent
    {
        IBlogService _blogService;
        IContactService _contactService;
        ICommentService _commentService;

        public StatisticWidgets3(IBlogService blogService, IContactService contactService, ICommentService commentService)
        {
            _blogService = blogService;
            _contactService = contactService;
            _commentService = commentService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            ViewBag.LastBlogName = (await _blogService.values.Include(x => x.Category).OrderByDescending(p => p.CreateDate).LastOrDefaultAsync());
            ViewBag.Messages = _contactService.values.Count();
            ViewBag.Comments = _commentService.values.Count();
            return View();
        }
    }

}

using BlogSite.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BlogSite.Demo.Controllers
{
	public class CommentController : Controller
	{
		IBlogService _blogService;

        public CommentController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public IActionResult Index()
		{
			return View();
		}
		public PartialViewResult PartialViewAddComment()
		{
			return PartialView();
		}
		public async Task<PartialViewResult> PartialViewCommentListAsync()
		{
			return PartialView(await _blogService.GetBlogByIdWithCommentsAsync(ViewBag.id));
		}
	}
}

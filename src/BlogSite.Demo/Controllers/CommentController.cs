using BlogSite.BusinessLayer.Abstract;
using BlogSite.EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace BlogSite.Demo.Controllers
{
	public class CommentController : Controller
	{
		IBlogService _blogService;
		ICommentService _commentService;
        public CommentController(IBlogService blogService, ICommentService commentService)
        {
            _blogService = blogService;
            _commentService = commentService;
        }

        public IActionResult Index()
		{
			return View();
		}
		[HttpGet]
		public PartialViewResult PartialViewAddComment()
		{
			return PartialView();
		}
        [HttpPost]
        public async Task<IActionResult> PartialViewAddComment(Comment comment)
        {
            await _commentService.AddAsync(comment);
            return RedirectToAction("Detail", "Blog", new {Id=comment.BlogId});
        }
        public async Task<PartialViewResult> PartialViewCommentListAsync()
		{
			return PartialView(await _blogService.GetBlogByIdWithCommentsAsync(ViewBag.id));
		}
	}
}

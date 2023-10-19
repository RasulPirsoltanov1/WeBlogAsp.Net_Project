using BlogSite.BusinessLayer.Abstract;
using BlogSite.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogSite.Demo.Controllers
{
	public class CommentController : Controller
	{
		IBlogService _blogService;
		ICommentService _commentService;
		UserManager<AppUser> _userManager;
        public CommentController(IBlogService blogService, ICommentService commentService, UserManager<AppUser> userManager)
        {
            _blogService = blogService;
            _commentService = commentService;
            _userManager = userManager;
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
			var user = await _userManager.FindByNameAsync(User.Identity.Name);
			if(user == null)
			{
                return RedirectToAction("Detail", "Blog", new { Id = comment.BlogId });
            }
			comment.AppUser = user;
			comment.UserName= user.UserName;
            await _commentService.AddAsync(comment);
            return RedirectToAction("Detail", "Blog", new {Id=comment.BlogId});
        }
        public async Task<PartialViewResult> PartialViewCommentListAsync()
		{
		
            return PartialView(await _blogService.GetBlogByIdWithCommentsAsync(ViewBag.id));
        }
	}
}

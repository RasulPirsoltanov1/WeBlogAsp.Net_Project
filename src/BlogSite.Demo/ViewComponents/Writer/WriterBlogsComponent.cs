using BlogSite.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BlogSite.Demo.ViewComponents.Writer
{
	public class WriterBlogsComponent: ViewComponent
	{
		IBlogService _blogService;

        public WriterBlogsComponent(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int writerId)
		{
			var blogs = await _blogService.GetByExpressionAsync(x=>x.WriterId==writerId);
			return View(blogs);
		}
	}
}

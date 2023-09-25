using BlogSite.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
			if(writerId == 0 || writerId==null) {
				var blogs1 = await _blogService.values.OrderBy(x=>x.CreateDate).Take(3).ToListAsync();
				return View(blogs1);
			}
			var blogs = await _blogService.GetByExpressionAsync(x=>x.WriterId==writerId);
			return View(blogs);
		}
	}
}

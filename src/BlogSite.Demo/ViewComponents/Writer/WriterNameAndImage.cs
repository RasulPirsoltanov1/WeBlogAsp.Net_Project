using BlogSite.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BlogSite.Demo.ViewComponents.Writer
{
    public class WriterNameAndImage : ViewComponent
    {
        IWriterService _writerService;

        public WriterNameAndImage(IWriterService writerService)
        {
            _writerService = writerService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var writer = (await _writerService.GetByExpressionAsync(x => x.Mail == User.Identity.Name))[0];
            return View(writer);
        }
    }
}

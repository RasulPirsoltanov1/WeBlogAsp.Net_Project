using BlogSite.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogSite.Demo.ViewComponents.Writer
{
    public class DashboardAboutWriter:ViewComponent
    {
        IWriterService _writerService;

        public DashboardAboutWriter(IWriterService writerService)
        {
            _writerService = writerService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var writer = (await _writerService.values.Include(x=>x.Country).Where(x=>x.Mail==User.Identity.Name).ToListAsync())[0];
            return View(writer);
        }
    }
}

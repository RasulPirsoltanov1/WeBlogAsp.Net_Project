using Microsoft.AspNetCore.Mvc;

namespace BlogSite.Demo.ViewComponents.Writer
{
    public class WriterNotification:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

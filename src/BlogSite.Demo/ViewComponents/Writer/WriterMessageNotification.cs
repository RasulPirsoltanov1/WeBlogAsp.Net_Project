using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace BlogSite.Demo.ViewComponents.Writer
{
    public class WriterMessageNotification:ViewComponent
    {
         public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

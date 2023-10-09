using BlogSite.BusinessLayer.Abstract;
using BlogSite.EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace BlogSite.Demo.ViewComponents.Writer
{
    public class WriterNotification:ViewComponent
    {
        INotificationService _notificationService;

        public WriterNotification(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            //var notifications= await _notificationService.GetAllAsync();
            return View(new List<Notification>
            {

            });
        }
    }
}

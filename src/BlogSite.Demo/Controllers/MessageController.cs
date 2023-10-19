using BlogSite.BusinessLayer.Abstract;
using BlogSite.Demo.Models;
using BlogSite.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogSite.Demo.Controllers
{
    public class MessageController : Controller
    {
        IMessage2Service _message2Service;
        UserManager<AppUser> _userManager;

        public MessageController(IMessage2Service message2Service, UserManager<AppUser> userManager)
        {
            _message2Service = message2Service;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var messsages2 = await _message2Service.values.Include(x => x.Reciever).Include(x => x.Sender).Where(x => x.Reciever.UserName == User.Identity.Name).ToListAsync();
            ViewBag.Count = messsages2.Count;
            return View(messsages2);
        }
        public async Task<IActionResult> Detail(int Id)
        {
            var messsage2 = await _message2Service.values.Include(x => x.Reciever).Include(x => x.Sender).FirstOrDefaultAsync(x => x.Reciever.UserName == User.Identity.Name && x.Id == Id);
            return View(messsage2);
        }
        public IActionResult SendMessage()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SendMessage(MailVM mailVM)
        {
            try
            {
                var userReceiver = await _userManager.FindByEmailAsync(mailVM.Email);
                var userSender = await _userManager.FindByNameAsync(User?.Identity?.Name);
                await _message2Service.AddAsync(new Message2
                {
                    RecieverId = userReceiver.Id,
                    Status = true,
                    Subject = mailVM.Subject ?? "Empty",
                    Details = mailVM.Content ?? "Empty",
                    SenderId = userSender.Id
                });
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return RedirectToAction(nameof(Index));
            }
        }
    }
}

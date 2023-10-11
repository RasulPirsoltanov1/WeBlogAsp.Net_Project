using BlogSite.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogSite.Demo.Areas.Admin.Controllers
{
    [Area("admin")]
    [Authorize(Roles = "Admin")]

    [Route("[area]/[controller]/[action]")]
    public class RoleController : Controller
    {
        RoleManager<AppRole> _roleManager;
        UserManager<AppUser> _userManager;
        public RoleController(RoleManager<AppRole> roleManager, UserManager<AppUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _roleManager.Roles.ToListAsync());
        }
        public async Task<IActionResult> Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(AppRole appRole)
        {
            await _roleManager.CreateAsync(appRole);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int Id)
        {
            var role = await _roleManager.Roles.FirstOrDefaultAsync(x => x.Id == Id);
            if (role != null)
                await _roleManager.DeleteAsync(role);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Update(int Id)
        {
            var role = await _roleManager.Roles.FirstOrDefaultAsync(x => x.Id == Id);
            return View(role);
        }
        [HttpPost]
        public async Task<IActionResult> Update(AppRole appRole)
        {
            var role = await _roleManager.Roles.FirstOrDefaultAsync(x => x.Id == appRole.Id);
            role.Name = appRole.Name;
            await _roleManager.UpdateAsync(role);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> UserRoleList()
        {
            var roles=await _userManager.Users.ToListAsync();
            return View(roles);
        }
        public async Task<IActionResult> AddUserRole(int Id)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == Id);
            ViewBag.Roles = await _roleManager.Roles.ToListAsync();
            return View(user);
        }
        [HttpPost]
        public async Task<IActionResult> AddUserRolePost(int UserId,int RoleId)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == UserId);
            var role=await _roleManager.Roles.FirstOrDefaultAsync(x=>x.Id== RoleId);
            await _userManager.AddToRoleAsync(user, role.Name);
            return RedirectToAction(nameof(UserRoleList));
        }
        public async Task<IActionResult> RemoveUserRole(int Id)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == Id);
            ViewBag.Roles = await _userManager.GetRolesAsync(user);
            return View(user);
        }
        [HttpPost]
        public async Task<IActionResult> RemoveUserRolePost(int UserId, string RoleName)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == UserId);
            var role = await _roleManager.Roles.FirstOrDefaultAsync(x => x.Name == RoleName);
            await _userManager.RemoveFromRoleAsync(user, role.Name);
            return RedirectToAction(nameof(UserRoleList));
        }
    }
}

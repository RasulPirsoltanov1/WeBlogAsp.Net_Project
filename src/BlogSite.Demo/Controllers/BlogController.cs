using BlogSite.BusinessLayer.Abstract;
using BlogSite.BusinessLayer.Extensions;
using BlogSite.DataAccessLayer.Abstract;
using BlogSite.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogSite.Demo.Controllers
{
   
    public class BlogController : Controller
    {
        IBlogService _blogService;
        ICategoryService _categoryService;
        IWriterService _writerService;
        UserManager<AppUser> _userManager;
        ICommentService _commentService;
        public BlogController(IBlogService blogService, IWriterService writerService, ICategoryService categoryService, UserManager<AppUser> userManager, ICommentService commentService)
        {
            _blogService = blogService;
            _writerService = writerService;
            _categoryService = categoryService;
            _userManager = userManager;
            _commentService = commentService;
        }
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            return View(await _blogService.GetBlogsWithCategoryAsync());
        }
        [AllowAnonymous]
        public async Task<IActionResult> Detail(int id)
        {
            return View(await _blogService.GetBlogByIdWithCommentsAsync(id));
          
        }
        public async Task<IActionResult> BlogListByWriter(string? email)
        {
            var writer = await _userManager.FindByNameAsync(User.Identity.Name);
            if (writer!=null)
            {
                var blogs = await _blogService.values.Include(x => x.Category).Where(x => x.WriterId == writer.Id).ToListAsync();
                return View(blogs);
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            ViewBag.Categories = await _categoryService.GetAllAsync();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(Blog blog, IFormFile formFile)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (formFile != null)
                    {
                        blog.Image = await formFile.UploadFileToAsync("blog", "image");
                    }
                    var writer = await _userManager.FindByNameAsync(User.Identity.Name);
                    if (writer!=null)
                    {
                        blog.WriterId = writer.Id;
                    }
                    else
                    {
                        blog.WriterId = null;
                    }
                    blog.Status = true;
                    await _blogService.AddAsync(blog);
                    return RedirectToAction("BlogListByWriter", "Blog", new { email = User.Identity.Name });
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
            }
            ViewBag.Categories = await _categoryService.GetAllAsync();
            return View();
        }
        public async Task<IActionResult> Delete(int Id, string email)
        {
            try
            {
                await IFormFileExtension.DeleteFileAsync((await _blogService.GetByIdAsync(Id)).Image);
                await _blogService.DeleteAsync(Id);
                return RedirectToAction(nameof(BlogListByWriter), new { email = email });
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<IActionResult> Edit(int Id)
        {
            ViewBag.Categories = await _categoryService.GetAllAsync();
            var blog = await _blogService.GetByIdAsync(Id);
            return View(blog);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Blog blog, IFormFile formFile)
        {
            ViewBag.Categories = await _categoryService.GetAllAsync();
            var dbblog = await _blogService.GetByIdAsync(blog.Id);
            dbblog.Title = blog.Title;
            dbblog.Content = blog.Content;
            dbblog.CategoryId = blog.CategoryId;
            if (formFile != null)
            {
                await IFormFileExtension.DeleteFileAsync(dbblog.Image??"");
                dbblog.Image = await formFile.UploadFileToAsync("blog", "image");
            }

            await _blogService.UpdateAsync(dbblog);
            return RedirectToAction("BlogListByWriter", "Blog", new { email = User.Identity?.Name });
        }
    }
}

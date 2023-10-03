using BlogSite.BusinessLayer.Abstract;
using BlogSite.EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using X.PagedList;

namespace BlogSite.Demo.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("[area]/[controller]/[action]")]
    public class CategoryController : Controller
    {
        ICategoryService _categoryService;
        IBlogService _blogService;

        public CategoryController(ICategoryService categoryService, IBlogService blogService)
        {
            _categoryService = categoryService;
            _blogService = blogService;
        }

        public async Task<IActionResult> Index(int? page)
        {
            page = page ?? 1;
            var categories = await _categoryService.values.Include(x => x.Blogs).ToPagedListAsync(page, 4);
            return View(categories);
        }
        public async Task<IActionResult> Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(Category category)
        {
            if (ModelState.IsValid)
            {
                await _categoryService.AddAsync(category);
                return RedirectToAction("Index", "Category");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int Id)
        {
            //var category=await _categoryService.values.Include(x=>x.Blogs).FirstOrDefaultAsync(x => x.Id == Id);
            //var blogs=category.Blogs;
            //if (blogs != null && blogs.Count() > 0)
            //{
            //    foreach (var item in blogs)
            //    {
            //       item.CategoryId= null;
            //    }
            //}
            await _categoryService.DeleteAsync(Id);
            return RedirectToAction("Index", "Category");
        }
        public async Task<IActionResult> ChangeStatus(int Id)
        {
            var category = await _categoryService.GetByIdAsync(Id);
            if (category != null)
            {
                if (category.Status != null)
                {
                    category.Status = !category.Status;
                }
                else
                {
                    category.Status = true;
                }
                await _categoryService.UpdateAsync(category);
            }
            return RedirectToAction("Index", "Category");
        }
    }
}

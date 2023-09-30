using BlogSite.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogSite.Demo.ViewComponents.Category
{
    public class CategoryListDasboard:ViewComponent
    {
        ICategoryService _categoryService;

        public CategoryListDasboard(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categories =await _categoryService.values.Include(x=>x.Blogs).ToListAsync();
            return View(categories);
        }
    }
}

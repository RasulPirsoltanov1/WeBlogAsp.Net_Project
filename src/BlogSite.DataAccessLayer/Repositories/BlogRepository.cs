using BlogSite.DataAccessLayer.Abstract;
using BlogSite.DataAccessLayer.Context;
using BlogSite.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace BlogSite.DataAccessLayer.Repositories
{
    public class BlogRepository : GenericRepository<Blog>, IBlogRepository
    {
        private readonly AppDbContext _dbContext;
        public BlogRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            _dbContext = appDbContext;
        }

        public async Task<List<Blog>> GetListWithCategoryAsync()
        {
            return await _dbContext.Blogs.Include(b=>b.Category).ToListAsync();
        }
    }
}

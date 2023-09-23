using BlogSite.DataAccessLayer.Abstract;
using BlogSite.DataAccessLayer.Context;
using BlogSite.EntityLayer.Concrete;

namespace BlogSite.DataAccessLayer.Repositories
{
    public class NewsLetterRepository : GenericRepository<NewsLetter>, INewsLetterRepository
    {
        public NewsLetterRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}

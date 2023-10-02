using BlogSite.DataAccessLayer.Abstract;
using BlogSite.DataAccessLayer.Context;
using BlogSite.EntityLayer.Concrete;

namespace BlogSite.DataAccessLayer.Repositories
{
    public class Message2Repository : GenericRepository<Message2>, IMessage2Repository
    {
        public Message2Repository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}

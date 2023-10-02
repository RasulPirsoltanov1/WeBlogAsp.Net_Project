using BlogSite.DataAccessLayer.Abstract;
using BlogSite.DataAccessLayer.Context;
using BlogSite.EntityLayer.Concrete;

namespace BlogSite.DataAccessLayer.Repositories
{
    public class MessageRepository : GenericRepository<Message>, IMessageRepository
    {
        public MessageRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}

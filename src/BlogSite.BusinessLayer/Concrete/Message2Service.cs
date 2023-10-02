using BlogSite.BusinessLayer.Abstract;
using BlogSite.DataAccessLayer.Abstract;
using BlogSite.EntityLayer.Concrete;

namespace BlogSite.BusinessLayer.Concrete
{
    public partial class AboutService
    {
        public class Message2Service : GenericService<Message2>, IMessage2Service
        {
            public Message2Service(IMessage2Repository repository) : base(repository)
            {
            }
        }
    }
}

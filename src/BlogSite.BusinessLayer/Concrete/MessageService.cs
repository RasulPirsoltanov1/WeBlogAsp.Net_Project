using BlogSite.BusinessLayer.Abstract;
using BlogSite.DataAccessLayer.Abstract;
using BlogSite.EntityLayer.Concrete;

namespace BlogSite.BusinessLayer.Concrete
{
    public partial class AboutService
    {
        public class MessageService : GenericService<Message>, IMessageService
        {
            public MessageService(IMessageRepository repository) : base(repository)
            {
            }
        }
    }
}

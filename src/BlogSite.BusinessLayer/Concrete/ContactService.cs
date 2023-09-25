using BlogSite.BusinessLayer.Abstract;
using BlogSite.DataAccessLayer.Abstract;
using BlogSite.EntityLayer.Concrete;

namespace BlogSite.BusinessLayer.Concrete
{
	public class ContactService : GenericService<Contact>, IContactService
	{
		public ContactService(IContactRepository repository) : base(repository)
		{
		}
	}
}

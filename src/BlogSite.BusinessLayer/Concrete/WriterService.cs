using BlogSite.BusinessLayer.Abstract;
using BlogSite.DataAccessLayer.Abstract;
using BlogSite.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.BusinessLayer.Concrete
{
	public class WriterService : GenericService<Writer>, IWriterService
	{
		public WriterService(IWriterRepository repository) : base(repository)
		{
		}
	}
}

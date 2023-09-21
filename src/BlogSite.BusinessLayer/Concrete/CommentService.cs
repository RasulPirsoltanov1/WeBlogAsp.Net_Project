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
	public class CommentService : GenericService<Comment>, ICommentService
	{
		public CommentService(ICommentRepository repository) : base(repository)
		{
		}
	}
}

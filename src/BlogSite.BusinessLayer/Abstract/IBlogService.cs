﻿using BlogSite.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.BusinessLayer.Abstract
{
    public interface IBlogService:IGenericService<Blog>
    {
        Task<List<Blog>> GetBlogsWithCategoryAsync();
        Task<Blog> GetBlogByIdWithCommentsAsync(int id);
    }
}

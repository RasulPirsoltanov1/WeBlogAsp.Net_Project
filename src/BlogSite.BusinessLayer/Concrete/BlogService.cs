﻿using BlogSite.BusinessLayer.Abstract;
using BlogSite.DataAccessLayer.Abstract;
using BlogSite.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.BusinessLayer.Concrete
{
    public class BlogService : GenericService<Blog>, IBlogService
    {
        IBlogRepository _blogRepository;
        public BlogService(IBlogRepository repository) : base(repository)
        {
            _blogRepository = repository;
        }

        public Task<Blog> GetBlogByIdWithCommentsAsync(int id)
        {
            return _blogRepository.GetBlogByIdWithCommentsAsync(id);
        }

        public async Task<List<Blog>> GetBlogsWithCategoryAsync()
        {
            return await _blogRepository.GetListWithCategoryAsync();
        }
    }
}

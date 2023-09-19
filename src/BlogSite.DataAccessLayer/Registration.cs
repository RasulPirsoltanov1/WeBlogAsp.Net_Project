using BlogSite.DataAccessLayer.Abstract;
using BlogSite.DataAccessLayer.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.DataAccessLayer
{
    public static class Registration
    {
        public static IServiceCollection DataAccessLayerRegistration(this IServiceCollection services)
        {
            services.AddScoped<IAboutRepository, AboutRepository>();
            services.AddScoped<IBlogRepository, BlogRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICommentRepository, CommentRepository>();
            services.AddScoped<IContactRepository, ContactRepository>();
            services.AddScoped<IWriterRepository, WriterRepository>();
            return services;
        }
    }
}

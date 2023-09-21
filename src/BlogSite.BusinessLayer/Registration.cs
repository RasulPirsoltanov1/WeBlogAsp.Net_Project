﻿using BlogSite.BusinessLayer.Abstract;
using BlogSite.BusinessLayer.Concrete;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.BusinessLayer
{
    public static class Registration
    {
        public static IServiceCollection BusinessLayerRegistration(this IServiceCollection services)
        {
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IBlogService, BlogService>();
            return services;
        }
    }
}
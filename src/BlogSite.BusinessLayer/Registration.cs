using BlogSite.BusinessLayer.Abstract;
using BlogSite.BusinessLayer.Concrete;
using BlogSite.BusinessLayer.Validation.WriterValidate;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BlogSite.BusinessLayer.Concrete.AboutService;

namespace BlogSite.BusinessLayer
{
    public static class Registration
    {
        public static IServiceCollection BusinessLayerRegistration(this IServiceCollection services)
        {
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IBlogService, BlogService>();
            services.AddScoped<IWriterService, WriterService>();
            services.AddScoped<ICountryService, CountryService>();
            services.AddScoped<INewsLetterService, NewsLetterService>();
            services.AddScoped<ICommentService, CommentService>();
            services.AddScoped<IAboutService, AboutService>();
            services.AddScoped<IContactService, ContactService>();
            services.AddScoped<INotificationService, NotificationService>();
            services.AddScoped<IMessageService, MessageService>();
            services.AddScoped<IMessage2Service, Message2Service>();
            services.AddScoped<IAdminService, AdminService>();
            services.AddFluentValidationAutoValidation();
			services.AddFluentValidationClientsideAdapters();
			services.AddValidatorsFromAssembly(typeof(WriterValidator).Assembly);
			return services;
        }
    }
}

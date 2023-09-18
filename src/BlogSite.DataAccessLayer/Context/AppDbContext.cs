using BlogSite.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.DataAccessLayer.Context
{
    public class AppDbContext : DbContext
    {
        //private readonly IConfiguration _configuration;

        //public AppDbContext(IConfiguration configuration)
        //{
        //    _configuration = configuration;
        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-UGCLLOE\\MSSQLSERVER2; Database=CoreBlogDb; Integrated security=true;");
        }

        public DbSet<About> Abouts { get; set; }
        public DbSet<Blog>  Blogs{ get; set; }
        public DbSet<Category> Categories{ get; set; }
        public DbSet<Comment>  Comments{ get; set; }
        public DbSet<Contact> Contacts{ get; set; }
        public DbSet<Writer>  Writers{ get; set; }
    }
}

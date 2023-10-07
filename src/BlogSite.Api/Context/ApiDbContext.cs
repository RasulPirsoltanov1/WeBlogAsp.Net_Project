using BlogSite.Api.Context.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BlogSite.Api.Context
{
    public class ApiDbContext:DbContext
    {
        private readonly IConfiguration _configuration;

        public ApiDbContext(DbContextOptions options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("Default"));
        }
        public DbSet<Employee>  Employees{ get; set; }
    }
}

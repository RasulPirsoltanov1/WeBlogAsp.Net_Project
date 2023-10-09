using BlogSite.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.DataAccessLayer.Context
{
    public class AppDbContext : IdentityDbContext<AppUser,AppRole,int>
    {
        private readonly IConfiguration _configuration;

        public AppDbContext(DbContextOptions options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("Default"));
        }

        public DbSet<About> Abouts { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Writer> Writers { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<NewsLetter> NewsLetters { get; set; }
        public DbSet<BlogRaiting> BlogRaitings { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Message2> Message2s { get; set; }
        public DbSet<Admin>  Admins{ get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Message2>().HasOne(m => m.Sender)
                .WithMany(s => s.SendMessages)
                .HasForeignKey(m => m.SenderId)
                .OnDelete(deleteBehavior: DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<Message2>().HasOne(m => m.Reciever)
                .WithMany(s => s.RecieveMessages)
                .HasForeignKey(m => m.RecieverId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<Blog>().HasOne(x => x.Category)
                .WithMany(x=>x.Blogs)
                .HasForeignKey(x=>x.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }



        public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            // get changed or added entries 
            var entries = ChangeTracker.Entries().Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);

            foreach (var entry in entries)
            {
                if (entry.Entity is BaseEntity baseEntity)
                {
                    if (entry.State == EntityState.Added)
                    {
                        baseEntity.CreateDate = DateTime.Now;
                    }
                    else if (entry.State == EntityState.Modified)
                    {
                        baseEntity.UpdateDate = DateTime.Now;
                    }
                }
            }
            // save changes
            return await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
    }
}

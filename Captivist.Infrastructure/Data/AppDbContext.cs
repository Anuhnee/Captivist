using Captivist.Core.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Captivist.Infrastructure.Data
{
    public class AppDbContext : IdentityDbContext
    {
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = /C:/Users/Anthony/Documents/DevFolder/Captivist/CaptivistApp/Captivist.Infrastructure/captivist.db");
        }
    }
}
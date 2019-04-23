using DMD.Test.Models.Identity;
using DMD.Test.Models.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DMD.Test.Models
{
    public class MainContext : IdentityDbContext<User, Role, int>
    {
        public MainContext(DbContextOptions<MainContext> options)
            : base(options)
        { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Category>().HasMany(x => x.Products).WithOne(x => x.Category);
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                builder.UseSqlServer(ConnectionStringInfo.DataContextConnectionString);
            }

            base.OnConfiguring(builder);
        }
    }
}

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using test8.Areas.Identity.Data;
using test8.Models;


namespace test8.Areas.Identity.Data
{
    public class AppDbContext : IdentityDbContext<test8User>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Product>()
                .HasOne(p => p.User)
                .WithMany()
                .HasForeignKey(p => p.UserId);

            builder.Entity<Product>()
             .Property(p => p.Id)
             .ValueGeneratedOnAdd();
        }

        public DbSet<Product> Products { get; set; }
    }
}


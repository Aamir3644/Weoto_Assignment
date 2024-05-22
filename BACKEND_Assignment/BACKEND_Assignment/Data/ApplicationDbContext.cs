using BACKEND_Assignment.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BACKEND_Assignment.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<Product> Product { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.UserName).IsRequired();
                entity.Property(e => e.Password).IsRequired();
                entity.Property(e => e.Role).IsRequired();
                entity.Property(e => e.MobileNumber).IsRequired();
                entity.HasIndex(e => e.MobileNumber).IsUnique();
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Name).IsRequired();
                entity.Property(e => e.Price).IsRequired();
            });

            // Adding 1 Admin User at the start
            var adminUser = new User
            {
                Id = 1,
                UserName = "admin",
                Password = BCrypt.Net.BCrypt.HashPassword("Admin@123"),
                Role = "Admin",
                MobileNumber = "8456457899"
            };

            modelBuilder.Entity<User>().HasData(adminUser);
        }
    }
}

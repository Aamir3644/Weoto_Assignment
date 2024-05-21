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
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Name).IsRequired();
                entity.Property(e => e.Price).IsRequired();
            });

            // Seed admin user
            var adminUser = new User
            {
                Id = 1,
                UserName = "admin",
                Password = BCrypt.Net.BCrypt.HashPassword("Admin@123"), // Use a secure password
                Role = "Admin"
            };

            modelBuilder.Entity<User>().HasData(adminUser);
        }
    }
}

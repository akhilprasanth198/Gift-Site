using Microsoft.EntityFrameworkCore;
using Gift_Site.Models;

namespace Gift_Site.GiftStoreDbContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // DbSet properties map models to database tables
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Cart> Cart { get; set; }
        public DbSet<Payment> Payments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //    // Seed Users
            //    modelBuilder.Entity<User>().HasData(
            //        //new User { Id = 1, UserName = "admin", Email = "admin@gmail.com", MobileNo = "1234567890", Password = "admin" ,Role="Admin" },
            //        new User { Id = 2, UserName = "john.doe", Email = "john@egmail.com", MobileNo = "1234567890", Password = "password123", Role = "User" },

            //        new User { Id = 2, UserName = "jane.doe", Email = "jane@gmail.com", MobileNo = "9876543210", Password = "password123" , Role = "User" }
            //    );

            // Seed Products
            modelBuilder.Entity<Product>().HasData(
                new Product { ProductId = 1, ProductName = "Gift Basket", Description = "A beautiful gift basket", Quantity = 10, Rate = 25.99M },
                new Product { ProductId = 2, ProductName = "Birthday Cake", Description = "Delicious birthday cake", Quantity = 5, Rate = 15.99M },
                new Product { ProductId = 3, ProductName = "Teddy Bear", Description = "Soft teddy bear for all ages", Quantity = 8, Rate = 19.99M }
            );

            // Seed Orders (can be customized as per your requirements)
            modelBuilder.Entity<Order>().HasData(
                new Order { OrderId = 1, TotalRate = 41.98M, UserId = 1, Status = "Pending", CreatedAt = DateTime.Now }
            );

            // Seed Cart (example for a product in the cart)
            modelBuilder.Entity<Cart>().HasData(
                new Cart { CartId = 1, ProductId = 1, OrderId = 1, Quantity = 1, TotalPrice = 25.99M }
            );
        
    }
    }
}

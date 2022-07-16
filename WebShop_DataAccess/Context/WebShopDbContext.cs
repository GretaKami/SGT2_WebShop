using Microsoft.EntityFrameworkCore;
using WebShop_DataAccess.Context.Entities;

namespace WebShop_DataAccess.Context
{
    public class WebShopDbContext : DbContext
    {
        public WebShopDbContext(DbContextOptions<WebShopDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Subcategory> Subcategories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> Cart_Items { get; set; }
        public DbSet<Order> Orders { get; set; }


    }
}

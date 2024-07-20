using Microsoft.EntityFrameworkCore;

namespace Kookis.Models
{
    public class KookisDbContext : DbContext
    {
        public KookisDbContext(DbContextOptions<KookisDbContext>
            options) : base(options) 
        { 
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Pie> Pies { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrdersDetail { get; set; }

    }
}

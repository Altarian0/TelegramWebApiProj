using Microsoft.EntityFrameworkCore;

namespace TelegramWebApiProj.Models
{
    public class OrderContext : DbContext
    {
        public DbSet<ExtendedOrder> ExtendedOrders { get; set; }
        public DbSet<User> Users { get; set; }

        public OrderContext(DbContextOptions<OrderContext> options)
            : base(options)
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();   // создаем базу данных при первом обращении
        }
    }
}

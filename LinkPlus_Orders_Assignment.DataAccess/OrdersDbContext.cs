using LinkPlus_Orders_Assignment.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LinkPlus_Orders_Assignment.DataAccess
{
    public class OrdersDbContext : DbContext
    {
        public OrdersDbContext(DbContextOptions<OrdersDbContext> options) : base(options) { }

        public DbSet<Order> Orders => Set<Order>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Order>()
                .Property(x => x.OrderName)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<Order>()
                .Property(x => x.OrderPrice)
                .IsRequired();

            modelBuilder.Entity<Order>()
                .Property(x => x.OrderDate)
                .IsRequired();



            modelBuilder.Entity<Order>()
                .HasData(
                    new Order
                    {
                        Id = 1,
                        OrderDate = DateTime.Now,
                        OrderName = "Order 1",
                        OrderPrice = 250
                    },
                    new Order
                    {
                        Id = 2,
                        OrderDate = DateTime.Now,
                        OrderName = "Order 2",
                        OrderPrice = 550
                    },
                    new Order
                    {
                        Id = 3,
                        OrderDate = DateTime.Now,
                        OrderName = "Order 2",
                        OrderPrice = 750
                    }
                );
        }
    }
}

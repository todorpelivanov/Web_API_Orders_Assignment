using LinkPlus_Orders_Assignment.DataAccess.Interfaces;
using LinkPlus_Orders_Assignment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkPlus_Orders_Assignment.DataAccess.Implementations
{
    public class OrderRepository : IRepository<Order>
    {
        private OrdersDbContext _OrdersDbContext;

        public OrderRepository(OrdersDbContext ordersDbContext)
        {
            _OrdersDbContext = ordersDbContext;
        }

        public void Add(Order entity)
        {
            _OrdersDbContext.Orders.Add(entity);
            _OrdersDbContext.SaveChanges();
        }

        public void Delete(Order entity)
        {
            _OrdersDbContext.Orders.Remove(entity);
            _OrdersDbContext.SaveChanges();
        }

        public IEnumerable<Order> GetAll()
        {
            return _OrdersDbContext.Orders;
        }

        public Order GetById(int id)
        {
            return _OrdersDbContext.Orders.SingleOrDefault(x => x.Id == id);
        }
    }
}

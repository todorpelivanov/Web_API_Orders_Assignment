using LinkPlus_Orders_Assignment.DataAccess.Interfaces;
using LinkPlus_Orders_Assignment.Domain.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkPlus_Orders_Assignment.Tests
{
    public class MockSetup
    {
        public static IRepository<Order> MockOrderRepository()
        {
            List<Order> orders = new List<Order>()
            {
                new Order()
                {
                    Id = 1,
                    OrderName = "Pizza",
                    OrderDate = DateTime.Now,
                    OrderPrice = 500
                },
                new Order()
                {
                    Id = 2,
                    OrderName = "Burger",
                    OrderDate = DateTime.Now,
                    OrderPrice = 300
                },
                new Order()
                {
                    Id = 3,
                    OrderName = "Burito",
                    OrderDate = DateTime.Now,
                    OrderPrice = 400
                }
            };

            var mockOrderRepository = new Mock<IRepository<Order>>();

            mockOrderRepository
                .Setup(x => x.GetAll())
                .Returns(orders);

            mockOrderRepository
                .Setup(x => x.Add(It.IsAny<Order>()))
                .Callback<Order>(order => orders.Add(order));


            mockOrderRepository
                .Setup(x => x.Delete(It.IsAny<Order>()))
                .Callback<Order>(order => orders.Remove(order));

            mockOrderRepository
                .Setup(x => x.GetById(It.IsAny<int>()))
                .Returns<int>(id => orders.SingleOrDefault(u => u.Id == id));

            return mockOrderRepository.Object;
        }
    }
}
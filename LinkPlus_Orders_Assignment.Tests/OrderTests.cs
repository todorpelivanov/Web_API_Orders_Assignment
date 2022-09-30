using LinkPlus_Orders_Assignment.Dtos.OrderDto;
using LinkPlus_Orders_Assignment.Services.Implementation;
using LinkPlus_Orders_Assignment.Services.Interface;
using LinkPlus_Orders_Assignment.Shared.OrdersException;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkPlus_Orders_Assignment.Tests
{
    [TestClass]
    public class OrderTests
    {
        private readonly IOrderService _orderService;
        public OrderTests()
        {
            _orderService = new OrderService(MockSetup.MockOrderRepository());
        }

        //get all orders
        [TestMethod]
        public void GetAllOrders_ReturnAllOrders_NoPaging() 
        {
            //Arrange
            var expectedResult = 3;

            //Act
            var result = _orderService.GetAllOrders(0, 0);

            //Assert
            Assert.AreEqual(expectedResult, result.Count);
        }

        [TestMethod]
        public void GetAllOrders_ReturnAllOrders_With_Paging()
        {
            //Arrange
            var page = 1;
            var pageSize = 2;

            //Act
            var result = _orderService.GetAllOrders(page, pageSize);

            //Assert
            Assert.AreEqual(pageSize, result.Count);
        }

        // add order
        [TestMethod]
        public void AddOrder_ValidOrder_OrderAdded()
        {
            //Arrange
            var expectedResult = 4;

            var order = new OrderDto
            {
                Id = 4,
                OrderDate = DateTime.Now,
                OrderName = "unit test order",
                OrderPrice = 200
            };

            //Act
            _orderService.AddOrder(order);

            //Assert
            var result = _orderService.GetAllOrders(0, 0);
            Assert.AreEqual(expectedResult, result.ToList().Count);
        }

        [TestMethod]
        public void AddOrder_InvalidOrderPrice_ThrowsException()
        {
            //Arrange
            var order = new OrderDto
            {
                Id = 4,
                OrderDate = DateTime.Now,
                OrderName = "unit test order"
            };

            //Act Assert
            Assert.ThrowsException<OrderNotFoundException>(() => _orderService.AddOrder(order));
        }

        // delete order
        [TestMethod]
        public void DeleteOrder_ValidOrderId_OrderDeleted()
        {
            //Arrange
            var expectedResult = 2;

            var orderId = 1;

            //Act
            _orderService.DeleteOrder(orderId);

            //Assert
            var result = _orderService.GetAllOrders(0, 0);
            Assert.AreEqual(expectedResult, result.ToList().Count);
        }

        [TestMethod]
        public void DeleteOrder_InvalidOrderId_ThrowsException()
        {
            //Arrange
            var orderId = 0;

            //Act Assert 
            Assert.ThrowsException<OrderNotFoundException>(() => _orderService.DeleteOrder(orderId));
        }

        // get order by id
        [TestMethod]
        public void GetById_ValidOrderId_ReturnsOrder()
        {
            //Arrange
            var orderId = 1;

            //Act
            var result = _orderService.GetOrderById(orderId);

            //Assert
            Assert.IsInstanceOfType(result, typeof(OrderDto));
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetById_InvalidOrderId_ThrowsException()
        {
            //Arrange
            var orderId = 20;

            //Act Assert 
            Assert.ThrowsException<OrderNotFoundException>(() => _orderService.GetOrderById(orderId));
        }

        // get order by date range
        [TestMethod]
        public void GetOrdersByDateRange_ValidInput_ReturnsOrders()
{
            //Arrange
            var expectedResult = 3;
            var fromDate = DateTime.Now.AddDays(-1);
            var toDate = DateTime.Now.AddDays(1);

            //Act
            var result = _orderService.GetOrdersByDateRange(fromDate, toDate);

            //Assert
            Assert.AreEqual(expectedResult, result.Count);
        }

        [TestMethod]
        public void GetOrdersByDateRange_ValidInput_ShouldReturnZeroOrders()
        {
            //Arrange
            var expectedResult = 0;
            var fromDate = DateTime.Now.AddDays(1);
            var toDate = DateTime.Now.AddDays(3);

            //Act
            var result = _orderService.GetOrdersByDateRange(fromDate, toDate);

            //Assert
            Assert.AreEqual(expectedResult, result.Count);
        }

    }
}
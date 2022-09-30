using LinkPlus_Orders_Assignment.Domain.Entities;
using LinkPlus_Orders_Assignment.Dtos.OrderDto;

namespace LinkPlus_Orders_Assignment.Mappers
{
    public static class OrdersMapper
    {

        public static OrderDto ToOrdersDto(Order order)
        {
            return new OrderDto
            {
                Id = order.Id,
                OrderName = order.OrderName,
                OrderPrice = order.OrderPrice,
                OrderDate = order.OrderDate,
            };
        }

        public static Order ToOrder(OrderDto order)
        {
            return new Order
            {
                Id = order.Id,
                OrderName = order.OrderName,
                OrderPrice = order.OrderPrice,
                OrderDate = order.OrderDate,
            };
        }

        public static List<Order> ToOrderListDto(Order order, List<Order> orderList)
        {
            var newOrder = new Order
            {
                OrderName = order.OrderName,
                OrderPrice = order.OrderPrice,
                OrderDate = order.OrderDate,
            };

            orderList.Add(newOrder);
            return orderList;
        }
    }
}

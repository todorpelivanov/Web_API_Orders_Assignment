using LinkPlus_Orders_Assignment.DataAccess.Interfaces;
using LinkPlus_Orders_Assignment.Domain.Entities;
using LinkPlus_Orders_Assignment.Dtos.OrderDto;
using LinkPlus_Orders_Assignment.Mappers;
using LinkPlus_Orders_Assignment.Services.Interface;
using LinkPlus_Orders_Assignment.Shared.OrdersException;

namespace LinkPlus_Orders_Assignment.Services.Implementation
{
    public class OrderService : IOrderService
    {
        private readonly IRepository<Order> _orderRepository;

        public OrderService(IRepository<Order> orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public void AddOrder(OrderDto order)
        {
            if (order.OrderPrice == 0)
            {
                throw new OrderDataException("Order Price must not be empty!");
            }

            _orderRepository.Add(OrdersMapper.ToOrder(order));
        }

        public void DeleteOrder(int id)
        {
            if (id == 0)
            {
                throw new OrderNotFoundException($"Order with id {id} was not found");
            }

            var order = _orderRepository.GetById(id);

            if (order == null)
            {
                throw new OrderNotFoundException($"Order with id {id} was not found");
            }

            _orderRepository.Delete(order);
        }

        public List<OrderDto> GetAllOrders(int pageNumber, int pageSize)
        {
            var query = _orderRepository.GetAll();

            if (pageNumber != 0 && pageSize != 0) 
            {
                query = query.Skip((pageNumber - 1) * pageSize)
                     .Take(pageSize);
            };

            return query.Select(o => OrdersMapper.ToOrdersDto(o)).ToList();
        }

        public OrderDto GetOrderById(int id)
        {
            var order = _orderRepository.GetById(id);

            if (order == null)
            {
                throw new OrderNotFoundException($"Order with id {id} was not found");
            }

            return OrdersMapper.ToOrdersDto(order);
        }

        public List<OrderDto> GetOrdersByDateRange(DateTime? fromDate, DateTime? toDate)
        {
            if (fromDate == null || toDate == null)
            {
                throw new OrderDataException("Please enter starting and ending dates!");
            }

            return _orderRepository.GetAll()
                                    .Where(x => x.OrderDate >= fromDate && x.OrderDate <= toDate)
                                    .Select(o => OrdersMapper.ToOrdersDto(o))
                                    .ToList();

        }
    }
}

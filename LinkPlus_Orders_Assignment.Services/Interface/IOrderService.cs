using LinkPlus_Orders_Assignment.Dtos.OrderDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkPlus_Orders_Assignment.Services.Interface
{
    public interface IOrderService
    {
        List<OrderDto> GetAllOrders(int pageNumber, int pageSize);
        OrderDto GetOrderById(int id);
        void AddOrder(OrderDto order);
        List<OrderDto> GetOrdersByDateRange(DateTime? fromDate, DateTime? toDate);
        void DeleteOrder(int id);
    }
}

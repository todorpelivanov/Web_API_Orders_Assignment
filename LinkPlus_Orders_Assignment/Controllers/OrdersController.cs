using LinkPlus_Orders_Assignment.Domain.Entities;
using LinkPlus_Orders_Assignment.Dtos.OrderDto;
using LinkPlus_Orders_Assignment.Helpers;
using LinkPlus_Orders_Assignment.Services.Interface;
using LinkPlus_Orders_Assignment.Shared.OrdersException;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LinkPlus_Orders_Assignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet("{orderId}")]
        public IActionResult GetOrderById([FromRoute] int orderId)
        {
            try
            {
                return Ok(_orderService.GetOrderById(orderId));

            }
            catch (OrderNotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred, contact the admin!");
            }
        }

        [HttpPost]
        public IActionResult CreateOrder([FromBody] OrderDto order)
        {
            try
            {
                _orderService.AddOrder(order);
                return Ok("Order Succesfully created");
            }
            catch (OrderDataException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred, contact the admin!");
            }
        }

        [HttpDelete("{orderId}")]
        public IActionResult DeleteOrder([FromRoute] int orderId)
        {
            try
            {
                _orderService.DeleteOrder(orderId);
                return Ok($"Order with id {orderId} was successfully deleted!");
            }
            catch (OrderNotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception)
            {
                //log
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred, contact the admin!");
            }
        }

        [HttpGet]
        public IActionResult GetAllOrders([FromQuery] int pageNumber, [FromQuery] int pageSize)
        {

            try
            {
                var pagedData = _orderService.GetAllOrders(pageNumber, pageSize);
                return Ok(pagedData);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred, contact the admin!");
            }

        }

        [HttpGet("/fromDate")]
        public IActionResult GetOrdersByDateRange([FromQuery] DateTime? fromDate, [FromQuery] DateTime? toDate)
        {
            try
            {
                return Ok(_orderService.GetOrdersByDateRange(fromDate, toDate));
            }
            catch (OrderNotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred, contact the admin!");
            }
        }
    }
}

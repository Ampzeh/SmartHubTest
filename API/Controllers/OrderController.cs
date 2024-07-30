using API.Dtos;
using API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly ILogger<OrderController> _logger;

        public OrderController(IOrderService orderService, ILogger<OrderController> logger)
        {
            _orderService = orderService;
            _logger = logger;
        }

        [HttpGet("list")]
        public async Task<IActionResult> GetOrders()
        {
            try
            {
                return Ok(await _orderService.GetOrders());
            }
            catch (Exception ex)
            {
                var message = "An error occurred while getting the orders.";
                _logger.LogError(ex, message);
                return Problem(message);
            }
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetOrder(Guid id)
        {
            try
            {
                var result = await _orderService.GetOrder(id);

                if (result == null)
                    return NotFound("Order not found.");

                return Ok(result);
            }
            catch (Exception ex)
            {
                var message = "An error occurred while getting the order.";
                _logger.LogError(ex, message);
                return Problem(message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(OrderDto dto)
        {
            try
            {
                await _orderService.CreateOrder(dto);
                return Ok("Order created successfully!");
            }
            catch (Exception ex)
            {
                var message = "An error occurred while creating the order.";
                _logger.LogError(ex, message);
                return Problem(message);

            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOrder(OrderDto dto)
        {
            try
            {
                await _orderService.UpdateOrder(dto);
                return Ok("Order updated successfully!");
            }
            catch (Exception ex)
            {
                var message = "An error occurred while updating the order.";
                _logger.LogError(ex, message);
                return Problem(message);
            }
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteOrder(Guid Id)
        {
            try
            {
                await _orderService.DeleteOrder(Id);
                return Ok("Order deleted successfully!");
            }
            catch (Exception ex)
            {
                var message = "An error occurred while deleting the order.";
                _logger.LogError(ex, message);
                return Problem(message);
            }
        }
    }
}

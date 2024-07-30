using API.Dtos;
using API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderLineController : ControllerBase
    {
        private readonly IOrderLineService _orderLineService;
        private readonly ILogger<OrderLineController> _logger;

        public OrderLineController(IOrderLineService orderLineService, ILogger<OrderLineController> logger)
        {
            _orderLineService = orderLineService;
            _logger = logger;
        }

        [HttpGet("list/{orderId:guid}")]
        public async Task<IActionResult> GetOrderLines(Guid orderId)
        {
            try
            {
                return Ok(await _orderLineService.GetOrderLines(orderId));
            }
            catch (Exception ex)
            {
                var message = "An error occurred while getting the order Lines.";
                _logger.LogError(ex, message);
                return Problem(message);
            }
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetOrderLine(Guid id)
        {
            try
            {
                var result = await _orderLineService.GetOrderLine(id);

                if (result == null)
                    return NotFound("Order Line not found.");

                return Ok(result);
            }
            catch (Exception ex)
            {
                var message = "An error occurred while getting the order line.";
                _logger.LogError(ex, message);
                return Problem(message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrderLine(OrderLineDto dto)
        {
            try
            {
                await _orderLineService.CreateOrderLine(dto);
                return Ok("Order Line created successfully!");
            }
            catch (Exception ex)
            {
                var message = "An error occurred while creating the order line.";
                _logger.LogError(ex, message);
                return Problem(message);

            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOrderLine(OrderLineDto dto)
        {
            try
            {
                await _orderLineService.UpdateOrderLine(dto);
                return Ok("Order Line updated successfully!");
            }
            catch (Exception ex)
            {
                var message = "An error occurred while updating the order line.";
                _logger.LogError(ex, message);
                return Problem(message);
            }
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteOrderLine(Guid Id)
        {
            try
            {
                await _orderLineService.DeleteOrderLine(Id);
                return Ok("Order Line deleted successfully!");
            }
            catch (Exception ex)
            {
                var message = "An error occurred while deleting the order line.";
                _logger.LogError(ex, message);
                return Problem(message);
            }
        }
    }
}

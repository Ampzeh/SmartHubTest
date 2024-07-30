using API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UtilitiesController : ControllerBase
    {
        private readonly IUtilityService _utilityService;
        private readonly ILogger<UtilitiesController> _logger;

        public UtilitiesController(IUtilityService utilityService, ILogger<UtilitiesController> logger)
        {
            _utilityService = utilityService;
            _logger = logger;
        }

        [HttpGet("manage-order")]
        public async Task<IActionResult> GetManageOrderUtilities()
        {
            try
            {
                return Ok(await _utilityService.GetManageOrderUtilities());
            }
            catch (Exception ex)
            {
                var message = "An error occurred while getting Manage Order utilities.";
                _logger.LogError(ex, message);
                return Problem(message);
            }
        }

        [HttpGet("manage-order-line/{orderId:guid}")]
        public async Task<IActionResult> GetManageOrderLineUtilities(Guid orderId)
        {
            try
            {
                return Ok(await _utilityService.GetManageOrderLineUtilities(orderId));
            }
            catch (Exception ex)
            {
                var message = "An error occurred while getting Manage Order Line utilities.";
                _logger.LogError(ex, message);
                return Problem(message);
            }
        }
    }
}

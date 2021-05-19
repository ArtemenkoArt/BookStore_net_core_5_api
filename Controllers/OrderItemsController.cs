using BookStore_01.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace BookStore_01.Controllers
{
    [Route("api/orders/{orderId}/items")]
    public class OrderItemsController : ControllerBase
    {
        private readonly IOrderItemService _service;
        private readonly ILogger _logger;

        public OrderItemsController(IOrderItemService service, ILogger logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get(int orderId)
        {
            try
            {
                var result = await _service.GetOrderItems(orderId);
                if (result != null)
                    return Ok(result);

                return NotFound();
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Format("OrderItemsController.Get(orderId), Message: {0}", ex.Message));
                return BadRequest(string.Format("Faled to get: {0}", ex.Message));
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int orderId, int id)
        {
            try
            {
                var result = await _service.GetOrderItem(orderId, id);
                if (result != null)
                    return Ok(result);

                return NotFound();
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Format("OrderItemsController.Get(orderId, id), Message: {0}", ex.Message));
                return BadRequest(string.Format("Faled to get: {0}", ex.Message));
            }
        }
    }
}

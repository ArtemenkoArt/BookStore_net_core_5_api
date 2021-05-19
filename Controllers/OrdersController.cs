using BookStore_01.Models;
using BookStore_01.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore_01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _service;
        private readonly ILogger _logger;

        public OrdersController(IOrderService service, ILogger logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderViewModel>>> Get()
        {
            try
            {
                var result = await _service.GetAll();
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Format("OrdersController.Get(), Message: {0}", ex.Message));
                return BadRequest(string.Format("Faled to get: {0}", ex.Message));
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderViewModel>> Get(int id)
        {
            try
            {
                var result = await _service.Get(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Format("OrdersController.Get(id), Message: {0}", ex.Message));
                return BadRequest(string.Format("Faled to get: {0}", ex.Message));
            }
        }

        [HttpPost]
        public async Task<ActionResult<OrderViewModel>> Post([FromBody] OrderViewModel viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _service.Add(viewModel);
                    return CreatedAtAction("Get", new { id = result.OrderId }, result);
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Format("OrdersController.Post(), Message: {0}", ex.Message));
                return BadRequest(string.Format("Faled to Post: {0}", ex.Message));
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<OrderViewModel>> Put(int id, [FromBody] OrderViewModel viewModel)
        {
            if (id != viewModel.OrderId)
                return BadRequest("Faled to Put: id is empty");

            try
            {
                var result = await _service.Update(viewModel);
                return CreatedAtAction("Get", new { id = result.OrderId }, result);
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Format("OrdersController.Put(), Message: {0}", ex.Message));
                return BadRequest(string.Format("Faled to Put: {0}", ex.Message));
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _service.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Format("OrdersController.Delete(id): {0}", ex.Message));
                return BadRequest();
            }
        }
    }
}

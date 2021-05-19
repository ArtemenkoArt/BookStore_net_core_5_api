﻿using BookStore_01.Models;
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
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorService _service;
        private readonly ILogger _logger;

        public AuthorsController(IAuthorService service, ILogger logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AuthorViewModel>> Get(int id)
        {
            try
            {
                var result = await _service.Get(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Format("AuthorsController.Get(id), Message: {0}", ex.Message));
                return BadRequest(string.Format("Faled to get: {0}", ex.Message));
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AuthorViewModel>>> Get()
        {
            try
            {
                var result = await _service.GetAll();
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Format("AuthorsController.Get(), Message: {0}", ex.Message));
                return BadRequest(string.Format("Faled to get: {0}", ex.Message));
            }
        }

        [HttpPost]
        public async Task<ActionResult<AuthorViewModel>> Post([FromBody] AuthorViewModel viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _service.Add(viewModel);
                    return CreatedAtAction("Get", new { id = result.Id }, result);
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Format("AuthorsController.Post(), Message: {0}", ex.Message));
                return BadRequest(string.Format("Faled to Post: {0}", ex.Message));
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<AuthorViewModel>> Put(int id, [FromBody] AuthorViewModel viewModel)
        {
            if (id != viewModel.Id)
                return BadRequest("Faled to Put: id is empty");

            try
            {
                var result = await _service.Update(viewModel);
                return CreatedAtAction("Get", new { id = result.Id }, result);
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Format("AuthorsController.Put(), Message: {0}", ex.Message));
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
                _logger.LogError(string.Format("AuthorsController.Delete(id): {0}", ex.Message));
                return BadRequest();
            }
        }
    }
}

﻿using Application.Products;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductApplication _application;
        private readonly ILogger<ProductsController> _logger;

        public ProductsController(IProductApplication application, ILogger<ProductsController> logger)
        {
            _application = application;
            _logger = logger;          
        }

        [HttpGet("sandwichesandextras")]       
        public async Task<IActionResult> GetSandwichesAndExtrasAsync(CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid) return UnprocessableEntity(ModelState);
            var request = await _application.GetAllSandwichesAndExtrasAsync(cancellationToken);

            if (request.IsSucess)
            {
                return Ok(request.Value);
            }
            else
            {
                _logger.LogError(request.Error.Message);
                return BadRequest(request.Error);
            }
        }

        [HttpGet("extras")]       
        public async Task<IActionResult> GetExtrasAsync(CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid) return UnprocessableEntity(ModelState);
            var request = await _application.GetAllExtrasAsync(cancellationToken);

            if (request.IsSucess)
            {
                return Ok(request.Value);
            }
            else
            {
                return BadRequest(request.Error);
            }
        }

        [HttpGet("sandwiches")]
        public async Task<IActionResult> GetSandwiches(CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid) return UnprocessableEntity(ModelState);
            var request = await _application.GetAllSandwichesAsync(cancellationToken);

            if (request.IsSucess)
            {
                return Ok(request.Value);
            }
            else
            {
                return BadRequest(request.Error);
            }
        }
    }
}

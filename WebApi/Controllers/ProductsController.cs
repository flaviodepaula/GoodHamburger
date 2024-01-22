using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
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

        [HttpGet]
        [Route("/sandwichesandextras")]
        public async Task<IActionResult> GetSandwichesAndExtras()
        {
            if (!ModelState.IsValid) return UnprocessableEntity(ModelState);
            var request = await _application.GetAllSandwichesAndExtrasAsync();

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

        [HttpGet]
        [Route("/extras")]
        public async Task<IActionResult> GetExtras()
        {
            if (!ModelState.IsValid) return UnprocessableEntity(ModelState);
            var request = await _application.GetAllExtrasAsync();

            if (request.IsSucess)
            {
                return Ok(request.Value);
            }
            else
            {
                return BadRequest(request.Error);
            }
        }

        [HttpGet]
        [Route("/sandwiches")]
        public async Task<IActionResult> GetSandwiches()
        {
            if (!ModelState.IsValid) return UnprocessableEntity(ModelState);
            var request = await _application.GetAllSandwichesAsync();

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

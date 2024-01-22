using AutoMapper;
using Domain.Interfaces;
using Domain.Models.Order;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : Controller
    {
        private readonly IOrderDomain _domain;
        private readonly ILogger<OrderController> _logger;
        private readonly IMapper _mapper;

        public OrderController(IOrderDomain domain, ILogger<OrderController> logger, IMapper mapper)
        {
            _domain = domain;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("/ammount")]
        public async Task<IActionResult> GetOrderAmount([FromBody] Guid orderGuid)
        {
            if (!ModelState.IsValid) return UnprocessableEntity(ModelState);
            var request = await _domain.GetOrderAmountAsync(orderGuid);

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

        [HttpPost]
        [Route("/order")]
        public async Task<IActionResult> CreateOrderAsync([FromBody] RequestProductViewModel orderProducts)
        {
            var orderCommand = _mapper.Map<CreateOrderCommand>(orderProducts);

            if (!ModelState.IsValid) return UnprocessableEntity(ModelState);
            var request = await _domain.CreateOrderAsync(orderCommand);

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
        [Route("/allorders")]
        public async Task<IActionResult> GetAllOrdersAsync([FromBody] Guid orderGuid)
        {
            if (!ModelState.IsValid) return UnprocessableEntity(ModelState);
            var request = await _domain.GetAllOrdersAsync();

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

        [HttpPut]
        [Route("/order")]
        public async Task<IActionResult> UpdateOrder([FromBody] Order order)
        {
            if (!ModelState.IsValid) return UnprocessableEntity(ModelState);
            var request = await _domain.UpdateOrdersync(order);

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

        [HttpDelete]
        [Route("/order")]
        public async Task<IActionResult> DeleteOrderAsync([FromBody] Guid orderGuid)
        {
            if (!ModelState.IsValid) return UnprocessableEntity(ModelState);
            var request = await _domain.DeleteOrderAsync(orderGuid);

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

    }
}

using Application.Orders;
using AutoMapper;
using Domain.Orders.Models;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("orders")]
    [ApiController]
    public class OrderController : Controller
    {
        private readonly IOrderApplication _application;
        private readonly ILogger<OrderController> _logger;
        private readonly IMapper _mapper;

        public OrderController(IOrderApplication domain, 
                               ILogger<OrderController> logger, 
                               IMapper mapper)
        {
            _application = domain;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet("amount")]
        public async Task<IActionResult> GetOrderAmount([FromQuery] Guid orderGuid, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid) return UnprocessableEntity(ModelState);
            var request = await _application.GetOrderAmountAsync(orderGuid, cancellationToken);

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

        [HttpPost("order")]        
        public async Task<IActionResult> CreateOrderAsync([FromBody] RequestProductViewModel orderProducts, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid) return UnprocessableEntity(ModelState);

            var orderDTO = _mapper.Map<OrderDTO>(orderProducts);
            var request = await _application.CreateOrderAsync(orderDTO, cancellationToken);

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

        [HttpGet("allorders")]
        public async Task<IActionResult> GetAllOrdersAsync(CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid) return UnprocessableEntity(ModelState);
            var request = await _application.GetAllOrdersAsync(cancellationToken);

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

        [HttpPut("order")]
        public async Task<IActionResult> UpdateOrderAsync([FromBody] UpdateProductViewModel order, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid) return UnprocessableEntity(ModelState);

            var orderDto = _mapper.Map<OrderDTO>(order);

            var request = await _application.UpdateOrdersync(orderDto, cancellationToken);

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

        [HttpDelete("order")]
        public async Task<IActionResult> DeleteOrderAsync([FromQuery] Guid orderGuid, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid) return UnprocessableEntity(ModelState);
            var request = await _application.DeleteOrderAsync(orderGuid, cancellationToken);

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

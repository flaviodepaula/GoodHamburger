using Application.Interfaces;
using AutoMapper;
using Domain.Models.Order;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
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

        [HttpGet]
        [Route("/ammount")]
        public async Task<IActionResult> GetOrderAmount([FromBody] Guid orderGuid, CancellationToken cancellationToken)
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

        [HttpPost]
        [Route("/order")]
        public async Task<IActionResult> CreateOrderAsync([FromBody] RequestProductViewModel orderProducts, CancellationToken cancellationToken)
        {
            var orderDTO = _mapper.Map<OrderDTO>(orderProducts);

            if (!ModelState.IsValid) return UnprocessableEntity(ModelState);
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

        [HttpGet]
        [Route("/allorders")]
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

        [HttpPut]
        [Route("/order")]
        public async Task<IActionResult> UpdateOrderAsync([FromBody] Order order, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid) return UnprocessableEntity(ModelState);
            var request = await _application.UpdateOrdersync(order, cancellationToken);

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
        public async Task<IActionResult> DeleteOrderAsync([FromBody] Guid orderGuid, CancellationToken cancellationToken)
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

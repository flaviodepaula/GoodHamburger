using AutoMapper;
using Domain.Errors;
using Domain.Interfaces;
using Domain.Models.Order;
using Domain.Models.Products;
using Infra.Common.Result;
using Infra.Repository.Entities;
using Infra.Repository.Interfaces;
using Microsoft.Extensions.Logging;

namespace Domain.Services
{
    public class OrderDomainServices : IOrderDomain
    {
        private readonly IRepository _repository;
        private readonly ILogger<OrderDomainServices> _logger;
        private readonly IMapper _mapper;

        public OrderDomainServices(IRepository repository, ILogger<OrderDomainServices> logger, IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
            _repository = repository;
        }

       
        public async Task<Result<IEnumerable<OrderDTO>>> GetAllOrdersAsync()
        {
            var dbOrders = await _repository.GetAllOrdersAsync();
            
            if (dbOrders.IsFailure)
                return Result.Failure<IEnumerable<OrderDTO>>(DomainErrors.RequestToDatabaseFailed);

            return dbOrders.Value.ToList();
        }

        public async Task<Result<Order>> UpdateOrdersync(Order order)
        {
            var orderDTO = _mapper.Map<OrderDTO>(order);

            var updateOrder = await _repository.UpdateOrderAsync(orderDTO);
            if (updateOrder.IsFailure)
                return Result.Failure<Order>(updateOrder.Error);

            var updatedOrder = _mapper.Map<Order>(orderDTO);

            return updatedOrder;
        }

        public async Task<Result<bool>> DeleteOrderAsync(Guid orderNumber)
        {
            var isDeleted = await _repository.DeleteOrderAsync(orderNumber);

            if (isDeleted.IsFailure)
                return Result.Failure<bool>(isDeleted.Error);

            return isDeleted.Value;
        }
          
        public async Task<Result<Order>> CreateOrderAsync(CreateOrderCommand order)
        {
            var productsDTO = _mapper.Map<IEnumerable<ProductDTO>>(order.Products);
            var productsDB = await _repository.GetProductDetailsList(productsDTO);

            if (productsDB.IsFailure)
                return Result.Failure<Order>(productsDB.Error);

            var products = _mapper.Map<IEnumerable<Product>>(productsDB);

            var newOrder = Order.CreateOrder(products);
            if (newOrder.IsFailure)
                return Result.Failure<Order>(newOrder.Error);

            OrderDTO newOrderDTO = new OrderDTO
            {
                OrderId = newOrder.Value.Id,
                Products = productsDTO,
                TotalAmount = newOrder.Value.Amount
            };

            var newOrderDatabase = await _repository.CreateOrderAync(newOrderDTO);
            if (newOrderDatabase.IsFailure)
                return Result.Failure<Order>(newOrderDatabase.Error);

            return newOrder.Value;
        }

        public async Task<Result<decimal>> GetOrderAmountAsync(Guid orderNumber)
        {
            var dbOrders = await _repository.GetOrderByIdAsync(orderNumber);

            if (dbOrders.IsFailure)
                return Result.Failure<decimal>(DomainErrors.RequestToDatabaseFailed);

            return dbOrders.Value.TotalAmount;
        }         
    }
}

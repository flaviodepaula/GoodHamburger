using AutoMapper;
using Domain.Errors;
using Domain.Interfaces;
using Domain.Models.Order;
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

        public Task<Result<Order>> UpdateOrdersync(UpdateOrderCommand order)
        {
            throw new NotImplementedException();
        }
        public async Task<Result<bool>> DeleteOrderAsync(Guid orderNumber)
        {
            var isDeleted = await _repository.DeleteOrderAsync(orderNumber);

            if (isDeleted.IsFailure)
                return Result.Failure<bool>(DomainErrors.UnableToRemove);

            return isDeleted.Value;
        }
          
        public async Task<Result<Order>> CreateOrderAsync(CreateOrderCommand order)
        {
            var newOrder = Order.CreateOrder(order.Products);
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

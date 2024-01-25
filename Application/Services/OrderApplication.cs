using Application.Errors;
using Application.Interfaces;
using AutoMapper;
using Domain.Interfaces;
using Domain.Models.Order;
using Infra.Common.Result;
using Infra.Repository.Interfaces;

namespace Application.Services
{
    public class OrderApplication : IOrderApplication
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IProductValidator _productValidator;
        private readonly IProductRepository _productRepository;

        public OrderApplication(IOrderRepository repository, IProductValidator productValidator, IProductRepository productRepository)
        {
            _orderRepository = repository;
            _productValidator = productValidator;
            _productRepository = productRepository;
        }

        public async Task<Result<IEnumerable<OrderDTO>>> GetAllOrdersAsync(CancellationToken cancellationToken)
        {
            var dbOrders = await _orderRepository.GetAllAsync(cancellationToken);

            if (dbOrders.IsFailure)
                return Result.Failure<IEnumerable<OrderDTO>>(dbOrders.Error);

            return dbOrders.Value.ToList();
        }

        public async Task<Result<Order>> UpdateOrdersync(OrderDTO order, CancellationToken cancellationToken)
        {
            var products = await _productRepository.GetProductDetailsListAsync(order.Products, cancellationToken);

            if (products.IsFailure)
                return Result.Failure<Order>(products.Error);

            var updateOrder = Order.CreateOrder(order.Id, products.Value);
            if (updateOrder.IsFailure)
                return Result.Failure<Order>(updateOrder.Error);
             

            var updatedOrder = await _orderRepository.UpdateAsync(updateOrder.Value, cancellationToken);
            if (updatedOrder.IsFailure)
                return Result.Failure<Order>(updatedOrder.Error);
             
            return updatedOrder;
        }

        public async Task<Result<bool>> DeleteOrderAsync(Guid orderNumber, CancellationToken cancellationToken )
        {
            var isDeleted = await _orderRepository.DeleteAsync(orderNumber, cancellationToken);

            if (isDeleted.IsFailure)
                return Result.Failure<bool>(isDeleted.Error);

            return isDeleted.Value;
        }

        public async Task<Result<Order>> CreateOrderAsync(OrderDTO order, CancellationToken cancellationToken)
        {           
            var products = await _productRepository.GetProductDetailsListAsync(order.Products, cancellationToken);

            if (products.IsFailure)
                return Result.Failure<Order>(products.Error);
            
            //all products received must be on database
            if (order.Products.Count() != products.Value.Count())
                return Result.Failure<Order>(ApplicationErrors.InvalidList);

            var newOrder = Order.CreateOrder(Guid.NewGuid(), products.Value);
            if (newOrder.IsFailure)
                return Result.Failure<Order>(newOrder.Error);

            var newOrderDatabase = await _orderRepository.CreateAync(newOrder.Value, cancellationToken);
            if (newOrderDatabase.IsFailure)
                return Result.Failure<Order>(newOrderDatabase.Error);

            return newOrderDatabase.Value;
        }

        public async Task<Result<decimal>> GetOrderAmountAsync(Guid orderNumber, CancellationToken cancellationToken)
        {
            var dbOrders = await _orderRepository.GetByIdAsync(orderNumber , cancellationToken);

            if (dbOrders.IsFailure)
                return Result.Failure<decimal>(dbOrders.Error);

            return dbOrders.Value.Amount;
        }
    }
}

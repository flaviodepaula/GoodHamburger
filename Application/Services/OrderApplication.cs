using Application.Interfaces;
using Application.Models;
using AutoMapper;
using Domain.Errors;
using Domain.Models.Order;
using Domain.Models.Products;
using Infra.Common.Result;
using Infra.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class OrderApplication : IOrderApplication
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;


        public OrderApplication(IOrderRepository repository, IProductRepository productRepository, IMapper mapper)
        {
            _orderRepository = repository;
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<Result<IEnumerable<Order>>> GetAllOrdersAsync()
        {
            var dbOrders = await _orderRepository.GetAllAsync();

            if (dbOrders.IsFailure)
                return Result.Failure<IEnumerable<Order>>(DomainErrors.RequestToDatabaseFailed);

            return dbOrders.Value.ToList();
        }

        public async Task<Result<Order>> UpdateOrdersync(Order order)
        { 
            var updatedOrder = await _orderRepository.UpdateAsync(order);
            if (updatedOrder.IsFailure)
                return Result.Failure<Order>(updatedOrder.Error);
             
            return updatedOrder;
        }

        public async Task<Result<bool>> DeleteOrderAsync(Guid orderNumber)
        {
            var isDeleted = await _orderRepository.DeleteAsync(orderNumber);

            if (isDeleted.IsFailure)
                return Result.Failure<bool>(isDeleted.Error);

            return isDeleted.Value;
        }

        public async Task<Result<Order>> CreateOrderAsync(OrderDTO order)
        {
            var productsDTO = _mapper.Map<IEnumerable<Product>>(order.Products);
            var products = await _productRepository.GetProductDetailsList(productsDTO);

            if (products.IsFailure)
                return Result.Failure<Order>(products.Error);

            var newOrder = await Order.CreateOrder(products.Value);
            if (newOrder.IsFailure)
                return Result.Failure<Order>(newOrder.Error);

            var newOrderDatabase = await _orderRepository.CreateAync(newOrder.Value);
            if (newOrderDatabase.IsFailure)
                return Result.Failure<Order>(newOrderDatabase.Error);

            return newOrder.Value;
        }

        public async Task<Result<decimal>> GetOrderAmountAsync(Guid orderNumber)
        {
            var dbOrders = await _orderRepository.GetByIdAsync(orderNumber);

            if (dbOrders.IsFailure)
                return Result.Failure<decimal>(DomainErrors.RequestToDatabaseFailed);

            return dbOrders.Value.Amount;
        }
    }
}

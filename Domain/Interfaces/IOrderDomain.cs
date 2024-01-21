using Domain.Models.Order;
using Infra.Common.Result;
using Infra.Repository.Entities;

namespace Domain.Interfaces
{
    public interface IOrderDomain
    {
        Task<Result<decimal>> GetOrderAmountAsync(Guid orderNumber);
        Task<Result<Order>> CreateOrderAsync(CreateOrderCommand order);
        Task<Result<IEnumerable<OrderDTO>>> GetAllOrdersAsync();
        Task<Result<Order>> UpdateOrdersync(Order order);
        Task<Result<bool>> DeleteOrderAsync(Guid orderNumber);
    }
}

using Domain.Models.Order;
using Infra.Common.Result;

namespace Application.Interfaces
{
    public interface IOrderApplication
    {
        Task<Result<decimal>> GetOrderAmountAsync(Guid orderNumber, CancellationToken cancellationToken);
        Task<Result<Order>> CreateOrderAsync(OrderDTO order, CancellationToken cancellationToken);
        Task<Result<IEnumerable<OrderDTO>>> GetAllOrdersAsync(CancellationToken cancellationToken);
        Task<Result<Order>> UpdateOrdersync(OrderDTO order, CancellationToken cancellationToken);
        Task<Result<bool>> DeleteOrderAsync(Guid orderNumber, CancellationToken cancellationToken);
    }
}

using Domain.Models.Order;
using Infra.Common.Result;

namespace Infra.Repository.Interfaces
{
    public interface IOrderRepository
    {
        Task<Result<OrderDTO>> GetByIdAsync(Guid orderNumber, CancellationToken cancellationToken);
        Task<Result<IEnumerable<OrderDTO>>> GetAllAsync(CancellationToken cancellationToken);
        Task<Result<Order>> CreateAync(Order order, CancellationToken cancellationToken);
        Task<Result<Order>> UpdateAsync(Order order, CancellationToken cancellationToken);
        Task<Result<bool>> DeleteAsync(Guid orderNumber, CancellationToken cancellationToken);
    }
}

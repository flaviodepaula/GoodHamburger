using Domain.Models.Order;
using Infra.Common.Result;

namespace Infra.Repository.Interfaces
{
    public interface IOrderRepository
    {
        Task<Result<Order>> GetByIdAsync(Guid orderNumber);
        Task<Result<IEnumerable<Order>>> GetAllAsync();
        Task<Result<Order>> CreateAync(Order order);
        Task<Result<Order>> UpdateAsync(Order order);
        Task<Result<bool>> DeleteAsync(Guid orderNumber);
    }
}

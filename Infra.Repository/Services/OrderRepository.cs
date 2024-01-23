using Domain.Models.Order;
using Infra.Common.Result;
using Infra.Repository.Interfaces;

namespace Infra.Repository.Services
{
    public class OrderRepository : IOrderRepository
    {
        public Task<Result<Order>> CreateAync(Order order)
        {
            throw new NotImplementedException();
        }

        public Task<Result<bool>> DeleteAsync(Guid orderNumber)
        {
            throw new NotImplementedException();
        }

        public Task<Result<IEnumerable<Order>>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Result<Order>> GetByIdAsync(Guid orderNumber)
        {
            throw new NotImplementedException();
        }

        public Task<Result<Order>> UpdateAsync(Order order)
        {
            throw new NotImplementedException();
        }
    }
}

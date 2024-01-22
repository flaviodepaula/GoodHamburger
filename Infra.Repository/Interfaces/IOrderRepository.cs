using Domain.Models.Order;
using Infra.Common.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repository.Interfaces
{
    public interface IOrderRepository
    {
        Task<Result<Order>> GetOrderByIdAsync(Guid orderNumber);
        Task<Result<IEnumerable<Order>>> GetAllOrdersAsync();
        Task<Result<Order>> CreateOrderAync(Order order);
        Task<Result<Order>> UpdateOrderAsync(Order order);
        Task<Result<bool>> DeleteOrderAsync(Guid orderNumber);
    }
}

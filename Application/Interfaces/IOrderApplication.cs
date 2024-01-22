using Application.Models;
using Domain.Models.Order;
using Infra.Common.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IOrderApplication
    {
        Task<Result<decimal>> GetOrderAmountAsync(Guid orderNumber);
        Task<Result<Order>> CreateOrderAsync(OrderDTO order);
        Task<Result<IEnumerable<Order>>> GetAllOrdersAsync();
        Task<Result<Order>> UpdateOrdersync(Order order);
        Task<Result<bool>> DeleteOrderAsync(Guid orderNumber);
    }
}

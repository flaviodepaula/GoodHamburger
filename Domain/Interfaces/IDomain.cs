using Domain.Models;
using Infra.Common.Result;

namespace Domain.Interfaces
{
    public interface IDomain
    {
        Task<Result<decimal>> CalculateAmmount(Order order);
    }
}

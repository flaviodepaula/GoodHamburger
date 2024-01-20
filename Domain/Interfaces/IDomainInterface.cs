using Domain.Models;
using Infra.Common.Result;

namespace Domain.Interfaces
{
    public interface IDomainInterface
    {
        Task<Result<double>> CalculateAmmount(Order order);
    }
}

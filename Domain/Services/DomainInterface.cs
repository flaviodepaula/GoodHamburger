using Domain.Interfaces;
using Domain.Models;
using Infra.Common.Result;

namespace Domain.Services
{
    public class DomainInterface : IDomainInterface
    {
        public Task<Result<double>> CalculateAmmount(Order order)
        {
            throw new NotImplementedException();
        }
    }
}

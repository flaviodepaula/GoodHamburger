using Domain.Interfaces;
using Domain.Models;

namespace Domain.Services
{
    public class DomainInterface : IDomainInterface
    {
        public Task<double> CalculateAmmount(Order order)
        {
            throw new NotImplementedException();
        }
    }
}

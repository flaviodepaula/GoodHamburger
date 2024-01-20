using Domain.Models;

namespace Domain.Interfaces
{
    public interface IDomainInterface
    {
        Task<double> CalculateAmmount(Order order);
    }
}

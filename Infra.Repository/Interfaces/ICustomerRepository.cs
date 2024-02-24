using Domain.Customers;
using Domain.Customers.DTOs;
using Infra.Common.Result;

namespace Infra.Repository.Interfaces
{
    public interface ICustomerRepository
    {
        Task<Result<CustomerDTO>> GetByIdAsync(Guid customerId, CancellationToken cancellationToken);
        Task<Result<IEnumerable<CustomerDTO>>> GetAllAsync(CancellationToken cancellationToken);
        Task<Result<CustomerDTO>> CreateAync(Customer customer, CancellationToken cancellationToken);
        Task<Result<CustomerDTO>> UpdateAsync(Customer customer, CancellationToken cancellationToken);
        Task<Result<bool>> DeleteAsync(Guid customerId, CancellationToken cancellationToken);
    }
}

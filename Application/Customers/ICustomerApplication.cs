using Domain.Customers.DTOs;
using Infra.Common.Result;

namespace Application.Customers
{
    public interface ICustomerApplication
    {
        Task<Result<CustomerDTO>> GetByIdAsync(Guid customerId, CancellationToken cancellationToken);
        Task<Result<IEnumerable<CustomerDTO>>> GetAllAsync(CancellationToken cancellationToken);
        Task<Result<CustomerDTO>> CreateAync(CustomerDTO customer, CancellationToken cancellationToken);
        Task<Result<CustomerDTO>> UpdateAsync(CustomerDTO customer, CancellationToken cancellationToken);
        Task<Result<bool>> DeleteAsync(Guid customerId, CancellationToken cancellationToken);

    }
}

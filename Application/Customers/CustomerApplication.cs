using AutoMapper;
using Domain.Customers;
using Domain.Customers.DTOs;
using Infra.Common.Result;
using Infra.Repository.Interfaces;

namespace Application.Customers
{
    public class CustomerApplication : ICustomerApplication
    {
        private readonly ICustomerRepository _repository;
        private readonly IMapper _mapper;

        public CustomerApplication(ICustomerRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Result<CustomerDTO>> CreateAync(CustomerDTO customer, CancellationToken cancellationToken)
        { 
            var newCustomer = Customer.NewCustomer(customer);
            if (newCustomer.IsFailure)
                return Result.Failure<CustomerDTO>(newCustomer.Error);

            return await _repository.CreateAync(newCustomer.Value, cancellationToken);
        }

        public async Task<Result<bool>> DeleteAsync(Guid customerId, CancellationToken cancellationToken)
        {
            return await _repository.DeleteAsync(customerId, cancellationToken);
        }

        public async Task<Result<IEnumerable<CustomerDTO>>> GetAllAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<Result<CustomerDTO>> GetByIdAsync(Guid customerId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<Result<CustomerDTO>> UpdateAsync(CustomerDTO customer, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

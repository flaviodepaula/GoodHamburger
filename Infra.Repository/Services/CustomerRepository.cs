using AutoMapper;
using Domain.Customers.DTOs;
using Domain.Orders.Models;
using Infra.Common.Result;
using Infra.Repository.Context;
using Infra.Repository.Errors;
using Infra.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repository.Services
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly GoodHamburgerDbContext _dbContext;
        private readonly IMapper _mapper;

        public CustomerRepository(GoodHamburgerDbContext dbContext,
                                  IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public Task<Result<CustomerDTO>> CreateAync(Domain.Customers.Customer customer, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<Result<bool>> DeleteAsync(Guid customerId, CancellationToken cancellationToken)
        {
            try
            {
                //verify if customer has orders => cannot be deleted
                var userHasOrders = _dbContext.Orders.Any(x => x.Customer.CustomerId == customerId);
                if (userHasOrders)
                    return Result.Failure<bool>(RepositoryErrors.Customer.UserHasOrders);

                Entities.Customer customerToDelete = new()
                {
                    CustomerId = customerId,
                };

                _dbContext.Customers.Remove(customerToDelete);

                var result = await _dbContext.SaveChangesAsync(cancellationToken);

                if (result > 0)
                    return Result.Sucess(true);
                else
                    return Result.Failure<bool>(RepositoryErrors.Customer.UnableToRemove);
            }
            catch (Exception ex)
            {
                return Result.Failure<bool>(RepositoryErrors.DeleteGeneralException(ex.Message));
            }
        }

        public async Task<Result<IEnumerable<CustomerDTO>>> GetAllAsync(CancellationToken cancellationToken)
        {
            try
            {
                List<CustomerDTO> customersList = [];

                var customers = await _dbContext.Customers.ToListAsync(cancellationToken);


                customersList = customers.Select(x => _mapper.Map<CustomerDTO>(x)).ToList();


                //if (customers.Count != 0)
                //{
                //    foreach (var customer in customers)
                //    {
                //        customersList.Add(new CustomerDTO()
                //        {
                //            Address = new AddressDTO()
                //            {
                //                City = customer.Address?.City,
                //                Neighborhood = customer.Address?.Neighborhood,
                //                Number = customer.Address?.Number,
                //                PostalCode = customer.Address?.PostalCode,
                //                ReferenceDetails = customer.Address?.ReferenceDetails,
                //                Street = customer.Address?.Street,
                //            },
                //            CustomerId = customer.CustomerId,
                //            Email = customer.Email,
                //            Name = customer.Name,
                //            Phone = customer.PhoneNumber,
                //        });
                //    }
                //}
                return Result.Sucess(customersList.AsEnumerable());
            }
            catch (Exception ex)
            {
                return Result.Failure<IEnumerable<CustomerDTO>>(RepositoryErrors.RequestToDatabaseFailed(ex.Message));
            }
        }

        public async Task<Result<CustomerDTO>> GetByIdAsync(Guid customerId, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _dbContext.Customers.FirstOrDefaultAsync(x => x.CustomerId == customerId, cancellationToken);

                var resultMapped = _mapper.Map<CustomerDTO>(result);

                if (resultMapped == null)
                {
                    return Result.Failure<CustomerDTO>(RepositoryErrors.Customer.CustomerDoesNotExists);
                }

                return Result.Sucess(resultMapped);
            }
            catch (Exception ex)
            {
                return Result.Failure<CustomerDTO>(RepositoryErrors.RequestToDatabaseFailed(ex.Message));
            }
        }
      
        public async Task<Result<CustomerDTO>> UpdateAsync(Domain.Customers.Customer customer, CancellationToken cancellationToken)
        {
            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    var actualCustomer = await _dbContext.Customers                        
                        .FirstOrDefaultAsync(y => y.CustomerId == customer.CustomerId, cancellationToken);

                    if (actualCustomer == null)
                        return Result.Failure<CustomerDTO>(RepositoryErrors.Customer.CustomerDoesNotExists);
                     
                    actualCustomer = _mapper.Map<Entities.Customer>(customer);

                    await _dbContext.SaveChangesAsync(cancellationToken);
                    transaction.Commit();

                    var customerUpdated = _mapper.Map<CustomerDTO>(actualCustomer);

                    return Result.Sucess(customerUpdated);
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return Result.Failure<CustomerDTO>(RepositoryErrors.Customer.UnableToUpdateCustomer(ex.Message));
                }
            }
        }
    }
}

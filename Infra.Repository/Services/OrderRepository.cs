using AutoMapper;
using Domain.Models.Order;
using Infra.Common.Result;
using Infra.Repository.Context;
using Infra.Repository.Errors;
using Infra.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repository.Services
{
    public class OrderRepository : IOrderRepository
    {
        private readonly GoodHamburgerDbContext _dbContext;
        private readonly IMapper _mapper;

        public OrderRepository(GoodHamburgerDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<Result<Order>> CreateAync(Order order, CancellationToken cancellationToken)
        {
            try
            {
                var resultMapped = _mapper.Map<Entities.Orders>(order);

                await _dbContext.Orders.AddAsync(resultMapped, cancellationToken);

                var result = _dbContext.SaveChanges();
                if (result > 0)                
                    return Result.Sucess(order);

                return Result.Failure<Order>(RepositoryErrors.UnableToCreateOrder);
            }
            catch (Exception ex)
            {
                return Result.Failure<Order>(RepositoryErrors.GeneralException(ex.Message));
            }
        }

        public async Task<Result<bool>> DeleteAsync(Guid orderNumber, CancellationToken cancellationToken)
        {
            try
            {
                Entities.Orders orderToDelete = new()
                {
                    OrderId = orderNumber
                };

                _dbContext.Orders.Remove(orderToDelete);

                var result = await _dbContext.SaveChangesAsync(cancellationToken);

                if (result > 0)
                    return Result.Sucess(true);
                else
                    return Result.Failure<bool>(RepositoryErrors.UnableToRemove);
            }
            catch (Exception ex)
            {
                return Result.Failure<bool>(RepositoryErrors.GeneralException(ex.Message));
            }
        }

        public async Task<Result<IQueryable<OrderDTO>>> GetAllAsync(CancellationToken cancellationToken)
        {
            try
            {
                IQueryable<OrderDTO> databaseResult = Enumerable.Empty<OrderDTO>().AsQueryable();

                var orders = await _dbContext.Orders.Include(ordprd => ordprd.ProductsOnOrder).ThenInclude(prd => prd.Product).ToListAsync(cancellationToken);

                if (orders.Count != 0)
                {
                    databaseResult = _mapper.Map<IQueryable<OrderDTO>>(orders);
                }
                return Result.Sucess(databaseResult);
            }
            catch (Exception ex)
            {
                return Result.Failure<IQueryable<OrderDTO>>(RepositoryErrors.RequestToDatabaseFailed(ex.Message));
            }
        }

        public async Task<Result<OrderDTO>> GetByIdAsync(Guid orderNumber, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _dbContext.Orders.FirstOrDefaultAsync(x => x.OrderId == orderNumber, cancellationToken);

                var resultMapped = _mapper.Map<OrderDTO>(result);

                return Result.Sucess(resultMapped);
            }
            catch (Exception ex)
            {
                return Result.Failure<OrderDTO>(RepositoryErrors.RequestToDatabaseFailed(ex.Message));
            }
        }

        public async Task<Result<Order>> UpdateAsync(Order order, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

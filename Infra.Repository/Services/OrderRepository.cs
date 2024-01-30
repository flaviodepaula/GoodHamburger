using AutoMapper;
using Domain.Orders.Models;
using Domain.Products.Enums;
using Domain.Products.Models;
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
            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    var resultMapped = new Entities.Orders()
                    {
                        OrderId = order.Id,
                        TotalAmount = order.Amount
                    };

                    await _dbContext.Orders.AddAsync(resultMapped, cancellationToken);
                    await _dbContext.SaveChangesAsync(cancellationToken);

                    var idsProducts = order.Products.Select(x => x.Id).ToList();

                    foreach (var idProd in idsProducts)
                    {
                        var orderProduct = new Entities.OrdersProducts()
                        {
                            OrderId = order.Id,
                            ProductId = idProd
                        };

                        _dbContext.OrdersProducts.Add(orderProduct);
                    }
                    await _dbContext.SaveChangesAsync(cancellationToken);

                    transaction.Commit();

                    return Result.Sucess(order);
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return Result.Failure<Order>(RepositoryErrors.UnableToCreateOrder(ex.Message));
                }
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
                return Result.Failure<bool>(RepositoryErrors.DeleteGeneralException(ex.Message));
            }
        }

        public async Task<Result<IEnumerable<OrderDTO>>> GetAllAsync(CancellationToken cancellationToken)
        {
            try
            {
                List<OrderDTO> orderList = new List<OrderDTO>();

                var orders = await _dbContext.Orders.Include(ordprd => ordprd.ProductsOnOrder).ThenInclude(prd => prd.Product).ToListAsync(cancellationToken);

                if (orders.Count != 0)
                {
                    foreach (var order in orders)
                    {
                        orderList.Add(new OrderDTO()
                        {
                            Id = order.OrderId,
                            Amount = order.TotalAmount,
                            Products = order.ProductsOnOrder.Select(p =>
                                                    new Product(p.ProductId, p.Product.Description,
                                                                p.Product.Value,
                                                                Enum.Parse<enumProductCategory>(p.Product.Category),
                                                                Enum.Parse<enumProductCategoryType>(p.Product.CategoryType)))
                        });
                    }
                }
                return Result.Sucess(orderList.AsEnumerable());
            }
            catch (Exception ex)
            {
                return Result.Failure<IEnumerable<OrderDTO>>(RepositoryErrors.RequestToDatabaseFailed(ex.Message));
            }
        }

        public async Task<Result<OrderDTO>> GetByIdAsync(Guid orderNumber, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _dbContext.Orders.FirstOrDefaultAsync(x => x.OrderId == orderNumber, cancellationToken);

                var resultMapped = _mapper.Map<OrderDTO>(result);

                if(resultMapped == null) {
                    return Result.Failure<OrderDTO>(RepositoryErrors.OrderDoesNotExists);
                }

                return Result.Sucess(resultMapped);
            }
            catch (Exception ex)
            {
                return Result.Failure<OrderDTO>(RepositoryErrors.RequestToDatabaseFailed(ex.Message));
            }
        }

        public async Task<Result<Order>> UpdateAsync(Order order, CancellationToken cancellationToken)
        {
            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {  
                    var actualOrder = await _dbContext.Orders
                        .Include(x=> x.ProductsOnOrder)
                        .FirstOrDefaultAsync(y=> y.OrderId == order.Id, cancellationToken);

                    if(actualOrder == null)                    
                        return Result.Failure<Order>(RepositoryErrors.OrderDoesNotExists);

                    actualOrder.ProductsOnOrder.Clear();

                    var newProdutcs = order.Products.Select(x => new Entities.OrdersProducts()
                    {
                        OrderId = order.Id,
                        ProductId = x.Id
                    });

                    foreach(var p in newProdutcs)
                    {
                        actualOrder.ProductsOnOrder.Add(p);
                    }

                    actualOrder.TotalAmount = order.Amount;

                    await _dbContext.SaveChangesAsync(cancellationToken);
                      
                    transaction.Commit();

                    return Result.Sucess(order);
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return Result.Failure<Order>(RepositoryErrors.UnableToUpdateOrder(ex.Message));
                }
            }
        }
    }
}

using AutoMapper;
using Domain.Products.Enums;
using Domain.Products.Models;
using Infra.Common.Result;
using Infra.Repository.Context;
using Infra.Repository.Errors;
using Infra.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Net.Sockets;

namespace Infra.Repository.Services
{
    public class ProductRepository : IProductRepository
    {
        private readonly GoodHamburgerDbContext _dbContext;
        private readonly IMapper _mapper;

        public ProductRepository(IMapper mapper, GoodHamburgerDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public async Task<Result<IEnumerable<Product>>> GetAllProductsByTypeAsync(IEnumerable<enumProductCategoryType> categories, CancellationToken cancellationToken)
        {
            try
            {
                var stringCategories = categories.Select(x => x.ToString()).ToList();

                IEnumerable<Product> databaseResult = Enumerable.Empty<Product>();
                var result = await _dbContext.Products.Where(x => stringCategories.Contains(x.CategoryType)).ToListAsync(cancellationToken);

                if (result.Count != 0)
                {
                    databaseResult = _mapper.Map<IEnumerable<Product>>(result);
                }
                return Result.Sucess(databaseResult);
            }
            catch (Exception ex)
            {
                return Result.Failure<IEnumerable<Product>>(RepositoryErrors.RequestToDatabaseFailed(ex.Message));
            }
        }

        public async Task<Result<IEnumerable<Product>>> GetProductDetailsListAsync(IEnumerable<Product> products, CancellationToken cancellationToken)
        {
            try
            {
                var productNames = products.Select(x=> x.Description).ToList();

                IEnumerable<Product> databaseResult = Enumerable.Empty<Product>();
                var result = await _dbContext.Products.Where(x => productNames.Contains(x.Description)).ToListAsync(cancellationToken);
                if (result.Count != 0)
                {
                    databaseResult = _mapper.Map<IEnumerable<Product>>(result);
                }
                return Result.Sucess(databaseResult);
            }
            catch (Exception ex)
            {
                return Result.Failure<IEnumerable<Product>>(RepositoryErrors.RequestToDatabaseFailed(ex.Message));
            }
        }      
    }
}

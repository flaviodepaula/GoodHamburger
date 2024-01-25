using AutoMapper;
using Domain.Models.Products;
using Infra.Common.Result;
using Infra.Repository.Context;
using Infra.Repository.Entities;
using Infra.Repository.Errors;
using Infra.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infra.Repository.Services
{
    public class ProductRepository : IProductRepository
    {
        private readonly GoodHamburgerDbContext _dbContext;

        private readonly ILogger<ProductRepository> _logger;
        private readonly IMapper _mapper;

        public ProductRepository(ILogger<ProductRepository> logger, IMapper mapper, GoodHamburgerDbContext dbContext)
        {
            _logger = logger;
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public async Task<Result<IEnumerable<Product>>> GetAllProductsByType(IEnumerable<enumProductCategory> categories)
        {
            try
            {
                var stringCategories = categories.Select(x=> x.ToString()).ToList();

                IEnumerable<Product> databaseResult = Enumerable.Empty<Product>();
                var result = await _dbContext.Products.Where(x => stringCategories.Contains(x.Category)).ToListAsync();

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

        public async Task<Result<IEnumerable<Product>>> GetProductDetailsList(IEnumerable<Product> products)
        {
            try
            {
                IEnumerable<Product> databaseResult = Enumerable.Empty<Product>();
                var result = await _dbContext.Products.Where(x => products.All(z => z.Id == x.ProductId)).ToListAsync();
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

        public Task<Result<IEnumerable<Product>>> GetProdutcsPriceAsync(Guid orderNumber)
        {
            throw new NotImplementedException();
        }
    }
}

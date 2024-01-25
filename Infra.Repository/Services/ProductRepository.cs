﻿using AutoMapper;
using Domain.Models.Products;
using Infra.Common.Result;
using Infra.Repository.Context;
using Infra.Repository.Errors;
using Infra.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

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
                IEnumerable<Product> databaseResult = Enumerable.Empty<Product>();
                var result = await _dbContext.Products.Where(x => products.All(z => z.Id == x.ProductId)).ToListAsync(cancellationToken);
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

        public Task<Result<IEnumerable<Product>>> GetProdutcsPriceAsync(Guid orderNumber, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

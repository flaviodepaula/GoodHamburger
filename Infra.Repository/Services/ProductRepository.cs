using AutoMapper;
using Domain.Models.Products;
using Infra.Common.Result;
using Infra.Repository.Interfaces;
using Microsoft.Extensions.Logging;

namespace Infra.Repository.Services
{
    public class ProductRepository : IProductRepository
    {
        private readonly ILogger<ProductRepository> _logger;
        private readonly IMapper _mapper;

        public ProductRepository(ILogger<ProductRepository> logger, IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
        }

        public Task<Result<IEnumerable<Product>>> GetAllProductsByType(IEnumerable<enumProductCategory> categories)
        {
            throw new NotImplementedException();
        }

        public Task<Result<IEnumerable<Product>>> GetProductDetailsList(IEnumerable<Product> products)
        {
            throw new NotImplementedException();
        }

        public Task<Result<IEnumerable<Product>>> GetProdutcsPriceAsync(Guid orderNumber)
        {
            throw new NotImplementedException();
        }
    }
}

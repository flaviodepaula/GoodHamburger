using AutoMapper;
using Infra.Common.Result;
using Infra.Repository.Entities;
using Infra.Repository.Interfaces;
using Microsoft.Extensions.Logging;

namespace Infra.Repository.Services
{
    public class RepositoryService : IProductRepository
    {
        private readonly ILogger<RepositoryService> _logger;
        private readonly IMapper _mapper;

        public RepositoryService(ILogger<RepositoryService> logger, IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
        }

        public Task<Result<Order>> CreateOrderAync(Order order)
        {
            throw new NotImplementedException();
        }

        public Task<Result<bool>> DeleteOrderAsync(Guid orderNumber)
        {
            throw new NotImplementedException();
        }

        public Task<Result<IEnumerable<Order>>> GetAllOrdersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Result<IEnumerable<Product>>> GetAllProductsByType(IEnumerable<CategoryOfProduct> categories)
        {
            throw new NotImplementedException();
        }

        public Task<Result<Order>> GetOrderByIdAsync(Guid orderNumber)
        {
            throw new NotImplementedException();
        }

        public Task<Result<Product>> GetProdutcs()
        {
            throw new NotImplementedException();
        }

        public Task<Result<IEnumerable<Product>>> GetProdutcsPriceAsync(Guid orderNumber)
        {
            throw new NotImplementedException();
        }

        public Task<Result<Order>> UpdateOrderAsync(Order order)
        {
            throw new NotImplementedException();
        }
    }
}

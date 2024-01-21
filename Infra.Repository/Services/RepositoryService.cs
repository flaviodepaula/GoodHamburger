using AutoMapper;
using Infra.Common.Result;
using Infra.Repository.Entities;
using Infra.Repository.Interfaces;
using Microsoft.Extensions.Logging;

namespace Infra.Repository.Services
{
    public class RepositoryService : IRepository
    {
        private readonly ILogger<RepositoryService> _logger;
        private readonly IMapper _mapper;

        public RepositoryService(ILogger<RepositoryService> logger, IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
        }

        public Task<Result<OrderDTO>> CreateOrderAync(OrderDTO order)
        {
            throw new NotImplementedException();
        }

        public Task<Result<bool>> DeleteOrderAsync(Guid orderNumber)
        {
            throw new NotImplementedException();
        }

        public Task<Result<IEnumerable<OrderDTO>>> GetAllOrdersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Result<IEnumerable<ProductDTO>>> GetAllProductsByType(IEnumerable<CategoryOfProduct> categories)
        {
            throw new NotImplementedException();
        }

        public Task<Result<OrderDTO>> GetOrderByIdAsync(Guid orderNumber)
        {
            throw new NotImplementedException();
        }

        public Task<Result<ProductDTO>> GetProdutcs()
        {
            throw new NotImplementedException();
        }

        public Task<Result<IEnumerable<ProductDTO>>> GetProdutcsPriceAsync(Guid orderNumber)
        {
            throw new NotImplementedException();
        }

        public Task<Result<OrderDTO>> UpdateOrderAsync(OrderDTO order)
        {
            throw new NotImplementedException();
        }
    }
}

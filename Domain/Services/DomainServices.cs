using AutoMapper;
using Domain.Errors;
using Domain.Interfaces;
using Domain.Models;
using Infra.Common.Result;
using Infra.Repository.Interfaces;
using Microsoft.Extensions.Logging;

namespace Domain.Services
{
    public class DomainServices : IDomain
    {
        private readonly IRepository _repository;
        private readonly ILogger<DomainServices> _logger;
        private readonly IMapper _mapper;

        public DomainServices(IRepository repository, ILogger<DomainServices> logger, IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<Result<decimal>> CalculateAmmount(Order order)
        {
            
            var ordem = await GetDataFromDatabase(order);

            if (ordem.IsFailure)
                return Result.Failure<decimal>(ordem.Error);
             
            return ordem.Value.Amount;
        }

        private async Task<Result<Order>> GetDataFromDatabase(Order order)
        {
            var responseProductsModel = _mapper.Map<IEnumerable<Infra.Repository.Models.Product>>(order.Products);

            var dbProducts = await _repository.GetProdutcsPrice(responseProductsModel);

            if (dbProducts.IsFailure)
                return Result.Failure<Order>(DomainErrors.RequestToDatabaseFailed);

            foreach (var ordemProduct in order.Products)
            {
                var prd = dbProducts.Value.FirstOrDefault(p => p.Description == ordemProduct.Name);

                if (prd == null)
                    return Result.Failure<Order>(DomainErrors.ProductDoNotExistOnDatabase);

                ordemProduct.UpdatePrice(prd.Value);
            }

            return order;
        }
    }
}

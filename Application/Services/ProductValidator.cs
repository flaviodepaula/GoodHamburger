using Domain.Interfaces;
using Domain.Models.Products;
using Infra.Common.Result;
using Infra.Repository.Interfaces;

namespace Application.Services
{
    public class ProductValidator : IProductValidator
    {
        private readonly IProductRepository _repository;

        public ProductValidator(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<bool>> IsValidAsync(IEnumerable<Product> products, CancellationToken cancellationToken)
        {
            var result = await _repository.GetProductDetailsListAsync(products, cancellationToken);

            if (result.IsFailure)
                return Result.Failure<bool>(result.Error);

            //todo: make a true validation. 
            return result.Value.Count() == products.Count();
        }
    }
}

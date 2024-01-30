using Domain.Products.Enums;
using Domain.Products.Models;
using Infra.Common.Result;
using Infra.Repository.Interfaces;

namespace Application.Products
{
    public class ProductApplication : IProductApplication
    {
        public readonly IProductRepository _repository;
        public ProductApplication(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<IEnumerable<Product>>> GetAllExtrasAsync(CancellationToken cancellationToken)
        {
            var types = new List<enumProductCategoryType>
            {
                enumProductCategoryType.Extras
            };

            var result = await _repository.GetAllProductsByTypeAsync(types, cancellationToken);

            if (result.IsFailure)
                return Result.Failure<IEnumerable<Product>>(result.Error);

            return result.Value.ToList();
        }

        public async Task<Result<IEnumerable<Product>>> GetAllSandwichesAndExtrasAsync(CancellationToken cancellationToken)
        {
            var types = new List<enumProductCategoryType>
            {
                enumProductCategoryType.Sandwich,
                enumProductCategoryType.Extras
            };

            var result = await _repository.GetAllProductsByTypeAsync(types, cancellationToken);

            if (result.IsFailure)
                return Result.Failure<IEnumerable<Product>>(result.Error);

            return result.Value.ToList();
        }

        public async Task<Result<IEnumerable<Product>>> GetAllSandwichesAsync(CancellationToken cancellationToken)
        {
            var types = new List<enumProductCategoryType>
            {
                enumProductCategoryType.Sandwich
            };

            var result = await _repository.GetAllProductsByTypeAsync(types, cancellationToken);

            if (result.IsFailure)
                return Result.Failure<IEnumerable<Product>>(result.Error);

            return result.Value.ToList();
        }

    }
}

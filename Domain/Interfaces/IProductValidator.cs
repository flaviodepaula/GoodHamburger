using Domain.Models.Products;
using Infra.Common.Result;

namespace Domain.Interfaces
{
    public interface IProductValidator
    {
        Task<Result<bool>> IsValidAsync(IEnumerable<Product> products, CancellationToken cancellationToken);
    }
}
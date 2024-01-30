using Domain.Products.Models;
using Infra.Common.Result;

namespace Domain.Products.Interfaces
{
    public interface IProductValidator
    {
        Task<Result<bool>> IsValidAsync(IEnumerable<Product> products, CancellationToken cancellationToken);
    }
}
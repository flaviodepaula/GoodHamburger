using Domain.Models.Products;
using Infra.Common.Result;

namespace Domain.Interfaces
{
    public interface IProductValidator
    {
        Task<Result<bool>> IsValid(IEnumerable<Product> products);
    }
}
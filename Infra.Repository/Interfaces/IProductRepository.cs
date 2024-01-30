using Domain.Products.Enums;
using Domain.Products.Models;
using Infra.Common.Result;

namespace Infra.Repository.Interfaces
{
    public interface IProductRepository
    {            
        Task<Result<IEnumerable<Product>>> GetAllProductsByTypeAsync(IEnumerable<enumProductCategoryType> categories, CancellationToken cancellationToken);
        Task<Result<IEnumerable<Product>>> GetProductDetailsListAsync(IEnumerable<Product> products, CancellationToken cancellationToken);
    }
}

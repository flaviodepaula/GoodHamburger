using Domain.Models.Products;
using Infra.Common.Result;

namespace Infra.Repository.Interfaces
{
    public interface IProductRepository
    {
        Task<Result<IEnumerable<Product>>> GetProdutcsPriceAsync(Guid orderNumber);        
        Task<Result<IEnumerable<Product>>> GetAllProductsByType(IEnumerable<enumProductCategoryType> categories);
        Task<Result<IEnumerable<Product>>> GetProductDetailsList(IEnumerable<Product> products);
    }
}

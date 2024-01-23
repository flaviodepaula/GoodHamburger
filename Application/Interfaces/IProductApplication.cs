using Domain.Models.Products;
using Infra.Common.Result;

namespace Application.Interfaces
{
    public interface IProductApplication
    {
        Task<Result<IEnumerable<Product>>> GetAllSandwichesAndExtrasAsync();
        Task<Result<IEnumerable<Product>>> GetAllSandwichesAsync();
        Task<Result<IEnumerable<Product>>> GetAllExtrasAsync();
    }
}

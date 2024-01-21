using Domain.Models.Products;
using Infra.Common.Result;

namespace Domain.Interfaces
{
    public interface IProductsDomain
    {        
        Task<Result<IEnumerable<Product>>> GetAllSandwichesAndExtrasAsync();
        Task<Result<IEnumerable<Product>>> GetAllSandwichesAsync();
        Task<Result<IEnumerable<Product>>> GetAllExtrasAsync();
       
    }
}

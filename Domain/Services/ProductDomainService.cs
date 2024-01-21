using Domain.Interfaces;
using Domain.Models.Order;
using Domain.Models.Products;
using Infra.Common.Result;

namespace Domain.Services
{
    public class ProductDomainService : IProductsDomain
    {
        public Task<Result<IEnumerable<Product>>> GetAllExtrasAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Result<IEnumerable<Product>>> GetAllSandwichesAndExtrasAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Result<IEnumerable<Product>>> GetAllSandwichesAsync()
        {
            throw new NotImplementedException();
        }
    }
}

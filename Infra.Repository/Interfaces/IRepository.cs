using Infra.Common.Result;
using Infra.Repository.Models;

namespace Infra.Repository.Interfaces
{
    public interface IRepository
    {
        Task<Result<IEnumerable<Product>>> GetProdutcsPrice(IEnumerable<Product> products);
    }
}

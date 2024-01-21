using Infra.Common.Result;
using Infra.Repository.Entities;

namespace Infra.Repository.Interfaces
{
    public interface IRepository
    {
        Task<Result<IEnumerable<ProductDTO>>> GetProdutcsPriceAsync(Guid orderNumber);
        Task<Result<OrderDTO>> GetOrderByIdAsync(Guid orderNumber);

        Task<Result<IEnumerable<ProductDTO>>> GetAllProductsByType(IEnumerable<CategoryOfProduct> categories);
        Task<Result<IEnumerable<ProductDTO>>> GetProductDetailsList(IEnumerable<ProductDTO> products);
        
        Task<Result<IEnumerable<OrderDTO>>> GetAllOrdersAsync();

        Task<Result<OrderDTO>> CreateOrderAync(OrderDTO order);

        Task<Result<OrderDTO>> UpdateOrderAsync(OrderDTO order);

        Task<Result<bool>> DeleteOrderAsync(Guid orderNumber);
    }
}

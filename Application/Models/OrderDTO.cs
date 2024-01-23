using Domain.Models.Products;

namespace Application.Models
{
    public class OrderDTO
    {
        public IEnumerable<Product> Products { get; private set; }
    }
}

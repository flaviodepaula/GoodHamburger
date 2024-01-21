using Domain.Models.Products;

namespace Domain.Models.Order
{
    public class CreateOrderCommand
    {
        public IEnumerable<Product> Products { get; private set; }
    }
}

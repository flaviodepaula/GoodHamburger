using Domain.Models.Products;

namespace Domain.Models.Order
{
    public record OrderDTO
    {
        public Guid Id { get; }
        public IEnumerable<Product> Products { get; set; }
        public decimal Amount { get; set; }
    }
}

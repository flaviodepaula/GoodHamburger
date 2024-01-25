using Domain.Models.Products;

namespace Domain.Models.Order
{
    public record OrderDTO
    {
        public Guid Id { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public decimal Amount { get; set; }
    }
}

using Domain.Products.Models;

namespace Domain.Orders.Models
{
    public record OrderDTO
    {
        public Guid Id { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public decimal Amount { get; set; }
    }
}

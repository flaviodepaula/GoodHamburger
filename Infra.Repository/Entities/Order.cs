using System.ComponentModel.DataAnnotations;

namespace Infra.Repository.Entities
{
    public record Order
    {
        [Key]
        public Guid OrderId { get; set; }
        public IEnumerable<Product> Products { get; set; }        
        public decimal TotalAmount { get; set; }
    }
}

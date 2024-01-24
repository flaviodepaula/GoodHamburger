using System.ComponentModel.DataAnnotations;

namespace Infra.Repository.Entities
{
    public class Products
    {
        [Key]
        public Guid ProductId { get; set; }
        public string Description { get; set; }
        public decimal Value { get; set; }
        public string Category { get; set; }
        public IEnumerable<OrdersProducts> OrdersProducts { get; set; }

        public Products()
        {
            
        }
    }
}

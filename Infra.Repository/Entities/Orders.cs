using System.ComponentModel.DataAnnotations;

namespace Infra.Repository.Entities
{
    public class Orders
    {
        [Key]
        public Guid OrderId { get; set; }
        public decimal TotalAmount { get; set; }
        public ICollection<OrdersProducts> ProductsOnOrder { get; set; }
        public Customer Customer { get; set; }
        public Orders()
        {
            
        }
    }
}

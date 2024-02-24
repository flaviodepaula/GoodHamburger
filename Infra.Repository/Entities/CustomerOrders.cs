namespace Infra.Repository.Entities
{
    public class CustomerOrders
    {
        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; }  
        public Guid OrderId { get; set; }
        public Orders Orders { get; set; }
    }
}

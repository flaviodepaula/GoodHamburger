namespace Infra.Repository.Entities
{
    public sealed class Customer
    {
        public Guid CustomerId { get; set; }
        public string Name { get; set; }
        public Address? Address { get; set; }
        public ICollection<CustomerOrders>? Orders { get; set; }
    }
}

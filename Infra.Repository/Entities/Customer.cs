namespace Infra.Repository.Entities
{
    public sealed class Customer
    {
        public Guid CustomerId { get; set; }
        public string Name { get; }
        public Address? Address { get; }
        public string Email {  get; }
        public string PhoneNumber { get; }
        public bool Active { get; }
        public ICollection<CustomerOrders>? Orders { get; }

        public Customer()
        {
            
        }
    }
}

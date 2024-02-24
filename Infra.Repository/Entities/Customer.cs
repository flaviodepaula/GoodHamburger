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

        public Customer(Guid customerId, string name, string email, string phoneNumber, Address address)
        {
            CustomerId = customerId;
            Name = name;
            Email = email;
            PhoneNumber = phoneNumber;
            Address = address;
        }

        public Customer(Guid customerId)
        {
            CustomerId = customerId;
        }
         
    }
}

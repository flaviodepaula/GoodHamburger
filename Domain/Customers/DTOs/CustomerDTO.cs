namespace Domain.Customers.DTOs
{
    public record CustomerDTO
    {
        public Guid CustomerId { get; set; }
        public string? Name { get; set; }
        public AddressDTO? Address { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public bool? Active { get; set; }
    }
}

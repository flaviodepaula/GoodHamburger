namespace Infra.Repository.Entities
{
    public record OrderDTO
    {
        public Guid OrderId { get; set; }
        public IEnumerable<ProductDTO> Products { get; set; }
        
        public decimal TotalAmount { get; set; }
    }
}

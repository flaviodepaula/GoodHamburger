namespace WebApi.Models
{
    public record UpdateProductViewModel
    {
        public Guid Id { get; set; }
        public IEnumerable<RequestProduct> Products { get; set; }

        public UpdateProductViewModel(IEnumerable<RequestProduct> products)
        {
             Products = products;
        }
    }
}

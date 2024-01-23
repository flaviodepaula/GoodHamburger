using Domain.Models.Products;

namespace WebApi.Models
{
    public record RequestProductViewModel
    {
        public RequestProductViewModel(IEnumerable<RequestProduct> products)
        {
            Products = products;
        }

        public IEnumerable<RequestProduct> Products { get; set; }        
    }

    public record RequestProduct
    {
        public string Name { get; set; }
        public enumProductCategory Category { get; set; }
        public RequestProduct(string name, enumProductCategory category)
        {
            Name = name;
            Category = category;
        }
    }
}

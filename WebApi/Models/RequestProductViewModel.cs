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
        public ProductCategory Category { get; set; }
        public RequestProduct(string name, ProductCategory category)
        {
            Name = name;
            Category = category;
        }
    }
}

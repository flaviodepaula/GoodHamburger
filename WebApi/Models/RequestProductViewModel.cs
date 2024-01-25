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
        public string Description { get; set; }
        public enumProductCategoryType Category { get; set; }
        public RequestProduct(string description, enumProductCategoryType category)
        {
            Description = description;
            Category = category;
        }
    }
}

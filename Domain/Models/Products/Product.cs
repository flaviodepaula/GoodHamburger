using Domain.Models.Products;

namespace Domain.Models.Products
{
    public class Product
    {
        public Product(Guid id, string? name, decimal value, enumProductCategory category, enumProductCategoryType categoryType)
        {
            Id = id;
            Description = name;
            Value = value;
            Category = category;
            CategoryType = categoryType;
        }

        public Product()
        {                
        }
        public Guid Id { get; set; }
        public string? Description { get; set; }
        public decimal Value { get; set; }
        public enumProductCategory Category { get; set; }
        public enumProductCategoryType CategoryType { get; set; }

    }
}
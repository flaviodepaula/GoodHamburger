namespace Domain.Models.Products
{
    public class Product
    {
        public Product(string? name, decimal value, ProductCategory caterogy)
        {
            Name = name;
            Value = value;
            Caterogy = caterogy;
        }

        public string? Name { get; set; }
        public decimal Value { get; set; }
        public ProductCategory Caterogy { get; set; }
     
    }
}
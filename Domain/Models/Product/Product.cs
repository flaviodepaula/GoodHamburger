namespace Domain.Models.Products
{
    public class Product
    {
        public Product(string? name, decimal value, enumProductCategory caterogy)
        {
            Name = name;
            Value = value;
            Caterogy = caterogy;
        }

        public string? Name { get; set; }
        public decimal Value { get; set; }
        public enumProductCategory Caterogy { get; set; }
     
    }
}
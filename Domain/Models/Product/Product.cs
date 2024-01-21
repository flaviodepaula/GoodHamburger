namespace Domain.Models.Products
{
    public class Product
    {
        private decimal _value;
        public string? Name { get; set; }
        public decimal Value => _value;
        public CategoryOfProduct Caterogy { get; set; }

        public void UpdatePrice(decimal price)
        {
            _value = price;
        }

    }
}
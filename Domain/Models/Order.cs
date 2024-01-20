using Domain.DiscountClasses;

namespace Domain.Models
{
    public class Order
    {
        public Guid Id { get; }
        public IEnumerable<Product> Products { get; private set; }
        public decimal Amount { 
            get
            {
                decimal totalAmount = Products.Sum(x=> x.Value);

                var discount3Items = new Discount3Items();
                var discountSandwichDrink = new DiscountSandwichDrink();
                var discountSandwichFries = new DiscountSandwichFries();

                discount3Items.SetNext(discountSandwichDrink);
                discountSandwichDrink.SetNext(discountSandwichFries);

                decimal totalDiscount = discount3Items.GetDiscount(this);

                totalAmount -= totalDiscount;

                return totalAmount;
            }
        }

        private Order(List<Product> products)
        {
            this.Id = Guid.NewGuid();
            this.Products = products;
        }

        public static Order? CreateOrder(List<Product> products)
        {
            if(products == null || products.Count == 0)
            {
                return null;
            } 

            return new Order(products);
        }
    }
}

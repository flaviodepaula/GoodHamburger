using Domain.DiscountClasses;
using Domain.Errors;
using Infra.Common.Result;
using Domain.Models.Products;

namespace Domain.Models.Order
{
    public sealed class Order
    {
        private decimal _amount;

        public Guid Id { get; }
        public IEnumerable<Product> Products { get; private set; }
        public decimal Amount => _amount;

        private Order(IEnumerable<Product> products)
        {
            Id = Guid.NewGuid();
            Products = products;
        }

        public static Result<Order> CreateOrder(IEnumerable<Product> products)
        {
            if (products == null || !products.Any())
                return Result.Failure<Order>(DomainErrors.OrderWithoutProducts);

            var groupByCategory = from product in products
                                  group product by product.Caterogy into categoryGroup
                                  select categoryGroup;

            var hasDuplicated = groupByCategory.All(x => x.Count() > 1);
            if (hasDuplicated)
                return Result.Failure<Order>(DomainErrors.DuplicatedItems);

            return new Order(products);
        }

        public void CalculateAmount()
        {
            decimal totalAmount = Products.Sum(x => x.Value);

            var discount3Items = new Discount3Items();
            var discountSandwichDrink = new DiscountSandwichDrink();
            var discountSandwichFries = new DiscountSandwichFries();

            discount3Items.SetNext(discountSandwichDrink);
            discountSandwichDrink.SetNext(discountSandwichFries);

            decimal totalDiscount = discount3Items.GetDiscount(this);

            _amount = totalAmount - totalDiscount;

        }
    }
}

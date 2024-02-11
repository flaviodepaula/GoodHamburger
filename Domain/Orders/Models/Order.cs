using Domain.Orders.DiscountClasses;
using Domain.Support;
using Infra.Common.Result;
using Domain.Products.Models;

namespace Domain.Orders.Models
{
    public sealed class Order
    {
        private decimal _amount;
        public Guid Id { get; }
        public IEnumerable<Product> Products { get; private set; }
        public decimal Amount
        {
            get { return _amount; }
        }

        private Order(Guid id, IEnumerable<Product> products)
        {
            Id = id;
            Products = products;
        }

        public static Result<Order> CreateOrder(Guid id, IEnumerable<Product> products)
        {
            if (products == null || !products.Any())
                return Result.Failure<Order>(DomainErrors.OrderErrors.OrderWithoutProducts);

            var groupByCategory = from product in products
                                  group product by product.Category into categoryGroup
                                  select categoryGroup;

            var hasDuplicated = groupByCategory.All(x => x.Count() > 1);
            if (hasDuplicated)
                return Result.Failure<Order>(DomainErrors.OrderErrors.DuplicatedItems);

            var newOrder = new Order(id, products);
            newOrder.CalculateAmount();

            return newOrder;
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

using Domain.DiscountClasses;
using Domain.Errors;
using Domain.Interfaces;
using Domain.Models.Products;
using Infra.Common.Result;

namespace Domain.Models.Order
{
    public sealed class Order
    {
        private readonly IProductValidator _productValidator;
        private decimal _amount;

        public Guid Id { get; }
        public IEnumerable<Product> Products { get; private set; }
        public decimal Amount
        {
            get { return _amount; }
        }

        private Order(IEnumerable<Product> products)
        {
            Id = Guid.NewGuid();
            Products = products;
        }

        public Order(IProductValidator productValidator)
        {
            _productValidator = productValidator;
        }

        public static async Task<Result<Order>> CreateOrder(IEnumerable<Product> products)
        {
            if (products == null || !products.Any())
                return Result.Failure<Order>(DomainErrors.OrderWithoutProducts);

            var groupByCategory = from product in products
                                  group product by product.Caterogy into categoryGroup
                                  select categoryGroup;

            var hasDuplicated = groupByCategory.All(x => x.Count() > 1);
            if (hasDuplicated)
                return Result.Failure<Order>(DomainErrors.DuplicatedItems);

            var newOrder = new Order(products);
            var isValid = await newOrder._productValidator.IsValid(products);
            if (isValid.IsFailure)            
                return Result.Failure<Order>(DomainErrors.DuplicatedItems);
            
            newOrder.CalculateAmount();

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

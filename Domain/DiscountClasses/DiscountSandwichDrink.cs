using Domain.Models.Order;
using Domain.Models.Products;

namespace Domain.DiscountClasses
{
    public class DiscountSandwichDrink : DiscountHandler
    {
        public override decimal GetDiscount(Order order)
        {
            decimal discount = 0;

            if (order.Products.Any(x => x.Caterogy == ProductCategory.Sandwich) &&               
                order.Products.Any(x => x.Caterogy == ProductCategory.Drink))
            {
                var amount = order.Products.Sum(x => x.Value);

                discount = amount * 0.15m;
            }
            else
            {
                if (_next != null)
                {
                    discount = _next.GetDiscount(order);
                }
            }

            return discount;
        }
    }
}

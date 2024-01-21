using Domain.Models.Order;
using Domain.Models.Products;

namespace Domain.DiscountClasses
{
    public class Discount3Items : DiscountHandler
    {
        public override decimal GetDiscount(Order order)
        {
            decimal discount = 0;

            if (order.Products.Any(x => x.Caterogy == ProductCategory.Sandwich) &&
               order.Products.Any(x => x.Caterogy == ProductCategory.Fries) &&
               order.Products.Any(x => x.Caterogy == ProductCategory.Drink))
            {
                var amount = order.Products.Sum(x => x.Value);

                discount = amount * 0.2m;
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

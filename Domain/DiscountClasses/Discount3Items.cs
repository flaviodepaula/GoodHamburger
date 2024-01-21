using Domain.Models.Order;
using Domain.Models.Products;

namespace Domain.DiscountClasses
{
    public class Discount3Items : DiscountHandler
    {
        public override decimal GetDiscount(Order order)
        {
            decimal discount = 0;

            if (order.Products.Any(x => x.Caterogy == CategoryOfProduct.Sandwich) &&
               order.Products.Any(x => x.Caterogy == CategoryOfProduct.Fries) &&
               order.Products.Any(x => x.Caterogy == CategoryOfProduct.Drink))
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

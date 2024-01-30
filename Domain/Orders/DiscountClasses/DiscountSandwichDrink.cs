using Domain.Orders.Models;
using Domain.Products.Enums;

namespace Domain.Orders.DiscountClasses
{
    public class DiscountSandwichDrink : DiscountHandler
    {
        public override decimal GetDiscount(Order order)
        {
            decimal discount = 0;

            if (order.Products.Any(x => x.Category == enumProductCategory.Sandwich) &&               
                order.Products.Any(x => x.Category == enumProductCategory.SoftDrink))
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

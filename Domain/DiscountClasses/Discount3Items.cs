﻿using Domain.Models;

namespace Domain.DiscountClasses
{
    public class Discount3Items : DiscountHandler
    {
        public override decimal GetDiscount(Order order)
        {
            decimal discount = 0;

            if (order.Products.Any(x => x.Caterogy == CaterogyOfProduct.Sandwich) &&
               order.Products.Any(x => x.Caterogy == CaterogyOfProduct.Fries) &&
               order.Products.Any(x => x.Caterogy == CaterogyOfProduct.Drink))
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

﻿using Domain.Orders.Models;
using Domain.Products.Enums;

namespace Domain.Orders.DiscountClasses
{
    public class DiscountSandwichFries : DiscountHandler
    {
        public override decimal GetDiscount(Order order)
        {
            decimal discount = 0;

            if (order.Products.Any(x => x.Category == enumProductCategory.Sandwich) &&
                order.Products.Any(x => x.Category == enumProductCategory.Fries))
            {
                var amount = order.Products.Sum(x => x.Value);

                discount = amount * 0.1m;
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

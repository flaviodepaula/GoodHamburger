using Domain.Orders.Models;

namespace Domain.Orders.DiscountClasses
{
    public abstract class DiscountHandler
    {
        protected DiscountHandler _next;

        public void SetNext(DiscountHandler next)
        {
            _next = next;
        }

        public abstract decimal GetDiscount(Order order);
    }
}

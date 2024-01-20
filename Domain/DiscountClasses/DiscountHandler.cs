using Domain.Models;

namespace Domain.DiscountClasses
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

namespace Domain.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public Sandwich Sandwich { get; set; }
        public Drink Drink { get; set; }
        public Fries Fries { get; set; }
        public double Amount { get; set; }

        public Order(Sandwich sandwich, Drink drink, Fries fries, double amount)
        {
            Sandwich = sandwich;
            Drink = drink;
            Fries = fries;
            Amount = amount;
        }

        public double CalculateValue()
        {
            return 0;
        }
    }
}

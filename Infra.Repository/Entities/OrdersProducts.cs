namespace Infra.Repository.Entities
{
    public class OrdersProducts
    {
        public Guid OrderId { get; set; }
        public Orders Order { get; set; }

        public Guid ProductId { get; set; }
        public Products Product { get; set; }

    }
}

namespace Order.Model
{
    public class OrderItem : EntityBase
    {
        public long OrderId { get; set; }

        public long ProductId { get; set; }

        public int Unit { get; set; }

        public decimal Price { get; set; }
    }
}

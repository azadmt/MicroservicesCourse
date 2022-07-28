namespace OrderManagement.Contract
{
    public class OrderItemDto
    {
        public long OrderId { get; set; }

        public long ProductId { get; set; }

        public int Unit { get; set; }

        public decimal Price { get; set; }
    }
}

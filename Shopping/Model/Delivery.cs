namespace Shopping.Model
{
    public class Delivery : EntityBase
    {
        public long? CourierId { get; set; }
        public string Address { get; set; }
        public OrderStatus? Status { get; set; }
    }

}

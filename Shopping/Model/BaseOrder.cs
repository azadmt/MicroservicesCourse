namespace Shopping.Model
{
    public abstract class BaseOrder:EntityBase
    {
        public OrderStatus Status { get; set; }
    }
}

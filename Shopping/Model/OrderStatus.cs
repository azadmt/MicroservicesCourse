namespace Shopping.Model
{
    public enum OrderStatus
    {
        Submitted,
        StockConfirmed,
        Paid,
        Assigned,
        PickedUp,
        Delivered,
        Cancelled
    }

    public enum DeliveryStatus
    {
         Assigned,
        PickedUp,
        Delivered,
        Cancelled
    }
}

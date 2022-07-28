namespace Shopping.Model
{
    public enum OrderStatus
    {
        Submitted,
        AwaitingValidation,
        StockConfirmed,
        Paid,
        PickedUp,
        Delivered,
        Cancelled
    }
}

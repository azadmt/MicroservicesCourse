namespace OrderManagement.Model
{
    public enum OrderStatus
    {
        Submitted,
        AwaitingValidation,
        StockConfirmed,
        Paid,
        Shipped,
        Cancelled
    }
}

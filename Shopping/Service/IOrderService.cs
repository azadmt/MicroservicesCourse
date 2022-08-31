using Shopping.DataContract;

namespace Shopping.Service
{
    public interface IOrderService
    {
        void CreateOrder(OrderDto orderDto);
        void ApproveOrder(long ordrId);
        void RejectOrder(long ordrId);
    }
}
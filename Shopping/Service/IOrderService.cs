using Shopping.DataContract;

namespace Shopping.Service
{
    public interface IOrderService
    {
        void CreateOrder(OrderDto orderDto);
    }
}
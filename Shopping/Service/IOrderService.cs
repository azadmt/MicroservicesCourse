using Shopping.DataContract;
using System.Threading.Tasks;

namespace Shopping.Service
{
    public interface IOrderService
    {
        Task CreateOrder(OrderDto orderDto);
    }
}
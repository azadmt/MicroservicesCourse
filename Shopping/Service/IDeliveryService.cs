using System.Threading.Tasks;

namespace Shopping.Service
{
    public interface IDeliveryService
    {
        Task ScheduleDelivery(long id,string address);
    }
}
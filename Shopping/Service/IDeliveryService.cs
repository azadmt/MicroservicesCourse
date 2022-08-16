namespace Shopping.Service
{
    public interface IDeliveryService
    {
        void ScheduleDelivery(long id,string address);
    }
}
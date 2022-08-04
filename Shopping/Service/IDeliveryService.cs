namespace Shopping.Service
{
    public interface IDeliveryService
    {
        void ScheduleDelivery(long id);
        void Pickup(long id);
    }
}
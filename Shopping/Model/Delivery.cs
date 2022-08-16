using System.ComponentModel.DataAnnotations.Schema;

namespace Shopping.Model
{
    [Table("Deliveries", Schema = "DeliveryManagement")]
    public class Delivery : EntityBase
    {
        public long? CourierId { get; set; }
        public string Address { get; set; }
        public DeliveryStatus Status { get; set; }
    }

}

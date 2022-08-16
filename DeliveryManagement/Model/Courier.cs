using System.ComponentModel.DataAnnotations.Schema;

namespace DeliveryManagement.Model
{
    [Table("Couriers", Schema = "DeliveryManagement")]
    public class Courier : EntityBase
    {
        public bool IsAvailable { get; set; }

    }
}

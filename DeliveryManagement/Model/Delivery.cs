using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryManagement.Model
{
    [Table("Deliveries", Schema = "DeliveryManagement")]
    public class Delivery : EntityBase
    {
        public long? CourierId { get; set; }
        public long OrderId { get; set; }
        public string Address { get; set; }
        public DeliveryStatus Status { get; set; }
    }
}

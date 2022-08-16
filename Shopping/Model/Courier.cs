using System.ComponentModel.DataAnnotations.Schema;

namespace Shopping.Model
{
    [Table("Couriers", Schema = "Shopping")]
    public class Courier : EntityBase
    {
        public bool IsAvailable { get; set; }
       
    }
}

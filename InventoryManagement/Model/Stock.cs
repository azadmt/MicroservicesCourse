using System.ComponentModel.DataAnnotations;

namespace InventoryManagement.Model
{
    public class Stock
    {
        [Key]
        public long ProductId { get; set; }
        public int Quantity{ get; set; }
    }
}

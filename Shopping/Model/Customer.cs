using System.ComponentModel.DataAnnotations.Schema;

namespace Shopping.Model
{
    [Table("Customers", Schema = "Shopping")]
    public class Customer : EntityBase
    {
        public string Name { get; set; }
        public CustomerType Type { get; set; }
    }
}

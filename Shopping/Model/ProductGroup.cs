using System.ComponentModel.DataAnnotations.Schema;

namespace Shopping.Model
{
    [Table("ProductGroups", Schema = "Shopping")]

    public class ProductGroup : EntityBase
    {
        public string Name { get; set; }
    }
}
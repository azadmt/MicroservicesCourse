using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping.Model
{
    [Table("Products", Schema = "Shopping")]

    public class Product : EntityBase
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public long Quantity { get; set; }
        public long ProductGroupId { get; set; }
        public virtual ProductGroup ProductGroup { get; set; }
    }
}

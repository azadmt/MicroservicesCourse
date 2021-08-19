using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping.Model
{
    public class Product : EntityBase
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public long ProductGroupId { get; set; }
        public virtual ProductGroup ProductGroup { get; set; }
    }
}

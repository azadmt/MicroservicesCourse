using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shopping.Model
{
    [Table("Stocks", Schema = "Shopping")]

    public class Stock : EntityBase
    {
        public long ProductId { get; set; }

        public virtual Product Product { get; set; }


        public int Quantity { get; set; }

    }
}

using System;

namespace Shopping.Model
{
    public class Stock : EntityBase
    {
        public long ProductId { get; set; }

        public virtual Product Product { get; set; }


        public int Quantity { get; set; }

    }
}

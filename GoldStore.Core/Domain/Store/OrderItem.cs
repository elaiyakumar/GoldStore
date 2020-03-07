using System;

namespace GoldStore.Core.Domain.Store
{
    public class OrderItem : BaseEntity
    {         

        public int OrderId { get; set; }
        public int ProductId { get; set; }

        public int Quantity { get; set; }
        public decimal Cost { get; set; }

        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}

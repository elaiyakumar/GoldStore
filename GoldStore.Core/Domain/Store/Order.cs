using System;
using System.Collections.Generic;

namespace GoldStore.Core.Domain.Store
{
    public class Order : BaseEntity
    {
        private ICollection<OrderItem> _orderItems;

        public string OrderCode { get; set; }
        public int OrderStatusId { get; set; }
        public decimal OrderTotal { get; set; }
        public DateTime OrderDate { get; set; }

        public virtual ICollection<OrderItem> OrderItems
        {
            get { return _orderItems ?? (_orderItems = new List<OrderItem>()); }
            protected set { _orderItems = value; }
        }
    }
}

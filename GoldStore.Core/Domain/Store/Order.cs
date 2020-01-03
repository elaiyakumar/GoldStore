using System;

namespace GoldStore.Core.Domain.Store
{
    public class Order : BaseEntity
    {        
        public string OrderCode { get; set; }
        public int PoductId { get; set; }
        public int Quantity { get; set; }
        public double Cost { get; set; }
        public DateTime OrderDate { get; set; }
        //TODO : OrderItem         
    }
}

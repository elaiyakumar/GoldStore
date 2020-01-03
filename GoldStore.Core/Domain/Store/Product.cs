using System;

namespace GoldStore.Core.Domain.Store
{
    public class Product
    {
        public string Name { get; set; }
        public int BatchNum { get; set; }
        public double UnitPrice { get; set; }
        public DateTime ExpiryDate  { get; set; }
        public int Count { get; set; }
    }
}

using System;

namespace GoldStore.Core.Domain.Store
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int BatchNum { get; set; }
        public DateTime ExpiryDate  { get; set; }
        public int Count { get; set; }
    }
}

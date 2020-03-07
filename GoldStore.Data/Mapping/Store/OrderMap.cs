using GoldStore.Core.Domain.Store;
 

namespace GoldStore.Data.Mapping.Store
{
    public class OrderMap : GoldStoreEntityTypeConfiguration<Order>
    {
        public OrderMap()
        {
            this.ToTable("Order");
            this.HasKey(p => p.Id);
            this.Property(a => a.OrderCode).HasMaxLength(50);
        }
    }
}

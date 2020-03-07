using GoldStore.Core.Domain.Store; 

namespace GoldStore.Data.Mapping.Store
{
    public class OrderItemMap : GoldStoreEntityTypeConfiguration<OrderItem>
    {
        public OrderItemMap()
        {
            this.ToTable("OrderItem");
            this.HasKey(p => p.Id);

            this.HasKey(orderItem => orderItem.Id);
            this.Property(orderItem => orderItem.Cost).HasPrecision(18, 4);
            
            this.HasRequired(orderItem => orderItem.Order)
                .WithMany(o => o.OrderItems)
                .HasForeignKey(orderItem => orderItem.OrderId);

            this.HasRequired(orderItem => orderItem.Product)
                .WithMany()
                .HasForeignKey(orderItem => orderItem.ProductId);
        }
    }
}

using GoldStore.Core.Domain.Store;

namespace GoldStore.Data.Mapping.Store
{
    public class ProductMap : GoldStoreEntityTypeConfiguration<Product>
    {
        public ProductMap()
        {
            this.ToTable("Product");
            this.HasKey(p => p.Id);
        }    
    }
}

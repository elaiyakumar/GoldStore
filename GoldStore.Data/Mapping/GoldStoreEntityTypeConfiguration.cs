using System.Data.Entity.ModelConfiguration;

namespace GoldStore.Data.Mapping
{
    public abstract class GoldStoreEntityTypeConfiguration<T> : EntityTypeConfiguration<T> where T : class
    {
        protected GoldStoreEntityTypeConfiguration()
        {
            PostInitialize();
        }

        /// <summary>
        /// Developers can override this method in custom partial classes
        /// in order to add some custom initialization code to constructors
        /// </summary>
        protected virtual void PostInitialize()
        {

        }
    } 
    
}

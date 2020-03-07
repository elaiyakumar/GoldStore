using System.Collections.Generic;

namespace GoldStore.Framework
{
    public class BaseModel
    { //Not used
        public BaseModel()
        {
            this.CustomProperties = new Dictionary<string, object>();
            PostInitialize();
        }

        /// <summary>
        /// Developers can override this method in custom partial classes
        /// in order to add some custom initialization code to constructors
        /// </summary>
        protected virtual void PostInitialize()
        {

        }

        /// <summary>
        /// Use this property to store any custom value for your models. 
        /// </summary>
        public Dictionary<string, object> CustomProperties { get; set; }
    }

    /// <summary>
    /// Base  entity model
    /// </summary>
    public partial class BaseEntityModel : BaseModel
    {
        public virtual int Id { get; set; }
    }
}
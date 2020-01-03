using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldStore.Data
{  
    public class GoldStoreInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<GoldStoreObjectContext>
    {

        protected override void Seed(GoldStoreObjectContext context)
        { 

        }
    }
}

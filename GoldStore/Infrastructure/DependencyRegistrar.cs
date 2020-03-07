using Autofac;
using Autofac.Integration.Mvc;
using GoldStore.Core.Configuration;
using GoldStore.Core.Data;
using GoldStore.Core.Infrastructure;
using GoldStore.Core.Infrastructure.DependencyManagement;
using GoldStore.Data;
using GoldStore.Services.Store;
using System.Linq;

namespace GoldStore.Infrastructure
{

    public class DependencyRegistrar : IDependencyRegistrar
    {
        public virtual void Register(ContainerBuilder builder, ITypeFinder typeFinder, GoldStoreConfig config)
        {
            string connectionString = "GoldStore"; 

            //controllers
            builder.RegisterControllers(typeFinder.GetAssemblies().ToArray());

            builder.Register<IDbContext>(c => new GoldStoreObjectContext(connectionString)).InstancePerLifetimeScope();


            builder.RegisterGeneric(typeof(EfRepository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();
            
            builder.RegisterType<OrderService>().As<IOrderService>().InstancePerLifetimeScope();
            builder.RegisterType<ProductService>().As<IProductService>().InstancePerLifetimeScope();

            //https://www.entityframeworktutorial.net/code-first/configure-many-to-many-relationship-in-code-first.aspx
            //https://github.com/entityframeworktutorial/EF6-Code-First-Demo
            //https://stackoverflow.com/questions/16490334/how-to-define-many-to-many-relationship-through-fluent-api-entity-framework
            //https://stackoverflow.com/questions/32517747/3-way-many-to-many-with-fluent-api
            //https://stackoverflow.com/questions/19342908/how-to-create-a-many-to-many-mapping-in-entity-framework
        }

        public int Order
        {
            get { return 2; }
        }
    }
}
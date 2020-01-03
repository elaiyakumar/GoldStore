using GoldStore.Core.Configuration;
using GoldStore.Core.Infrastructure.DependencyManagement;
using System;

namespace GoldStore.Core.Infrastructure
{
    /// <summary>
    /// Classes implementing this interface can serve as a portal for the 
    /// various services composing the GoldStore engine. Edit functionality, modules
    /// and implementations access most GoldStore functionality through this 
    /// interface.
    /// </summary>
    public interface IEngine
    {
        /// <summary>
        /// Container manager
        /// </summary>
        ContainerManager ContainerManager { get; }

        /// <summary>
        /// Initialize components and plugins in the GoldStore environment.
        /// </summary>
        /// <param name="config">Config</param>
        void Initialize(GoldStoreConfig config);

        /// <summary>
        /// Resolve dependency
        /// </summary>
        /// <typeparam name="T">T</typeparam>
        /// <returns></returns>
        T Resolve<T>() where T : class;

        /// <summary>
        ///  Resolve dependency
        /// </summary>
        /// <param name="type">Type</param>
        /// <returns></returns>
        object Resolve(Type type);

        /// <summary>
        /// Resolve dependencies
        /// </summary>
        /// <typeparam name="T">T</typeparam>
        /// <returns></returns>
        T[] ResolveAll<T>();
    }
}

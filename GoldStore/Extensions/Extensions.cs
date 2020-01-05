using GoldStore.Core.Domain.Store;
using GoldStore.Core.Infrastructure.Mapper;
using GoldStore.Models;

namespace GoldStore.Extensions
{
   
    public static class MappingExtensions
    {
        #region Generic
        public static TDestination MapTo<TSource, TDestination>(this TSource source)
        {
            return AutoMapperConfiguration.Mapper.Map<TSource, TDestination>(source);

        }
        public static TDestination MapTo<TSource, TDestination>(this TSource source, TDestination destination)
        {
            return AutoMapperConfiguration.Mapper.Map(source, destination);
        }
        #endregion

        #region Order
        public static OrderModel ToModel(this Order entity)
        {
            return entity.MapTo<Order, OrderModel>();
        }
        public static Order ToEntity(this OrderModel model)
        {
            return model.MapTo<OrderModel, Order>();
        }
        public static Order ToEntity(this OrderModel model, Order destination)
        {
            return model.MapTo<OrderModel, Order>(destination);
        }
        #endregion
          
    }
}
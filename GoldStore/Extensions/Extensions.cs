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
        
        #region OrderItem
        public static OrderItemModel ToModel(this OrderItem entity)
        {
            return entity.MapTo<OrderItem, OrderItemModel>();
        }
        public static OrderItem ToEntity(this OrderItemModel model)
        {
            return model.MapTo<OrderItemModel, OrderItem>();
        }
        public static OrderItem ToEntity(this OrderItemModel model, OrderItem destination)
        {
            return model.MapTo<OrderItemModel, OrderItem>(destination);
        }
        #endregion

        #region Product
        public static ProductModel ToModel(this Product entity)
        {
            return entity.MapTo<Product, ProductModel>();
        }
        public static Product ToEntity(this ProductModel model)
        {
            return model.MapTo<ProductModel, Product>();
        }
        public static Product ToEntity(this ProductModel model, Product destination)
        {
            return model.MapTo<ProductModel, Product>(destination);
        }
        #endregion

    }
}
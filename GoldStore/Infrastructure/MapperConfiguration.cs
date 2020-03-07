using System;
using AutoMapper;
using GoldStore.Core.Infrastructure.Mapper; 
using System.Linq;
using GoldStore.Core.Domain.Store;
using GoldStore.Models;

namespace GoldStore.Infrastructure
{

    public class MapperConfiguration : IMapperConfiguration
    {
        /// <summary>
        /// Get configuration
        /// </summary>
        /// <returns>Mapper configuration action</returns>
        public Action<IMapperConfigurationExpression> GetConfiguration()
        {

            Action<IMapperConfigurationExpression> action = cfg =>
            {
                //Orders
                cfg.CreateMap<Order, OrderModel>()
                    .ForMember(dest => dest.OrderItems, mo => mo.Ignore());
                cfg.CreateMap<OrderModel, Order>()
                    .ForMember(dest => dest.OrderItems, mo => mo.Ignore());

                //OrderItem to OrderItemModel
                cfg.CreateMap<OrderItemModel, OrderItem>()
                   .ForMember(src => src.Product, mo => mo.Ignore());
                cfg.CreateMap<OrderItemModel, OrderItem>()
                   .ForMember(src => src.Order, mo => mo.Ignore());
                
                //OrderItemModel to OrderItem 
                cfg.CreateMap<OrderItem, OrderItemModel>()
                  .ForMember(src => src.AvailableProducts, mo => mo.Ignore());
            };
            return action;
        }

        /// <summary>
        /// Order of this mapper implementation
        /// </summary>
        public int Order
        {
            get { return 0; }
        }
    }
}
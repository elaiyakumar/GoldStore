using System; 
using System.Linq;
using System.Collections.Generic;
using GoldStore.Core.Data;
using GoldStore.Core.Domain.Store;

namespace GoldStore.Services.Store
{ 
    public class OrderService : IOrderService
    {
        private readonly IRepository<Order> _orderRepository;
        private readonly IRepository<OrderItem> _orderItemRepository;

        public OrderService(IRepository<Order> orderRepository, IRepository<OrderItem> orderItemRepository)
        {
            _orderRepository = orderRepository;
            _orderItemRepository = orderItemRepository;
        }

        public Order GetOrderById(int? orderId)
        {
            if (orderId == 0)
                return null;
            return _orderRepository.GetById(orderId);

        }

        public Order GetOrderByIdEagerLoad(int? orderId)
        {
            var children = new string[] { "OrderItems", "OrderItems.Product" };

            var query = from d in _orderRepository.GetEntityWithEagerLoad(d => d.Id == orderId, children)
                        orderby d.OrderCode
                        select d;

            var order = query.FirstOrDefault();
            return order;
        }

        public IList<Order> GetAllOrders()
        {
            var query = from d in _orderRepository.Table
                        orderby d.OrderCode
                        select d;

            var orders = query.ToList();
            return orders;
        }
              

        public void InsertOrder(Order order)
        {
            _orderRepository.Insert(order);
        } 

        public void UpdateOrder(Order order)
        {
            _orderRepository.Update(order);
        }

        public void DeleteOrder(Order order)
        {
            _orderRepository.Delete(order);
        }

        public void DeleteOrders(IList<Order> orders)
        {
            throw new NotImplementedException();
            //_OrderRepository.Update(Order);
        }

        public OrderItem GetOrderItemById(int? orderItemId)
        {
            if (orderItemId == 0)
                return null;
            return _orderItemRepository.GetById(orderItemId);

        }

        public void InsertOrderItem(OrderItem orderItem)
        {
            _orderItemRepository.Insert(orderItem);
        }

        public void DeleteOrderItem(OrderItem orderItem)
        {
            _orderItemRepository.Delete(orderItem);
        }  

    }
}

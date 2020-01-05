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

        public OrderService(IRepository<Order> orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public Order GetOrderById(int? orderId)
        {
            if (orderId == 0)
                return null;
            return _orderRepository.GetById(orderId);
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


    }
}

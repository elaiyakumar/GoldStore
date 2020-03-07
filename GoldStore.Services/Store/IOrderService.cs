using GoldStore.Core.Domain.Store;
using System.Collections.Generic;

namespace GoldStore.Services.Store
{  

    public interface IOrderService
    {
        #region Order 

        /// <summary>
        /// Gets all Orders
        /// </summary>
        /// <returns>Orders</returns>
        IList<Order> GetAllOrders();

        /// <summary>
        /// Gets Order
        /// </summary>
        /// <param name="orderId">Order identifier</param>
        /// <returns>Order</returns>
        Order GetOrderById(int? orderId);
        Order GetOrderByIdEagerLoad(int? orderId);
        //IList<Order> GetOrderByIdEagerLoad(int? orderId);

        /// <summary>
        /// Inserts an Order
        /// </summary>
        /// <param name="Order">Order</param>
        void InsertOrder(Order order);


        /// <summary>
        /// Inserts an Order
        /// </summary>
        /// <param name="Order">Order</param>
        void InsertOrderItem(OrderItem orderItem);

        /// <summary>
        /// Updates the Order
        /// </summary>
        /// <param name="Order">Order</param>
        void UpdateOrder(Order order);

        /// <summary>
        /// Delete a Order
        /// </summary>
        /// <param name="Order">Order</param>
        void DeleteOrder(Order order);

        /// <summary>
        /// Delete products
        /// </summary>
        /// <param name="Orders">Orders</param>
        void DeleteOrders(IList<Order> orders);

        #endregion
    }
}

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
        /// <param name="OrderId">Order identifier</param>
        /// <returns>Order</returns>
        Order GetOrderById(int OrderId);

        /// <summary>
        /// Inserts an Order
        /// </summary>
        /// <param name="Order">Order</param>
        void InsertOrder(Order Order);

        /// <summary>
        /// Updates the Order
        /// </summary>
        /// <param name="Order">Order</param>
        void UpdateOrder(Order Order);

        /// <summary>
        /// Delete a Order
        /// </summary>
        /// <param name="Order">Order</param>
        void DeleteOrder(Order Order);

        /// <summary>
        /// Delete products
        /// </summary>
        /// <param name="products">Orders</param>
        void DeleteOrders(IList<Order> Orders);

        #endregion
    }
}

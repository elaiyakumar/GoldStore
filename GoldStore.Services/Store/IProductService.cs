using GoldStore.Core.Domain.Store;
using System.Collections.Generic;

namespace GoldStore.Services.Store
{  

    public interface IProductService
    {
        #region Product 

        /// <summary>
        /// Gets all Products
        /// </summary>
        /// <returns>Products</returns>
        IList<Product> GetAllProducts();

        /// <summary>
        /// Gets Product
        /// </summary>
        /// <param name="ProductId">Product identifier</param>
        /// <returns>Product</returns>
        Product GetProductById(int ProductId);

        /// <summary>
        /// Inserts an Product
        /// </summary>
        /// <param name="Product">Product</param>
        void InsertProduct(Product Product);

        /// <summary>
        /// Updates the Product
        /// </summary>
        /// <param name="Product">Product</param>
        void UpdateProduct(Product Product);

        /// <summary>
        /// Delete a Product
        /// </summary>
        /// <param name="Product">Product</param>
        void DeleteProduct(Product Product);

        /// <summary>
        /// Delete products
        /// </summary>
        /// <param name="Products">Products</param>
        void DeleteProducts(IList<Product> Products);

        #endregion
    }
}

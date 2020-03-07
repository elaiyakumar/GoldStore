using System; 
using System.Linq;
using System.Collections.Generic;
using GoldStore.Core.Data;
using GoldStore.Core.Domain.Store;

namespace GoldStore.Services.Store
{ 
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> _ProductRepository;

        public ProductService(IRepository<Product> ProductRepository)
        {
            _ProductRepository = ProductRepository;
        }

        public Product GetProductById(int ProductId)
        {
            if (ProductId == 0)
                return null;
            return _ProductRepository.GetById(ProductId);
        }

        public IList<Product> GetAllProducts()
        {
            var query = from d in _ProductRepository.Table
                        orderby d.Name
                        select d;

            var Products = query.ToList();
            return Products;
        }

        public void InsertProduct(Product Product)
        {
            _ProductRepository.Insert(Product);
        }

        public void UpdateProduct(Product Product)
        {
            _ProductRepository.Update(Product);
        }

        public void DeleteProduct(Product Product)
        {
            _ProductRepository.Delete(Product);
        }

        public void DeleteProducts(IList<Product> Products)
        {
            throw new NotImplementedException();
            //_ProductRepository.Update(Product);
        }


    }
}

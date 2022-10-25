using Inventory.Models;
using Inventory.Repositories;
using Inventory.Repositories.Interfaces;
using Inventory.Services.Interfaces;
using System.Collections.Generic;

namespace Inventory.Services
{
    public class ProductService : IProductService
    {
        private IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            this._productRepository = productRepository;
        }
        private bool UsedId(int id)
        {
            var productList = _productRepository.GetAll();
            if(productList.Exists(p => p.Id_Product == id))
                return true;
            return false;
        }

        public List<Product> GetAll() => _productRepository.GetAll();

        public Product? Get(int id)
        {
            if(UsedId(id))
                return _productRepository.Get(id);
            return null;
        } 

        public void Add(Product product)
        {
            if(!UsedId(product.Id_Product))
                _productRepository.Add(product);
            return;
        } 

        public void Delete(int id)
        {
            var productToDelete = _productRepository.Get(id);
            if(productToDelete != null)
                _productRepository.Delete(productToDelete);
            return;
        }

        public void Update(Product product)
        {
            if (UsedId(product.Id_Product))
                _productRepository.Update(product);
            return;
        }
        
    }
}

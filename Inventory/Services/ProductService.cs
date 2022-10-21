using Inventory.Models;
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

        public List<Product> GetAll() => _productRepository.GetAll();

        public Product? Get(int id) => _productRepository.Get(id);

        public void Add(Product product) => _productRepository.Add(product);

        public void Delete(int id)
        {
            var productToDelete = _productRepository.Get(id);
            if(productToDelete != null)
                _productRepository.Delete(productToDelete);
        }

        public void Update(Product product)
        {
            if(product != null)
                _productRepository.Update(product);
        }
        
    }
}

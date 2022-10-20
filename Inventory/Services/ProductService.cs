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

        public void Delete(int id) => _productRepository.Delete(id);

        public void Update(Product product) => _productRepository.Update(product);
    }
}

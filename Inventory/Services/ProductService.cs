using Inventory.Data;
using Inventory.Models;
using Inventory.Repositories;
using Inventory.Repositories.Interfaces;
using Inventory.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Inventory.Services
{
    public class ProductService : IProductService
    {
        IProductRepository _productRepository;
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


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
        private ICategoryRepository _categoryRepository;
        public ProductService(IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            this._productRepository = productRepository;
            this._categoryRepository = categoryRepository;
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

        public bool Add(Product product)
        {
            Category categoryById = _categoryRepository.Get(product.Id_Category);
            if (!UsedId(product.Id_Product) && categoryById != null)
            {
                _productRepository.Add(product);
                return true;
            }
            return false;
        } 

        public bool Delete(int id)
        {
            var productToDelete = _productRepository.Get(id);
            if(productToDelete != null)
            {
                _productRepository.Delete(productToDelete);
                return true;
            }
            return false;
        }

        public bool Update(Product product)
        {
            Category categoryById = _categoryRepository.Get(product.Id_Category);
            if (UsedId(product.Id_Product) && categoryById != null)
            {
                _productRepository.Update(product);
                return true;
            }
            return false;
        }
        
    }
}

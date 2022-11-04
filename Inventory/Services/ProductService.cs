using Inventory.Models;
using Inventory.Repositories;
using Inventory.Repositories.Interfaces;
using Inventory.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Inventory.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        public ProductService(IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            this._productRepository = productRepository;
            this._categoryRepository = categoryRepository;
        }
        private async Task<bool> UsedId(int id)
        {
            var productList = await _productRepository.GetAll();
            if(productList.Exists(p => p.Id_Product == id))
                return true;
            return false;
        }

        public async Task<List<Product>> GetAll() => await _productRepository.GetAll();

        public async Task<Product?> Get(int id)
        {
            if(await UsedId(id))
            {
                var productGet = await _productRepository.Get(id);
                return productGet;
            }
            return null;
        } 

        public async Task<bool> Add(Product product)
        {
            Category categoryById = await _categoryRepository.Get(product.Id_Category);
            if (!(await UsedId(product.Id_Product)) && categoryById != null && product.Id_Product > 0)
            {
                await _productRepository.Add(product);
                return true;
            }
            return false;
        } 

        public async Task<bool> Delete(int id)
        {
            var productToDelete = await _productRepository.Get(id);
            if(productToDelete != null)
            {
                await _productRepository.Delete(productToDelete);
                return true;
            }
            return false;
        }

        public async Task<bool> Update(Product product)
        {
            Category categoryById = await _categoryRepository.Get(product.Id_Category);
            if (await UsedId(product.Id_Product) && categoryById != null)
            {
                await _productRepository.Update(product);
                return true;
            }
            return false;
        }
        
    }
}

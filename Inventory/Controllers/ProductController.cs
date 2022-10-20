using Inventory.Models;
using Inventory.Services;
using Inventory.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Inventory.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private IProductService _productService;
        ProductController(IProductService productService)
        {
            this._productService = productService;
        }

        [HttpGet]
        public List<Product> GetAllProducts() => _productService.GetAll();

        [HttpGet("{id}")]
        public Product GetProduct(int id) => _productService.Get(id);

        [HttpPost]
        public void AddProduct(Product product) => _productService.Add(product);

        [HttpDelete("{id}")]
        public void DeleteProduct(Product product) => _productService.Delete(product.Id_Product);

        [HttpPut]
        public void UpdateProduct(Product product) => _productService.Update(product); 
        
    }
}

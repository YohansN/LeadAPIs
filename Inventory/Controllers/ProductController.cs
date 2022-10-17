using Inventory.Models;
using Inventory.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Inventory.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        public List<Product> GetAllProducts() 
        {
            ProductService service = new ProductService();
            return service.GetAll();
        }

        [HttpGet("{id}")]
        public Product GetProduct(int id)
        {
            ProductService service = new ProductService();
            return service.Get(id);
        }

        [HttpPost]
        public void AddProduct(Product product)
        {
            ProductService service = new ProductService();
            service.Add(product);
        } 

        [HttpDelete("{id}")]
        public void DeleteProduct(Product product)
        {
            ProductService service = new ProductService();
            service.Delete(product.Id_Product);
        } 

        [HttpPut]
        public void UpdateProduct(Product product) {
            ProductService service = new ProductService();
            service.Update(product); 
        }
    }
}

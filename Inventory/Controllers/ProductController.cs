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
        public List<Product> GetAllProducts() { return ProductService.GetAll(); }

        [HttpGet("{id}")]
        public Product GetProduct(int id) { return ProductService.Get(id); }

        [HttpPost]
        public void AddProduct(Product product) { ProductService.Add(product); }

        [HttpDelete("{id}")]
        public void DeleteProduct(Product product) { ProductService.Delete(product.Id); }

        [HttpPut]
        public void UpdateProduct(Product product) { ProductService.Update(product); }
    }
}

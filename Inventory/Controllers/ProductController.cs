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
        public ProductController(IProductService productService)
        {
            this._productService = productService;
        }

        /// <summary>
        /// Retorna uma lista de products.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<Product> GetAllProducts() => _productService.GetAll();

        /// <summary>
        /// Retorna um objeto product de acordo com o id passado no parâmetro.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public Product GetProduct(int id) => _productService.Get(id);

        /// <summary>
        /// Adiciona um novo product ao banco caso o id passado já não exista.
        /// </summary>
        /// <param name="product"></param>
        [HttpPost]
        public void AddProduct(Product product) => _productService.Add(product);

        /// <summary>
        /// Apaga um objeto product de acordo com o id passado.
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public void DeleteProduct(int id) => _productService.Delete(id);

        /// <summary>
        /// Atualiza um objeto product.
        /// </summary>
        /// <param name="product"></param>
        [HttpPut]
        public void UpdateProduct(Product product) => _productService.Update(product); 
        
    }
}

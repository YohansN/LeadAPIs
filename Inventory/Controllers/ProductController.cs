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
        public IActionResult GetAllProducts() => Ok(_productService.GetAll());

        /// <summary>
        /// Retorna um objeto product de acordo com o id passado no parâmetro.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            if (id <= 0)
                return BadRequest();

            var productById = _productService.Get(id);
            if (productById != null)
                return Ok(productById);
            return NotFound();
        }

        /// <summary>
        /// Adiciona um novo product ao banco caso o id passado já não exista.
        /// </summary>
        /// <param name="product"></param>
        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            bool productAdd = _productService.Add(product);
            if(productAdd)
                return Ok();
            return BadRequest();
        }

        /// <summary>
        /// Apaga um objeto product de acordo com o id passado.
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var productDelete = _productService.Delete(id);
            if(productDelete)
                return NoContent();
            return BadRequest();
        }

        /// <summary>
        /// Atualiza um objeto product.
        /// </summary>
        /// <param name="product"></param>
        [HttpPut]
        public IActionResult UpdateProduct(Product product)
        {
            var productUpdate = _productService.Update(product);
            if(productUpdate)
                return NoContent();
            return BadRequest();
        }
    }
}

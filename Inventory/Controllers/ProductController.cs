using Inventory.Models;
using Inventory.Services;
using Inventory.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Inventory.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            this._productService = productService;
        }

        /// <summary>
        /// Retorna uma lista de products.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllProducts() => Ok(await _productService.GetAll());

        /// <summary>
        /// Retorna um objeto product de acordo com o id passado no parâmetro.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            if (id <= 0)
                return BadRequest();

            var productById = await _productService.Get(id);
            if (productById != null)
                return Ok(productById);
            return NotFound();
        }

        /// <summary>
        /// Adiciona um novo product ao banco caso o id passado já não exista.
        /// </summary>
        /// <param name="product"></param>
        [HttpPost]
        public async Task<IActionResult> AddProduct(Product product)
        {
            bool productAdd = await _productService.Add(product);
            if(productAdd)
                return Ok();
            return BadRequest();
        }

        /// <summary>
        /// Apaga um objeto product de acordo com o id passado.
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var productDelete = await _productService.Delete(id);
            if(productDelete)
                return NoContent();
            return BadRequest();
        }

        /// <summary>
        /// Atualiza um objeto product.
        /// </summary>
        /// <param name="product"></param>
        [HttpPut]
        public async Task<IActionResult> UpdateProduct(Product product)
        {
            var productUpdate = await _productService.Update(product);
            if(productUpdate)
                return NoContent();
            return BadRequest();
        }
    }
}

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
    public class CategoryController : ControllerBase
    {
        private ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            this._categoryService = categoryService;
        }

        /// <summary>
        /// Retorna uma lista de categorias.
        /// </summary>
        /// <returns>Ok</returns>
        [HttpGet]
        public async Task<IActionResult> GetAllCategories() => Ok(await _categoryService.GetAll());
        
       /// <summary>
       /// Retorna um objeto category de acordo com o id passado no parâmetro.
       /// </summary>
       /// <param name="id"></param>
       /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategory(int id)
        {
            if (id <= 0)
                return BadRequest();

            var categoryById = await _categoryService.Get(id);
            if(categoryById != null)
                return Ok(categoryById);
            return NotFound();
        }
        
        /// <summary>
        /// Adiciona uma nova category ao banco caso o id passado já não exista.
        /// </summary>
        /// <param name="category"></param>
        [HttpPost]
        public async Task<IActionResult> CreateCategory(Category category)
        {
            var categoryAdd = await _categoryService.Add(category);
            if(categoryAdd)
                return Ok(category);
            return BadRequest();
        } 

        /// <summary>
        /// Apaga um objeto category de acordo com o id passado.
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var categoryDelete = await _categoryService.Delete(id);
            if(categoryDelete)
                return NoContent();
            return BadRequest();
        }

        /// <summary>
        /// Atualiza um objeto category.
        /// </summary>
        /// <param name="category"></param>
        [HttpPut]
        public async Task<IActionResult> UpdateCategory(Category category)
        {
            var categoryUpdate = await _categoryService.Update(category);
            if(categoryUpdate)
                return NoContent();
            return BadRequest();
        } 

    }
}

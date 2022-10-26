using Inventory.Models;
using Inventory.Services;
using Inventory.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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
        public IActionResult GetAllCategories() => Ok(_categoryService.GetAll());
        
       /// <summary>
       /// Retorna um objeto category de acordo com o id passado no parâmetro.
       /// </summary>
       /// <param name="id"></param>
       /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetCategory(int id)
        {
            var categoryById = _categoryService.Get(id);
            if(categoryById != null)
                return Ok(categoryById);
            return NotFound();
        }
        
        /// <summary>
        /// Adiciona uma nova category ao banco caso o id passado já não exista.
        /// </summary>
        /// <param name="category"></param>
        [HttpPost]
        public IActionResult CreateCategory(Category category)
        {
            var categoryAdd = _categoryService.Add(category);
            if(categoryAdd)
                return BadRequest();
            return Ok(category);
        } 

        /// <summary>
        /// Apaga um objeto category de acordo com o id passado.
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            var categoryDelete = _categoryService.Delete(id);
            if(categoryDelete)
                return Ok(categoryDelete);
            return BadRequest();
        }

        /// <summary>
        /// Atualiza um objeto category.
        /// </summary>
        /// <param name="category"></param>
        [HttpPut]
        public IActionResult UpdateCategory(Category category)
        {
            var categoryUpdate = _categoryService.Update(category);
            if(categoryUpdate)
                return Ok(categoryUpdate);
            return BadRequest();
        } 

    }
}

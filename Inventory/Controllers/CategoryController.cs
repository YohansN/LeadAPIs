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
        public List<Category> GetAllCategories() => _categoryService.GetAll();
        
       /// <summary>
       /// Retorna um objeto category de acordo com o id passado no parâmetro.
       /// </summary>
       /// <param name="id"></param>
       /// <returns></returns>
        [HttpGet("{id}")]
        public Category GetCategory(int id) => _categoryService.Get(id);
        
        /// <summary>
        /// Adiciona uma nova category ao banco caso o id passado já não exista.
        /// </summary>
        /// <param name="category"></param>
        [HttpPost]
        public void CreateCategory(Category category) => _categoryService.Add(category);

        /// <summary>
        /// Apaga um objeto category de acordo com o id passado.
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public void DeleteCategory(int id) => _categoryService.Delete(id);

        /// <summary>
        /// Atualiza um objeto category.
        /// </summary>
        /// <param name="category"></param>
        [HttpPut]
        public void UpdateCategory(Category category) => _categoryService.Update(category);

    }
}

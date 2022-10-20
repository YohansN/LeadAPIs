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
        CategoryController(ICategoryService categoryService)
        {
            this._categoryService = categoryService;
        }

        [HttpGet]
        public List<Category> GetAllCategories() => _categoryService.GetAll();
            
        [HttpGet("{id}")]
        public Category GetCategory(int id) => _categoryService.Get(id);
        
        [HttpPost]
        public void CreateCategory(Category category) => _categoryService.Add(category);
        
        [HttpDelete("{id}")]
        public void DeleteCategory(Category category) => _categoryService.Delete(category.Id_Category);

        [HttpPut]
        public void UpdateCategory(Category category) => _categoryService.Update(category);

    }
}

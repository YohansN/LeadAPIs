using Inventory.Models;
using Inventory.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Inventory.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {
        [HttpGet]
        public List<Category> GetAllCategories() => CategoryService.GetAll();

        [HttpGet("{id}")]
        public Category GetCategory(int id) => CategoryService.Get(id);

        [HttpPost]
        public void CreateCategory(Category category) => CategoryService.Add(category);

        [HttpDelete("{id}")]
        public void DeleteCategory(Category category) => CategoryService.Delete(category.Id);
        
        [HttpPut]
        public void UpdateCategory(Category category) => CategoryService.Update(category);

        
    }
}

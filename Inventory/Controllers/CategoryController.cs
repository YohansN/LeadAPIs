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
        public List<Category> GetAllCategories()
        {
            CategoryService service = new CategoryService();
            return service.GetAll();
        }
            
        [HttpGet("{id}")]
        public Category GetCategory(int id)
        {
            CategoryService service = new CategoryService();
            return service.Get(id);
        }

        [HttpPost]
        public void CreateCategory(Category category)
        {
            CategoryService service = new CategoryService();
            service.Add(category);
        }

        [HttpDelete("{id}")]
        public void DeleteCategory(Category category)
        {
            CategoryService service = new CategoryService();
            service.Delete(category.Id_Category);
        }

        [HttpPut]
        public void UpdateCategory(Category category)
        {
            CategoryService service = new CategoryService();
            service.Update(category);
        }

        
    }
}

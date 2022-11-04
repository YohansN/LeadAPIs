using Inventory.Models;
using Inventory.Repositories;
using Inventory.Repositories.Interfaces;
using Inventory.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Inventory.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            this._categoryRepository = categoryRepository;
        }
        private async Task<bool> UsedId(int id)
        {
            var productList = await _categoryRepository.GetAll();
            if (productList.Exists(p => p.Id_Category == id))
                return true;
            return false;
        }

        public async Task<List<Category>> GetAll()
        {
            var categoryGetAll = await _categoryRepository.GetAll();
            return categoryGetAll;
        } 

        public async Task<Category>? Get(int id)
        {
            if (await UsedId(id))
            {
                var categoryById = await _categoryRepository.Get(id);
                return categoryById;
            }
            return null;
        } 

        public async Task<bool> Add(Category category)
        {
            if (!(await UsedId(category.Id_Category)) && category.Id_Category > 0)
            {
                await _categoryRepository.Add(category);
                return true;
            }         
            return false;
        } 

        public async Task<bool> Delete(int id)
        {
            var categoryToDelete = await _categoryRepository.Get(id);
            if(categoryToDelete != null)
            {
                await _categoryRepository.Delete(categoryToDelete);
                return true;
            }
            return false;
        }

        public async Task<bool> Update(Category category)
        {
            if (await UsedId(category.Id_Category))
            {
                await _categoryRepository.Update(category);
                return true;
            }
            return false;
        }
        
    }
}

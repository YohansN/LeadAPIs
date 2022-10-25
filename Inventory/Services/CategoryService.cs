using Inventory.Models;
using Inventory.Repositories;
using Inventory.Repositories.Interfaces;
using Inventory.Services.Interfaces;
using System.Collections.Generic;

namespace Inventory.Services
{
    public class CategoryService : ICategoryService
    {
        private ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            this._categoryRepository = categoryRepository;
        }
        private bool UsedId(int id)
        {
            var productList = _categoryRepository.GetAll();
            if (productList.Exists(p => p.Id_Category == id))
                return true;
            return false;
        }

        public List<Category> GetAll() => _categoryRepository.GetAll();

        public Category? Get(int id)
        {
            if(UsedId(id))
                return _categoryRepository.Get(id);
            return null;
        } 

        public void Add(Category category)
        {
            if(!UsedId(category.Id_Category))
                _categoryRepository.Add(category);
            return;
        } 

        public void Delete(int id)
        {
            var categoryToDelete = _categoryRepository.Get(id);
            if(categoryToDelete != null)
                _categoryRepository.Delete(categoryToDelete);
            return;
        }

        public void Update(Category category)
        {
            if (UsedId(category.Id_Category))
                _categoryRepository.Update(category);
            return;
        }
        
    }
}

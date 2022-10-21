using Inventory.Models;
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

        public List<Category> GetAll() => _categoryRepository.GetAll();

        public Category? Get(int id) => _categoryRepository.Get(id);

        public void Add(Category category) => _categoryRepository.Add(category);

        public void Delete(int id)
        {
            var categoryToDelete = _categoryRepository.Get(id);
            if(categoryToDelete != null)
                _categoryRepository.Delete(categoryToDelete);
        }

        public void Update(Category category)
        {
            if(category != null)
                _categoryRepository.Update(category);
        }
        
    }
}

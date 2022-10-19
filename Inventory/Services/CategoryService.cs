using Inventory.Data;
using Inventory.Models;
using Inventory.Repositories;
using Inventory.Repositories.Interfaces;
using Inventory.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory.Services
{
    public class CategoryService : ICategoryService
    {
        ICategoryRepository _categoryRepository;
        CategoryService(ICategoryRepository categoryRepository)
        {
            this._categoryRepository = categoryRepository;
        }

        public List<Category> GetAll() => _categoryRepository.GetAll();

        public Category? Get(int id) => _categoryRepository.Get(id);
            
        public void Add(Category category) => _categoryRepository.Add(category);
        
        public void Delete(int id) => _categoryRepository.Delete(id);

        public void Update(Category category) => _categoryRepository.Update(category);
        
    }
}


using Inventory.Data;
using Inventory.Models;
using Inventory.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly Context _context;
        public CategoryRepository(Context context)
        {
            this._context = context;
        }

        public async Task<List<Category>> GetAll()
        {
            var categoryGetAll = await _context.Category.ToListAsync();
            return categoryGetAll;
        }

        public async Task<Category> Get(int id)
        {
            var categoryGet = await _context.Category.FirstOrDefaultAsync(c => c.Id_Category == id);
            return categoryGet;
        }

        public async Task Add(Category category)
        {
            _context.Category.Add(category);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Category categoryToDelete)
        {
            _context.Category.Remove(categoryToDelete);
            await _context.SaveChangesAsync();   
        }

        public async Task Update(Category category)
        {
            _context.Category.Update(category);
            await _context.SaveChangesAsync();
        }
    }
}

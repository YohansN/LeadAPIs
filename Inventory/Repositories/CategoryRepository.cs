using Inventory.Data;
using Inventory.Models;
using Inventory.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Inventory.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private Context _context;
        public CategoryRepository(Context context)
        {
            this._context = context;
        }

        public List<Category> GetAll()
        {
            return _context.Category.ToList();
        }

        public Category Get(int id)
        {
            return _context.Category.FirstOrDefault(c => c.Id_Category == id);
        }

        public void Add(Category category)
        {
            _context.Category.Add(category);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var category = Get(id);
            if (category != null)
            {
                _context.Category.Remove(category);
                _context.SaveChanges();
            }
        }

        public void Update(Category category)
        {
            _context.Category.Update(category);
            _context.SaveChanges();
        }
    }
}

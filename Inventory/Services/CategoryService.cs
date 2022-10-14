using Inventory.Data;
using Inventory.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory.Services
{
    public class CategoryService
    {
        
        public CategoryService(){}

        public List<Category> GetAll()
        {
            Context _context = new Context();
            return _context.Category.ToList();
        }

        public Category? Get(int id)
        {
            Context _context = new Context();
            return _context.Category.FirstOrDefault(c => c.Id_Category == id);
        }
            
        public void Add(Category category)
        {
            Context _context = new Context();
            _context.Category.Add(category);
        }

        public void Delete(int id)
        {
            Context _context = new Context();

            var category = Get(id);
            if (category is null)
                return;
            _context.Category.Remove(category);
        }

        /*
        public static void Update(Category category)
        {
            Context _context = new Context();

            var index = _context.Category.Update(category);
            if (index == -1)
                return;
            _context.Category[index] = category;
        }
        */
    }
}


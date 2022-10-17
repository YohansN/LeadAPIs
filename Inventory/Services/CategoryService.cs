using Inventory.Data;
using Inventory.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory.Services
{
    public class CategoryService
    {
        
        

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
            _context.SaveChanges();
        }
        

        public void Delete(int id)
        {
            Context _context = new Context();

            var category = Get(id);
            if (category is null)
                return;
            _context.Category.Remove(category);
            _context.SaveChanges();
        }

        
        public void Update(Category category)
        {
            Context _context = new Context();
            var index = _context.Category.Update(category);
            _context.SaveChanges();
        }
        
    }
}


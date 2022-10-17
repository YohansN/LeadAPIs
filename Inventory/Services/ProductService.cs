using Inventory.Data;
using Inventory.Models;
using System.Collections.Generic;
using System.Linq;

namespace Inventory.Services
{
    public class ProductService
    {
        
        public ProductService(){}

        public List<Product> GetAll()
        {
            Context _context = new Context();
            return _context.Product.ToList();
        }

        public Product? Get(int id)
        {
            Context _context = new Context();
            return _context.Product.FirstOrDefault(p => p.Id_Product == id);
        }

        public void Add(Product product)
        {
            Context _context = new Context();
            _context.Product.Add(product);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            Context _context = new Context();

            var product = Get(id);
            if (product is null)
                return;
            _context.Product.Remove(product);
            _context.SaveChanges();
        }
        
        
        public void Update(Product product)
        {
            Context _context = new Context();
            var index = _context.Product.Update(product);
            _context.SaveChanges();
        }
        
    }
}


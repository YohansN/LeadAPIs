using Inventory.Data;
using Inventory.Models;
using Inventory.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Inventory.Repositories
{
    public class ProductRepository : IProductRepository
    {
        Context _context;
        ProductRepository(Context context)
        {
            this._context = context;
        }

        public List<Product> GetAll()
        {
            return _context.Product.ToList();
        }

        public Product Get(int id)
        {
            return _context.Product.FirstOrDefault(p => p.Id_Product == id);
        }

        public void Add(Product product)
        {
            _context.Product.Add(product);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var product = Get(id);
            if (product is null)
                return;
            _context.Product.Remove(product);
            _context.SaveChanges();
        }

        public void Update(Product product)
        {
            _context.Product.Update(product);
            _context.SaveChanges();
        }
        

    }
}

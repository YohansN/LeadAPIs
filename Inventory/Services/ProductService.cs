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
        }

        public void Delete(int id)
        {
            Context _context = new Context();

            var product = Get(id);
            if (product is null)
                return;
            _context.Product.Remove(product);
        }
        
        /*
        public void Update(Product product)
        {
            var index = Products.FindIndex(p => p.Id_Product == product.Id_Product);
            if (index == -1)
                return;
            Products[index] = product;
        }
        */
    }
}


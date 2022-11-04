using Inventory.Data;
using Inventory.Models;
using Inventory.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly Context _context;
        public ProductRepository(Context context)
        {
            this._context = context;
        }

        public async Task<List<Product>> GetAll()
        {
            var productGetAll = await _context.Product.ToListAsync();
            return productGetAll;
        }

        public async Task<Product> Get(int id)
        {
            var productGet = await _context.Product.FirstOrDefaultAsync(p => p.Id_Product == id);
            return productGet;
        }

        public async Task Add(Product product)
        {
            _context.Product.Add(product);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Product productToDelete)
        {
            _context.Product.Remove(productToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Product product)
        {
            _context.Product.Update(product);
            await _context.SaveChangesAsync();
        }
    }
}

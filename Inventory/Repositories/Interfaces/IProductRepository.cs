using Inventory.Models;
using System.Collections.Generic;

namespace Inventory.Repositories.Interfaces
{
    public interface IProductRepository
    {
        List<Product> GetAll();

        Product Get(int id);

        void Add(Product product);

        void Delete(Product productToDelete);

        void Update(Product product);
        
    }
}

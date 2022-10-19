using Inventory.Models;
using System.Collections.Generic;

namespace Inventory.Repositories.Interfaces
{
    public interface IProductRepository
    {
        List<Product> GetAll();

        Product Get(int id);

        void Add(Product product);

        void Delete(int id);

        void Update(Product product);
    }
}

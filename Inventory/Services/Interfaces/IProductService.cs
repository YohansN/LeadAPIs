using Inventory.Models;
using System.Collections.Generic;

namespace Inventory.Services.Interfaces
{
    public interface IProductService
    {
        List<Product> GetAll();

        Product Get(int id);

        void Add(Product product);

        void Delete(int id);

        void Update(Product product);
    }
}

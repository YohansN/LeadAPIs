using Inventory.Models;
using System.Collections.Generic;

namespace Inventory.Services.Interfaces
{
    public interface IProductService
    {
        List<Product> GetAll();

        Product Get(int id);

        bool Add(Product product);

        bool Delete(int id);

        bool Update(Product product);
    }
}

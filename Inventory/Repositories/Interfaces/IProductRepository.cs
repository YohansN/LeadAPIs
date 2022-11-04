using Inventory.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Inventory.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAll();

        Task<Product> Get(int id);

        Task Add(Product product);

        Task Delete(Product productToDelete);

        Task Update(Product product);
        
    }
}

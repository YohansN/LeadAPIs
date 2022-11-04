using Inventory.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Inventory.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetAll();

        Task<Category> Get(int id);

        Task Add(Category category);

        Task Delete(Category categoryToDelete);

        Task Update(Category category);
    }
}

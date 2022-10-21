using Inventory.Models;
using System.Collections.Generic;

namespace Inventory.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        List<Category> GetAll();

        Category Get(int id);

        void Add(Category category);

        void Delete(Category categoryToDelete);

        void Update(Category category);
    }
}

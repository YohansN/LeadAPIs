using Inventory.Models;
using System.Collections.Generic;

namespace Inventory.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        List<Category> GetAll();

        Category Get(int id);

        void Add(Category category);

        void Delete(int id);

        void Update(Category category);
    }
}

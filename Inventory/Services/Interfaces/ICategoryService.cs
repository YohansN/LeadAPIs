using Inventory.Models;
using System.Collections.Generic;

namespace Inventory.Services.Interfaces
{
    public interface ICategoryService
    {
        List<Category> GetAll();

        Category Get(int id);

        bool Add(Category category);

        bool Delete(int id);

        bool Update(Category category);
    }
}

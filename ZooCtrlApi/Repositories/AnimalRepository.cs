using ZooCtrlApi.Data;
using ZooCtrlApi.Repositories.Interfaces;

namespace ZooCtrlApi.Repositories
{
    public class AnimalRepository : IAnimalRepository
    {
        private Context _context;
        AnimalRepository(Context context)
        {
            this._context = context;
        }


    }
}

using System.Collections.Generic;
using System.Threading.Tasks;
using ZooCtrlApi.Models;

namespace ZooCtrlApi.Repositories.Interfaces
{
    public interface IZonaRepository
    {
        public Task<List<Zona>> GetAll();
        public Task<Zona> GetById(int id);
        public Task Add(Zona zona);
        public Task Delete(int id);
        public Task Update(Zona zona);
    }
}

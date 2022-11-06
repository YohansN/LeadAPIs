using System.Collections.Generic;
using System.Threading.Tasks;
using ZooCtrlApi.Models;

namespace ZooCtrlApi.Services.Interfaces
{
    public interface IZonaService
    {
        public Task<List<Zona>> GetAll();
        public Task<Zona> GetById(int id);
        public Task<bool> Add(Zona zona);
        public Task<bool> Delete(int id);
        public Task<bool> Update(Zona zona);
    }
}

using System.Collections.Generic;
using System.Threading.Tasks;
using ZooCtrlApi.Models;

namespace ZooCtrlApi.Services.Interfaces
{
    public interface IFiloService
    {
        public Task<List<Filo>> GetAll();
        public Task<Filo> GetById(int id);
        public Task<bool> Add(Filo filo);
        public Task<bool> Delete(int id);
        public Task<bool> Update(Filo filo);
    }
}

using System.Collections.Generic;
using System.Threading.Tasks;
using ZooCtrlApi.Models;

namespace ZooCtrlApi.Repositories.Interfaces
{
    public interface IFiloRepository
    {
        public Task<List<Filo>> GetAll();
        public Task<Filo> GetById(int id);
        public Task Add(Filo filo);
        public Task Delete(int id);
        public Task Update(Filo filo);
    }
}

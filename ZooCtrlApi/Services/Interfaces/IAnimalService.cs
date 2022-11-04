using System.Collections.Generic;
using System.Threading.Tasks;
using ZooCtrlApi.Models;

namespace ZooCtrlApi.Services.Interfaces
{
    public interface IAnimalService
    {
        public Task<List<Animal>> GetAll();
        public Task<Animal> GetById(int id);
        public Task<bool> Add(Animal animal);
        public Task<bool> Delete(int id);
        public Task<bool> Update(Animal animal);
    }
}

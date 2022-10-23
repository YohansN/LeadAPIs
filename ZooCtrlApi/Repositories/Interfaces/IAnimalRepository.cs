using System.Collections.Generic;
using ZooCtrlApi.Models;

namespace ZooCtrlApi.Repositories.Interfaces
{
    public interface IAnimalRepository
    {
        public List<Animal> GetAll();
        public Animal GetById(int id);
        public void Add(Animal animal);
        public void Delete(int id);
        public void Update(Animal animal);
    }
}

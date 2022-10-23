using System.Collections.Generic;
using ZooCtrlApi.Models;

namespace ZooCtrlApi.Services.Interfaces
{
    public interface IAnimalService
    {
        public List<Animal> GetAll();
        public Animal GetById(int id);
        public void Add(Animal animal);
        public void Delete(int id);
        public void Update(Animal animal);
    }
}

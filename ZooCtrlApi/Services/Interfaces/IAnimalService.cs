using System.Collections.Generic;
using ZooCtrlApi.Models;

namespace ZooCtrlApi.Services.Interfaces
{
    public interface IAnimalService
    {
        public List<Animal> GetAll();
        public Animal GetById(int id);
        public bool Add(Animal animal);
        public bool Delete(int id);
        public bool Update(Animal animal);
    }
}

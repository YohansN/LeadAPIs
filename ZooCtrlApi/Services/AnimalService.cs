using Microsoft.EntityFrameworkCore.Update.Internal;
using System.Collections.Generic;
using ZooCtrlApi.Models;
using ZooCtrlApi.Repositories.Interfaces;
using ZooCtrlApi.Services.Interfaces;

namespace ZooCtrlApi.Services
{
    public class AnimalService : IAnimalService
    {
        private readonly IAnimalRepository _animalRepository;
        public AnimalService(IAnimalRepository animalRepository)
        {
            this._animalRepository = animalRepository;
        }
        
        //Verifica se um Id está ou não sendo usado(existente).
        private bool UsedId(int id)
        {
            var listAnimal = GetAll();
            if(listAnimal.Exists(x => x.IdAnimal == id))
                return true;
            return false;
        }

        public List<Animal> GetAll() => _animalRepository.GetAll();

        public Animal GetById(int id)
        {
            if(UsedId(id))
                return _animalRepository.GetById(id);
            //modificar depois: retornar notFound()
            return null;
        }
        
        public void Add(Animal animal)
        {
            if (UsedId(animal.IdAnimal))
                return;
            _animalRepository.Add(animal);
        }
        
        public void Delete(int id)
        {
            if(UsedId(id))
                _animalRepository.Delete(id);
            return;
        }
        
        public void Update(Animal animal)
        {
            if(UsedId(animal.IdAnimal))
                _animalRepository.Update(animal);
            return;
        }
    }
}

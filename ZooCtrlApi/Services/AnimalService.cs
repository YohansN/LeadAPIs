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
        private IFiloRepository _filoRepository;
        public AnimalService(IAnimalRepository animalRepository, IFiloRepository filoRepository)
        {
            this._animalRepository = animalRepository;
            this._filoRepository = filoRepository;
        }
        
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
            return null;
        }
        
        public bool Add(Animal animal)
        {
            //verificar se o id do animal está livre(ainda n existe) e se o idFilo é um filo já existente.
            Filo filo = _filoRepository.GetById(animal.IdFilo);
            if (!UsedId(animal.IdAnimal) && filo != null)
            {
                _animalRepository.Add(animal);
                return true;
            }
            return false;
        }

        public bool Update(Animal animal)
        {
            //verificar se o id do animal existe e se o idFilo é um filo que vai ser atualizado é existente.
            Filo filo = _filoRepository.GetById(animal.IdFilo);
            if (UsedId(animal.IdAnimal) && filo != null)
            {
                _animalRepository.Update(animal);
                return true;
            }
            return false;
        }

        public bool Delete(int id)
        {
            if (UsedId(id))
            {
                _animalRepository.Delete(id);
                return true;
            }
            return false; 
        }
    }
}

using Microsoft.EntityFrameworkCore.Update.Internal;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ZooCtrlApi.Models;
using ZooCtrlApi.Repositories.Interfaces;
using ZooCtrlApi.Services.Interfaces;

namespace ZooCtrlApi.Services
{
    public class AnimalService : IAnimalService
    {
        private readonly IAnimalRepository _animalRepository;
        private readonly IFiloRepository _filoRepository;
        public AnimalService(IAnimalRepository animalRepository, IFiloRepository filoRepository)
        {
            this._animalRepository = animalRepository;
            this._filoRepository = filoRepository;
        }

        public async Task<List<Animal>> GetAll()
        {
            var getAllAnimals = await _animalRepository.GetAll();
            return getAllAnimals;
        } 

        public async Task<Animal> GetById(int id)
        {
            if (await _animalRepository.IdExistsAsync(id))
            {
                var animalById = await _animalRepository.GetById(id);
                return animalById;
            }
            return null;
        }
        
        public async Task<bool> Add(Animal animal)
        {
            //verificar se o id do animal está livre(ainda não existe) e se o idFilo é um filo já existente.
            Filo filo = await _filoRepository.GetById(animal.IdFilo);
            if (!(await _animalRepository.IdExistsAsync(animal.IdAnimal)) && filo != null)
            {
                await _animalRepository.Add(animal);
                return true;
            }
            return false;
        }

        public async Task<bool> Update(Animal animal)
        {
            //verificar se o id do animal existe e se o idFilo que vai ser atualizado é existente.
            Filo filo = await _filoRepository.GetById(animal.IdFilo);
            if (await _animalRepository.IdExistsAsync(animal.IdAnimal) && filo != null)
            {
                await _animalRepository.Update(animal);
                return true;
            }
            return false;
        }

        public async Task<bool> Delete(int id)
        {
            if (await _animalRepository.IdExistsAsync(id))
            {
                await _animalRepository.Delete(id);
                return true;
            }
            return false; 
        }
    }
}

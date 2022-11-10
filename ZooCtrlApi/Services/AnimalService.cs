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
        
        private async Task<bool> UsedId(int id)
        {
            var listAnimal = await _animalRepository.GetById(id);
            if(listAnimal != null)
                return true;
            return false;
        }

        public async Task<List<Animal>> GetAll()
        {
            var getAllAnimals = await _animalRepository.GetAll();
            return getAllAnimals;
        } 

        public async Task<Animal> GetById(int id)
        {
            if (await UsedId(id))
            {
                var animalById = await _animalRepository.GetById(id);
                return animalById;
            }
            return null;
        }
        
        public async Task<bool> Add(Animal animal)
        {
            //verificar se o id do animal está livre(ainda n existe), se o idFilo é um filo já existente, e se o nome não esta nulo ou vazio.
            Filo filo = await _filoRepository.GetById(animal.IdFilo);
            if (!(await UsedId(animal.IdAnimal)) && filo != null && !String.IsNullOrEmpty(animal.Nome))
            {
                await _animalRepository.Add(animal);
                return true;
            }
            return false;
        }

        public async Task<bool> Update(Animal animal)
        {
            //verificar se o id do animal existe, se o idFilo que vai ser atualizado é existente, e se o nome não está nulo ou vazio.
            Filo filo = await _filoRepository.GetById(animal.IdFilo);
            if (await UsedId(animal.IdAnimal) && filo != null && !String.IsNullOrEmpty(animal.Nome))
            {
                await _animalRepository.Update(animal);
                return true;
            }
            return false;
        }

        public async Task<bool> Delete(int id)
        {
            if (await UsedId(id))
            {
                await _animalRepository.Delete(id);
                return true;
            }
            return false; 
        }
    }
}

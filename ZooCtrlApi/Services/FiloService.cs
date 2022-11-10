using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ZooCtrlApi.Models;
using ZooCtrlApi.Repositories.Interfaces;
using ZooCtrlApi.Services.Interfaces;

namespace ZooCtrlApi.Services
{
    public class FiloService : IFiloService
    {
        private readonly IFiloRepository _filoRepository;
        private readonly IAnimalRepository _animalRepository;
        public FiloService(IFiloRepository filoRepository, IAnimalRepository animalRepository)
        {
            this._filoRepository = filoRepository;
            this._animalRepository = animalRepository;
        }

        //Verifica se um Id está ou não sendo usado(existente).
        private async Task<bool> UsedId(int id)
        {
            var listFilo = await _filoRepository.GetById(id);
            if (listFilo != null)
                return true;
            return false;
        }

        public async Task<List<Filo>> GetAll()
        {
            var filoGetAll = await _filoRepository.GetAll();
            return filoGetAll;
        }
        

        public async Task<Filo> GetById(int id)
        {
            if (await UsedId(id))
            {
                var filoGetById = await _filoRepository.GetById(id);
                return filoGetById;
            }              
            return null;
        }

        public async Task<bool> Add(Filo filo)
        {
            if(!(await UsedId(filo.IdFilo)) && !String.IsNullOrEmpty(filo.Nome))
            {
                await _filoRepository.Add(filo);
                return true;
            }
            return false;
        }

        public async Task<bool> Update(Filo filo)
        {
            if (await UsedId(filo.IdFilo) && !String.IsNullOrEmpty(filo.Nome))
            {
                await _filoRepository.Update(filo);
                return true;
            }
            return false;
        }

        //Verificar se existem animais - Caso verdadeiro: retornar bad request. So é possivel apagar um filo caso ele não esteja sendo usado.
        public async Task<bool> Delete(int id)
        {
            var listAnimal = await _animalRepository.GetById(id);
            if (await UsedId(id) && !(listAnimal != null))
            {
                await _filoRepository.Delete(id);
                return true;
            }
            return false; 
        }

    }
}

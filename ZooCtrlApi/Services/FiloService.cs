using System.Collections.Generic;
using System.Threading.Tasks;
using ZooCtrlApi.Models;
using ZooCtrlApi.Repositories.Interfaces;
using ZooCtrlApi.Services.Interfaces;

namespace ZooCtrlApi.Services
{
    public class FiloService : IFiloService
    {
        private IFiloRepository _filoRepository;
        public FiloService(IFiloRepository filoRepository)
        {
            this._filoRepository = filoRepository;
        }

        //Verifica se um Id está ou não sendo usado(existente).
        private async Task<bool> UsedId(int id)
        {
            var listFilo = await _filoRepository.GetAll();
            if (listFilo.Exists(x => x.IdFilo == id))
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
            if(await UsedId(filo.IdFilo))
                return false;
            await _filoRepository.Add(filo);
            return true;
        }

        public async Task<bool> Update(Filo filo)
        {
            if (await UsedId(filo.IdFilo))
            {
                await _filoRepository.Update(filo);
                return true;
            }
            return false;
        }

        public async Task<bool> Delete(int id)
        {
            if (await UsedId(id))
            {
                await _filoRepository.Delete(id);
                return true;
            }
            return false; 
        }

    }
}

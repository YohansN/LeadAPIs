using System.Collections.Generic;
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
        private bool UsedId(int id)
        {
            var listFilo = GetAll();
            if (listFilo.Exists(x => x.IdFilo == id))
                return true;
            return false;
        }

        public List<Filo> GetAll() => _filoRepository.GetAll();

        public Filo GetById(int id)
        {
            if (UsedId(id))
                return _filoRepository.GetById(id);
            //modificar depois: retornar notFound()
            return null;
        }

        public void Add(Filo filo)
        {
            if(UsedId(filo.IdFilo))
                return; //modificar 
            _filoRepository.Add(filo);
        }

        public void Delete(int id)
        {
            if(UsedId(id))
                _filoRepository.Delete(id);
            return; //modificar 
        }

        public void Update(Filo filo)
        {
            if(UsedId(filo.IdFilo))
                _filoRepository.Update(filo);
            return; //modificar 
        }
    }
}

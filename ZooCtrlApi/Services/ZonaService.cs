using System.Collections.Generic;
using ZooCtrlApi.Models;
using ZooCtrlApi.Repositories.Interfaces;
using ZooCtrlApi.Services.Interfaces;

namespace ZooCtrlApi.Services
{
    public class ZonaService : IZonaService
    {
        private IZonaRepository _zonaRepository;
        private IFiloRepository _filoRepository;

        public ZonaService(IZonaRepository zonaRepository, IFiloRepository filoRepository)
        {
            _zonaRepository = zonaRepository;
            _filoRepository = filoRepository;
        }

         private bool UsedId(int id)
        {
            var listZona = GetAll();
            if (listZona.Exists(x => x.IdZona == id))
                return true;
            return false;
        }

        public List<Zona> GetAll() => _zonaRepository.GetAll();

        public Zona GetById(int id)
        {
            if (UsedId(id))
                return _zonaRepository.GetById(id);
            return null;
        }

        public bool Add(Zona zona)
        {
            //verificar se o id da Zona está livre(ainda n existe) e se o idFilo é um filo já existente.
            Filo filo = _filoRepository.GetById(zona.IdFilo);
            if (!UsedId(zona.IdZona) && filo != null)
            {
                _zonaRepository.Add(zona);
                return true;
            }
            return false;
        }

        public bool Delete(int id)
        {
            if (UsedId(id))
            {
                _zonaRepository.Delete(id);
                return true;
            }
            return false;
        }

        public bool Update(Zona zona)
        {
            //verificar se o id do animal existe e se o idFilo é um filo que vai ser atualizado é existente.
            Filo filo = _filoRepository.GetById(zona.IdFilo);
            if (UsedId(zona.IdZona) && filo != null)
            {
                _zonaRepository.Update(zona);
                return true;
            }
            return false;
        }
    }
}

using System.Collections.Generic;
using System.Threading.Tasks;
using ZooCtrlApi.Models;
using ZooCtrlApi.Repositories.Interfaces;
using ZooCtrlApi.Services.Interfaces;

namespace ZooCtrlApi.Services
{
    public class ZonaService : IZonaService
    {
        private readonly IZonaRepository _zonaRepository;
        private readonly IFiloRepository _filoRepository;

        public ZonaService(IZonaRepository zonaRepository, IFiloRepository filoRepository)
        {
            _zonaRepository = zonaRepository;
            _filoRepository = filoRepository;
        }

         private async Task<bool> UsedId(int id)
        {
            var listZona = await _zonaRepository.GetAll();
            if (listZona.Exists(x => x.IdZona == id))
                return true;
            return false;
        }

        public async Task<List<Zona>> GetAll()
        {
            var zonaGetAll = await _zonaRepository.GetAll();
            return zonaGetAll;
        }  
            

        public async Task<Zona> GetById(int id)
        {
            if (await UsedId(id))
            {
                var zonaGetById = await _zonaRepository.GetById(id);
                return zonaGetById;
            }
            return null;
        }

        public async Task<bool> Add(Zona zona)
        {
            //verificar se o id da Zona está livre(ainda n existe) e se o idFilo é um filo já existente.
            Filo filo = await _filoRepository.GetById(zona.IdFilo);
            if (!(await UsedId(zona.IdZona)) && filo != null)
            {
                await _zonaRepository.Add(zona);
                return true;
            }
            return false;
        }

        public async Task<bool> Delete(int id)
        {
            if (await UsedId(id))
            {
                await _zonaRepository.Delete(id);
                return true;
            }
            return false;
        }

        public async Task<bool> Update(Zona zona)
        {
            //verificar se o id do animal existe e se o idFilo é um filo que vai ser atualizado é existente.
            Filo filo = await _filoRepository.GetById(zona.IdFilo);
            if (await UsedId(zona.IdZona) && filo != null)
            {
                await _zonaRepository.Update(zona);
                return true;
            }
            return false;
        }
    }
}

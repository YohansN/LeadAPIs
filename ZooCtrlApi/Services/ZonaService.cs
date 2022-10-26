using System.Collections.Generic;
using ZooCtrlApi.Models;
using ZooCtrlApi.Services.Interfaces;

namespace ZooCtrlApi.Services
{
    public class ZonaService : IZonaService
    {
        private IZonaService _zonaService;

        public ZonaService(IZonaService zonaService)
        {
            _zonaService = zonaService;
        }

         private bool UsedId(int id)
        {
            var listZona = GetAll();
            if (listZona.Exists(x => x.IdZona == id))
                return true;
            return false;
        }

        public List<Zona> GetAll() => _zonaService.GetAll();

        public Zona GetById(int id)
        {
            if (UsedId(id))
                return _zonaService.GetById(id);
            //modificar depois: retornar notFound()
            return null;
        }

        public void Add(Zona zona)
        {
            if (UsedId(zona.IdZona))
                return; //modificar 
            _zonaService.Add(zona);
        }

        public void Delete(int id)
        {
            if (UsedId(id))
                _zonaService.Delete(id);
            return; //modificar 
        }

        public void Update(Zona zona)
        {
            if (UsedId(zona.IdZona))
                _zonaService.Update(zona);
            return; //modificar 
        }
    }
}

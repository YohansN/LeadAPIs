using System.Collections.Generic;
using ZooCtrlApi.Models;

namespace ZooCtrlApi.Services.Interfaces
{
    public interface IZonaService
    {
        public List<Zona> GetAll();
        public Zona GetById(int id);
        public bool Add(Zona zona);
        public bool Delete(int id);
        public bool Update(Zona zona);
    }
}

using System.Collections.Generic;
using ZooCtrlApi.Models;

namespace ZooCtrlApi.Repositories.Interfaces
{
    public interface IZonaRepository
    {
        public List<Zona> GetAll();
        public Zona GetById(int id);
        public void Add(Zona zona);
        public void Delete(int id);
        public void Update(Zona zona);
    }
}

using System.Collections.Generic;
using ZooCtrlApi.Models;

namespace ZooCtrlApi.Services.Interfaces
{
    public interface IFiloService
    {
        public List<Filo> GetAll();
        public Filo GetById(int id);
        public bool Add(Filo filo);
        public bool Delete(int id);
        public bool Update(Filo filo);
    }
}

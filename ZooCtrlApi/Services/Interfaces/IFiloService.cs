using System.Collections.Generic;
using ZooCtrlApi.Models;

namespace ZooCtrlApi.Services.Interfaces
{
    public interface IFiloService
    {
        public List<Filo> GetAll();
        public Filo GetById(int id);
        public void Add(Filo filo);
        public void Delete(int id);
        public void Update(Filo filo);
    }
}

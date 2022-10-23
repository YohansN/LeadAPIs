using System.Collections.Generic;
using System.Linq;
using ZooCtrlApi.Data;
using ZooCtrlApi.Models;
using ZooCtrlApi.Repositories.Interfaces;

namespace ZooCtrlApi.Repositories
{
    public class FiloRepository : IFiloRepository
    {
        private Context _context;
        public FiloRepository(Context context)
        {
            this._context = context;
        }

        public List<Filo> GetAll()
        {
            return _context.Filos.ToList();
        }

        public Filo GetById(int id)
        {
            return _context.Filos.FirstOrDefault(f => f.IdFilo == id);
        }

        public void Add(Filo filo)
        {
            _context.Filos.Add(filo);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            _context.Filos.Remove(GetById(id));
            _context.SaveChanges();
        }

        public void Update(Filo filo)
        {
            _context.Filos.Update(filo);
            _context.SaveChanges();
        }
    }
}

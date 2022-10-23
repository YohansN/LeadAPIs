using System.Collections.Generic;
using System.Linq;
using ZooCtrlApi.Data;
using ZooCtrlApi.Models;
using ZooCtrlApi.Repositories.Interfaces;

namespace ZooCtrlApi.Repositories
{
    public class ZonaRepository : IZonaRepository
    {
        private Context _context;
        public ZonaRepository(Context context)
        {
            this._context = context;
        }

        public List<Zona> GetAll()
        {
            return _context.Zonas.ToList();
        }

        public Zona GetById(int id)
        {
            return _context.Zonas.FirstOrDefault(z => z.IdZona == id);
        }

        public void Add(Zona zona)
        {
            _context.Zonas.Add(zona);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            _context.Zonas.Remove(GetById(id));
            _context.SaveChanges();
        }

        public void Update(Zona zona)
        {
            _context.Zonas.Update(zona);
            _context.SaveChanges();
        }
    }
}

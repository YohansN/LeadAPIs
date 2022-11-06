using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZooCtrlApi.Data;
using ZooCtrlApi.Models;
using ZooCtrlApi.Repositories.Interfaces;

namespace ZooCtrlApi.Repositories
{
    public class ZonaRepository : IZonaRepository
    {
        private readonly Context _context;
        public ZonaRepository(Context context)
        {
            this._context = context;
        }

        public async Task<List<Zona>> GetAll()
        {
            var zonaGetAll = await _context.Zonas.ToListAsync();
            return zonaGetAll;
        }

        public async Task<Zona> GetById(int id)
        {
            var zonaGetById = await _context.Zonas.FirstOrDefaultAsync(z => z.IdZona == id);
            return zonaGetById;
        }

        public async Task Add(Zona zona)
        {
            _context.Zonas.Add(zona);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            _context.Zonas.Remove(await GetById(id));
            await _context.SaveChangesAsync();
        }

        public async Task Update(Zona zona)
        {
            _context.Zonas.Update(zona);
            await _context.SaveChangesAsync();
        }
    }
}

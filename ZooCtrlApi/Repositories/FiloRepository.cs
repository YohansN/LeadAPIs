using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZooCtrlApi.Data;
using ZooCtrlApi.Models;
using ZooCtrlApi.Repositories.Interfaces;

namespace ZooCtrlApi.Repositories
{
    public class FiloRepository : IFiloRepository
    {
        private readonly Context _context;
        public FiloRepository(Context context)
        {
            this._context = context;
        }

        public async Task<List<Filo>> GetAll()
        {
            var filoGetAll = await _context.Filos.ToListAsync();
            return filoGetAll;
        }

        public async Task<Filo> GetById(int id)
        {
            
            var filoGetById = await _context.Filos.FirstOrDefaultAsync(f => f.IdFilo == id);
            return filoGetById;
        }

        public async Task Add(Filo filo)
        {
            _context.Filos.Add(filo);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            _context.Filos.Remove(await GetById(id));
            await _context.SaveChangesAsync();
        }

        public async Task Update(Filo filo)
        {
            _context.Filos.Update(filo);
            await _context.SaveChangesAsync();
        }
    }
}

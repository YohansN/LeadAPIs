using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZooCtrlApi.Data;
using ZooCtrlApi.Models;
using ZooCtrlApi.Repositories.Interfaces;

namespace ZooCtrlApi.Repositories
{
    public class AnimalRepository : IAnimalRepository
    {
        private readonly Context _context;
        public AnimalRepository(Context context)
        {
            this._context = context;
        }
        
        public async Task<List<Animal>> GetAll()
        {
            var listAnimals = await _context.Animals.ToListAsync();
            return listAnimals;
        }
        
        public async Task<Animal> GetById(int id)
        {
            var animalById = await _context.Animals.FirstOrDefaultAsync(a => a.IdAnimal == id);
            return animalById;
        }
        
        public async Task Add(Animal animal)
        {
            _context.Animals.Add(animal);
            await _context.SaveChangesAsync();
        }
        
        public async Task Delete(int id)
        {
            _context.Animals.Remove(await GetById(id));
            await _context.SaveChangesAsync();
        }
        
        public async Task Update(Animal animal)
        {
            _context.Animals.Update(animal);
            await _context.SaveChangesAsync();
        }
    }
}

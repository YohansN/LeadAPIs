using System.Collections.Generic;
using System.Linq;
using ZooCtrlApi.Data;
using ZooCtrlApi.Models;
using ZooCtrlApi.Repositories.Interfaces;

namespace ZooCtrlApi.Repositories
{
    public class AnimalRepository : IAnimalRepository
    {
        private Context _context;
        public AnimalRepository(Context context)
        {
            this._context = context;
        }
        
        public List<Animal> GetAll()
        {
            return _context.Animals.ToList();
        }
        
        public Animal GetById(int id)
        {
            return _context.Animals.FirstOrDefault(a => a.IdAnimal == id);
        }
        
        public void Add(Animal animal)
        {
            _context.Animals.Add(animal);
            _context.SaveChanges();
        }
        
        public void Delete(int id)
        {
            _context.Animals.Remove(GetById(id));
            _context.SaveChanges();
        }
        
        public void Update(Animal animal)
        {
            _context.Animals.Update(animal);
            _context.SaveChanges();
        }
    }
}

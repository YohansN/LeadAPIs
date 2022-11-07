using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ZooCtrlApi.Models;
using ZooCtrlApi.Services;
using ZooCtrlApi.Services.Interfaces;

namespace ZooCtrlApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AnimalController : ControllerBase
    {
        private readonly IAnimalService _animalService;
        public AnimalController(IAnimalService animalService)
        {
            this._animalService = animalService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var getAllAnimals = await _animalService.GetAll();
            return Ok(getAllAnimals);
        }
            

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var animalById = await _animalService.GetById(id);
            if(animalById != null)
                return Ok(animalById);
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Add(Animal animal)
        {
            var animalAdd = await _animalService.Add(animal);
            if (animalAdd)
                return NoContent();
            return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> Update(Animal animal)
        {
            var animalUpdate = await _animalService.Update(animal);
            if(animalUpdate)
                NoContent();
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var animalDelete = await _animalService.Delete(id);
            if (animalDelete)
                return NoContent();
            return BadRequest();
        }
    }
}

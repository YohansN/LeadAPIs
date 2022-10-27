using Microsoft.AspNetCore.Mvc;
using ZooCtrlApi.Models;
using ZooCtrlApi.Services;
using ZooCtrlApi.Services.Interfaces;

namespace ZooCtrlApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AnimalController : ControllerBase
    {
        private IAnimalService _animalService;
        public AnimalController(IAnimalService animalService)
        {
            this._animalService = animalService;
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_animalService.GetAll());

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var animalById = _animalService.GetById(id);
            if(animalById != null)
                return Ok(animalById);
            return NotFound();
        }

        [HttpPost]
        public IActionResult Add(Animal animal)
        {
            var animalAdd = _animalService.Add(animal);
            if (animalAdd)
                return NoContent();
            return BadRequest();
        }

        [HttpPut]
        public IActionResult Update(Animal animal)
        {
            var animalUpdate = _animalService.Update(animal);
            if(animalUpdate)
                NoContent();
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var animalDelete = _animalService.Delete(id);
            if (animalDelete)
                return NoContent();
            return BadRequest();
        }
    }
}

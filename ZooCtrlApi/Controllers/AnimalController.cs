using Microsoft.AspNetCore.Mvc;
using System;
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

        /// <summary>
        /// Retorna, em formato de lista de objetos, todos os animais cadastrados no banco de dados.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var getAllAnimals = await _animalService.GetAll();
            return Ok(getAllAnimals);
        }
            
        /// <summary>
        /// Retorna UM objeto animal de acordo com o ID passado como parâmetro. O ID passado deve ser válido.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            if (id <= 0)
                return BadRequest("Id passado é invalido.");

            var animalById = await _animalService.GetById(id);
            if(animalById != null)
                return Ok(animalById);
            return NotFound();
        }

        /// <summary>
        /// Cadastra um objeto animal no banco de dados.
        /// </summary>
        /// <param name="animal"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Add(Animal animal)
        {
            if (String.IsNullOrEmpty(animal.Nome) || animal.IdAnimal <= 0)
                return BadRequest("Nome e/ou Id invalido(s).");

            var animalAdd = await _animalService.Add(animal);
            if (animalAdd)
                return Created("Animal cadastrado!", animal);
            return BadRequest();
        }

        /// <summary>
        /// Atualiza um objeto animal no banco de dados. Os parâmetros passados ao objeto devem ser válidos.
        /// </summary>
        /// <param name="animal"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Update(Animal animal)
        {
            if (String.IsNullOrEmpty(animal.Nome) || animal.IdAnimal <= 0)
                return BadRequest("Nome e/ou Id invalido(s).");

            var animalUpdate = await _animalService.Update(animal);
            if(animalUpdate)
                return NoContent();
            return BadRequest();
        }

        /// <summary>
        /// Apaga um objeto animal do banco de dados caso ele exista. O Id passado deve ser válido e existente.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
                return BadRequest("Id passado é invalido.");

            var animalDelete = await _animalService.Delete(id);
            if (animalDelete)
                return NoContent();
            return BadRequest();
        }
    }
}

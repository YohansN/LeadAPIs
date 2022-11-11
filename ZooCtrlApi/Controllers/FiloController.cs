using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using ZooCtrlApi.Models;
using ZooCtrlApi.Services.Interfaces;

namespace ZooCtrlApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FiloController : ControllerBase
    {
        private readonly IFiloService _filoService;
        public FiloController(IFiloService filoService)
        {
            this._filoService = filoService;
        }

        /// <summary>
        /// Retorna, em formato de lista de objetos, todos os filos cadastrados no banco de dados.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var filoGetAll = await _filoService.GetAll();
            return Ok(filoGetAll);
        }

        /// <summary>
        /// Retorna UM objeto Filo de acordo com o ID passado como parâmetro. O ID passado deve ser válido.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            if (id <= 0)
                return BadRequest("Id passado é invalido.");

            var filoById = await _filoService.GetById(id);
            if(filoById != null)
                return Ok(filoById);
            return NotFound();
        }

        /// <summary>
        /// Cadastra um objeto filo no banco de dados.
        /// </summary>
        /// <param name="filo"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Add(Filo filo)
        {
            if (String.IsNullOrEmpty(filo.Nome) || filo.IdFilo <= 0)
                return BadRequest("Nome e/ou Id invalido(s).");

            var filoAdd = await _filoService.Add(filo);
            if(filoAdd)
                return Created("Filo cadastrado!", filo);
            return BadRequest();
        }

        /// <summary>
        /// Atualiza um objeto filo no banco de dados. Os parâmetros passados ao objeto devem ser válidos.
        /// </summary>
        /// <param name="filo"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Update(Filo filo)
        {
            if (String.IsNullOrEmpty(filo.Nome) || filo.IdFilo <= 0)
                return BadRequest("Nome e/ou Id invalido(s).");

            var filoUpdate = await _filoService.Update(filo);
            if (filoUpdate)
                return Ok();
            return BadRequest();
        }

        /// <summary>
        /// Apaga um objeto filo do banco de dados caso ele exista. O Id passado deve ser válido e existente.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
                return BadRequest("Id passado é invalido.");

            var filoDelete = await _filoService.Delete(id);
            if (filoDelete)
                return NoContent();
            return BadRequest();
        }
    }
}

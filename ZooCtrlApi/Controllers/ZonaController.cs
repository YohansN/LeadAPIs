using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ZooCtrlApi.Models;
using ZooCtrlApi.Services;
using ZooCtrlApi.Services.Interfaces;

namespace ZooCtrlApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ZonaController : ControllerBase
    {
        private readonly IZonaService _zonaService;
        public ZonaController(IZonaService zonaService)
        {
            this._zonaService = zonaService;
        }

        /// <summary>
        /// Retorna, em formato de lista de objetos, todas as zonas cadastradas no banco de dados.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _zonaService.GetAll());
        }

        /// <summary>
        /// Retorna UM objeto Zona de acordo com o ID passado como parâmetro. O ID passado deve ser válido.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            if (id <= 0)
                return BadRequest("Id passado é invalido.");

            var zonaById = await _zonaService.GetById(id);
            if (zonaById != null)
                return Ok(zonaById);
            return NotFound();
        }

        /// <summary>
        /// Cadastra um objeto zona no banco de dados.
        /// </summary>
        /// <param name="zona"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Add(Zona zona)
        {
            var zonaAdd = await _zonaService.Add(zona);
            if (zonaAdd)
                return Created("Zona cadastrada!",zona);
            return BadRequest();
        }

        /// <summary>
        /// Atualiza um objeto zona no banco de dados. Os parâmetros passados ao objeto devem ser válidos.
        /// </summary>
        /// <param name="zona"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Update(Zona zona)
        {
            var zonaUpdate = await _zonaService.Update(zona);
            if (zonaUpdate)
                return Ok();
            return BadRequest();
        }

        /// <summary>
        /// Apaga um objeto zona do banco de dados caso ele exista. O Id passado deve ser válido e existente.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
                return BadRequest("Id passado é invalido.");

            var zonaDelete = await _zonaService.Delete(id);
            if (zonaDelete)
                return NoContent();
            return BadRequest();
        }
    }
}

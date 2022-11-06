using Microsoft.AspNetCore.Mvc;
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
        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _filoService.GetAll());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var filoById = await _filoService.GetById(id);
            if(filoById != null)
                return Ok(filoById);
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Add(Filo filo)
        {
            var filoAdd = await _filoService.Add(filo);
            if(filoAdd)
                return Ok();
            return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> Update(Filo filo)
        {
            var filoUpdate = await _filoService.Update(filo);
            if (filoUpdate)
                return NoContent();
            return BadRequest();
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var filoDelete = await _filoService.Delete(id);
            if (filoDelete)
                return NoContent();
            return BadRequest();
        }
    }
}

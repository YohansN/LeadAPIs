using Microsoft.AspNetCore.Mvc;
using ZooCtrlApi.Models;
using ZooCtrlApi.Services.Interfaces;

namespace ZooCtrlApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FiloController : ControllerBase
    {
        private IFiloService _filoService;
        public FiloController(IFiloService filoService)
        {
            this._filoService = filoService;
        }
        [HttpGet]
        public IActionResult GetAll() => Ok(_filoService.GetAll());

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var filoById = _filoService.GetById(id);
            if(filoById != null)
                return Ok(filoById);
            return NotFound();
        }

        [HttpPost]
        public IActionResult Add(Filo filo)
        {
            var filoAdd = _filoService.Add(filo);
            if(filoAdd)
                return Ok();
            return BadRequest();
        }

        [HttpPut]
        public IActionResult Update(Filo filo)
        {
            var filoUpdate = _filoService.Update(filo);
            if (filoUpdate)
                return NoContent();
            return BadRequest();
        }
        
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var filoDelete = _filoService.Delete(id);
            if (filoDelete)
                return NoContent();
            return BadRequest();
        }
    }
}

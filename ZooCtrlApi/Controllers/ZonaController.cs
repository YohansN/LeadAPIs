using Microsoft.AspNetCore.Mvc;
using ZooCtrlApi.Models;
using ZooCtrlApi.Services;
using ZooCtrlApi.Services.Interfaces;

namespace ZooCtrlApi.Controllers
{
    public class ZonaController : ControllerBase
    {
        private IZonaService _zonaService;
        public ZonaController(IZonaService zonaService)
        {
            this._zonaService = zonaService;
        }
        [HttpGet]
        public IActionResult GetAll() => Ok(_zonaService.GetAll());

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var zonaById = _zonaService.GetById(id);
            if (zonaById != null)
                return Ok(zonaById);
            return NotFound();
        }

        [HttpPost]
        public IActionResult Add(Zona zona)
        {
            var zonaAdd = _zonaService.Add(zona);
            if (zonaAdd)
                return Ok();
            return BadRequest();
        }

        [HttpPut]
        public IActionResult Update(Zona zona)
        {
            var zonaUpdate = _zonaService.Update(zona);
            if (zonaUpdate)
                return NoContent();
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var zonaDelete = _zonaService.Delete(id);
            if (zonaDelete)
                return NoContent();
            return BadRequest();
        }
    }
}

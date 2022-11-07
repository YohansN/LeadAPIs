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
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _zonaService.GetAll());
        }
            

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var zonaById = await _zonaService.GetById(id);
            if (zonaById != null)
                return Ok(zonaById);
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Add(Zona zona)
        {
            var zonaAdd = await _zonaService.Add(zona);
            if (zonaAdd)
                return Ok();
            return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> Update(Zona zona)
        {
            var zonaUpdate = await _zonaService.Update(zona);
            if (zonaUpdate)
                return NoContent();
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var zonaDelete = await _zonaService.Delete(id);
            if (zonaDelete)
                return NoContent();
            return BadRequest();
        }
    }
}

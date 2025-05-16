using Microsoft.AspNetCore.Mvc;
using EntrenosApp.Business.Services;
using EntrenosApp.Models.DTOs;
using Microsoft.AspNetCore.Authorization;

namespace EntrenosApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class EntrenamientoController : ControllerBase
    {
        private readonly EntrenamientoService _service;

        public EntrenamientoController(EntrenamientoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EntrenamientoDTO>>> GetAll(
    string? intensidad,
    bool? completado,
    string? orden
)
        {
            var lista = await _service.GetFilteredAsync(intensidad, completado, orden);
            return Ok(lista);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<EntrenamientoDTO>> GetById(int id)
        {
            var item = await _service.GetByIdAsync(id);
            if (item == null) return NotFound();
            return Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult<EntrenamientoDTO>> Create(EntrenamientoCreateDTO dto)
        {
            var creado = await _service.AddAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = creado.Id }, creado);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var ok = await _service.DeleteAsync(id);
            if (!ok) return NotFound();
            return NoContent();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using EntrenosApp.Business.Services;
using EntrenosApp.Models.DTOs;
using Microsoft.AspNetCore.Authorization;

namespace EntrenosApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class CategoriaEntrenamientoController : ControllerBase
    {
        private readonly CategoriaEntrenamientoService _service;

        public CategoriaEntrenamientoController(CategoriaEntrenamientoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoriaEntrenamientoDTO>>> GetAll()
        {
            var categorias = await _service.GetAllAsync();
            return Ok(categorias);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoriaEntrenamientoDTO>> GetById(int id)
        {
            var categoria = await _service.GetByIdAsync(id);
            if (categoria == null) return NotFound();
            return Ok(categoria);
        }

        [HttpPost]
        public async Task<ActionResult<CategoriaEntrenamientoDTO>> Create(CategoriaEntrenamientoDTO dto)
        {
            var creada = await _service.AddAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = creada.Id }, creada);
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

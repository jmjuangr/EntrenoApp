using Microsoft.AspNetCore.Mvc;
using EntrenosApp.Business.Services;
using EntrenosApp.Models.DTOs;
using Microsoft.AspNetCore.Authorization;

namespace EntrenosApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin")]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioService _service;

        public UsuarioController(UsuarioService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioDTO>>> GetAll()
        {
            var usuarios = await _service.GetAllAsync();
            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioDTO>> GetById(int id)
        {
            var usuario = await _service.GetByIdAsync(id);
            if (usuario == null) return NotFound();
            return Ok(usuario);
        }

        [HttpPost]
        public async Task<ActionResult<UsuarioDTO>> Create(UsuarioCreateDTO dto)
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

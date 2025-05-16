using EntrenosApp.Models;
using EntrenosApp.Models.DTOs;
using EntrenosApp.Data.Repositories;

namespace EntrenosApp.Business.Services
{
    public class UsuarioService
    {
        private readonly UsuarioRepository _repo;

        public UsuarioService(UsuarioRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<UsuarioDTO>> GetAllAsync()
        {
            var usuarios = await _repo.GetAllAsync();
            return usuarios.Select(u => new UsuarioDTO
            {
                Id = u.Id,
                Nombre = u.Nombre,
                Edad = u.Edad,
                Genero = u.Genero,
                Nivel = u.Nivel,
                Admin = u.Admin
            }).ToList();
        }

        public async Task<UsuarioDTO?> GetByIdAsync(int id)
        {
            var u = await _repo.GetByIdAsync(id);
            if (u == null) return null;

            return new UsuarioDTO
            {
                Id = u.Id,
                Nombre = u.Nombre,
                Edad = u.Edad,
                Genero = u.Genero,
                Nivel = u.Nivel,
                Admin = u.Admin
            };
        }

        public async Task<UsuarioDTO> AddAsync(UsuarioCreateDTO dto)
        {
            var usuario = new Usuario
            {
                Nombre = dto.Nombre,
                Edad = dto.Edad,
                Genero = dto.Genero,
                Nivel = dto.Nivel,
                Admin = dto.Admin,
                Pass = dto.Pass
            };

            var creado = await _repo.AddAsync(usuario);

            return new UsuarioDTO
            {
                Id = creado.Id,
                Nombre = creado.Nombre,
                Edad = creado.Edad,
                Genero = creado.Genero,
                Nivel = creado.Nivel,
                Admin = creado.Admin
            };
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repo.DeleteAsync(id);
        }
    }
}

using EntrenosApp.Models;
using EntrenosApp.Models.DTOs;
using EntrenosApp.Data.Repositories;

namespace EntrenosApp.Business.Services
{
    public class CategoriaEntrenamientoService
    {
        private readonly CategoriaEntrenamientoRepository _repo;

        public CategoriaEntrenamientoService(CategoriaEntrenamientoRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<CategoriaEntrenamientoDTO>> GetAllAsync()
        {
            var categorias = await _repo.GetAllAsync();
            return categorias.Select(c => new CategoriaEntrenamientoDTO
            {
                Id = c.Id,
                Tipo = c.Tipo,
                ColorVisual = c.ColorVisual
            }).ToList();
        }

        public async Task<CategoriaEntrenamientoDTO?> GetByIdAsync(int id)
        {
            var c = await _repo.GetByIdAsync(id);
            if (c == null) return null;

            return new CategoriaEntrenamientoDTO
            {
                Id = c.Id,
                Tipo = c.Tipo,
                ColorVisual = c.ColorVisual
            };
        }

        public async Task<CategoriaEntrenamientoDTO> AddAsync(CategoriaEntrenamientoDTO dto)
        {
            var nueva = new CategoriaEntrenamiento
            {
                Tipo = dto.Tipo,
                ColorVisual = dto.ColorVisual
            };

            var creada = await _repo.AddAsync(nueva);

            return new CategoriaEntrenamientoDTO
            {
                Id = creada.Id,
                Tipo = creada.Tipo,
                ColorVisual = creada.ColorVisual
            };
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repo.DeleteAsync(id);
        }
    }
}

using EntrenosApp.Models;
using EntrenosApp.Models.DTOs;
using EntrenosApp.Data.Repositories;

namespace EntrenosApp.Business.Services
{
    public class EntrenamientoService
    {
        private readonly EntrenamientoRepository _repo;

        public EntrenamientoService(EntrenamientoRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<EntrenamientoDTO>> GetAllAsync()
        {
            var lista = await _repo.GetAllAsync();
            return lista.Select(e => new EntrenamientoDTO
            {
                Id = e.Id,
                UsuarioId = e.UsuarioId,
                UsuarioNombre = e.Usuario?.Nombre ?? "",
                CategoriaEntrenamientoId = e.CategoriaEntrenamientoId,
                CategoriaNombre = e.CategoriaEntrenamiento?.Tipo ?? "",
                Descripcion = e.Descripcion,
                Duracion = e.Duracion,
                Fecha = e.Fecha,
                Intensidad = e.Intensidad,
                Completado = e.Completado,
                PuntosExperencia = e.PuntosExperencia
            }).ToList();
        }

        public async Task<EntrenamientoDTO?> GetByIdAsync(int id)
        {
            var e = await _repo.GetByIdAsync(id);
            if (e == null) return null;

            return new EntrenamientoDTO
            {
                Id = e.Id,
                UsuarioId = e.UsuarioId,
                UsuarioNombre = e.Usuario?.Nombre ?? "",
                CategoriaEntrenamientoId = e.CategoriaEntrenamientoId,
                CategoriaNombre = e.CategoriaEntrenamiento?.Tipo ?? "",
                Descripcion = e.Descripcion,
                Duracion = e.Duracion,
                Fecha = e.Fecha,
                Intensidad = e.Intensidad,
                Completado = e.Completado,
                PuntosExperencia = e.PuntosExperencia
            };
        }

        public async Task<EntrenamientoDTO> AddAsync(EntrenamientoCreateDTO dto)
        {
            var nuevo = new Entrenamiento
            {
                UsuarioId = dto.UsuarioId,
                CategoriaEntrenamientoId = dto.CategoriaEntrenamientoId,
                Descripcion = dto.Descripcion,
                Duracion = dto.Duracion,
                Fecha = dto.Fecha,
                Intensidad = dto.Intensidad,
                Completado = dto.Completado,
                PuntosExperencia = dto.PuntosExperencia
            };

            var creado = await _repo.AddAsync(nuevo);

            return new EntrenamientoDTO
            {
                Id = creado.Id,
                UsuarioId = creado.UsuarioId,
                CategoriaEntrenamientoId = creado.CategoriaEntrenamientoId,
                Descripcion = creado.Descripcion,
                Duracion = creado.Duracion,
                Fecha = creado.Fecha,
                Intensidad = creado.Intensidad,
                Completado = creado.Completado,
                PuntosExperencia = creado.PuntosExperencia,
                UsuarioNombre = "", // opcional cargar después
                CategoriaNombre = ""
            };
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repo.DeleteAsync(id);
        }
        public async Task<List<EntrenamientoDTO>> GetFilteredAsync(string? intensidad, bool? completado, string? orden)
        {
            var entrenamientos = await _repo.GetAllAsync();

            if (!string.IsNullOrWhiteSpace(intensidad))
                entrenamientos = entrenamientos
                    .Where(e => e.Intensidad.ToLower() == intensidad.ToLower())
                    .ToList();

            if (completado.HasValue)
                entrenamientos = entrenamientos
                    .Where(e => e.Completado == completado.Value)
                    .ToList();

            if (orden == "fecha_asc")
                entrenamientos = entrenamientos.OrderBy(e => e.Fecha).ToList();
            else if (orden == "fecha_desc")
                entrenamientos = entrenamientos.OrderByDescending(e => e.Fecha).ToList();

            return entrenamientos.Select(e => new EntrenamientoDTO
            {
                Id = e.Id,
                UsuarioId = e.UsuarioId,
                UsuarioNombre = e.Usuario?.Nombre ?? "",
                CategoriaEntrenamientoId = e.CategoriaEntrenamientoId,
                CategoriaNombre = e.CategoriaEntrenamiento?.Tipo ?? "",
                Descripcion = e.Descripcion,
                Duracion = e.Duracion,
                Fecha = e.Fecha,
                Intensidad = e.Intensidad,
                Completado = e.Completado,
                PuntosExperencia = e.PuntosExperencia
            }).ToList();
        }

    }
}

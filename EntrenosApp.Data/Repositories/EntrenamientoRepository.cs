using EntrenosApp.Models;
using Microsoft.EntityFrameworkCore;

namespace EntrenosApp.Data.Repositories
{
    public class EntrenamientoRepository
    {
        private readonly EntrenosDbContext _context;

        public EntrenamientoRepository(EntrenosDbContext context)
        {
            _context = context;
        }

        public async Task<List<Entrenamiento>> GetAllAsync()
        {
            return await _context.Entrenamientos
                .Include(e => e.Usuario)
                .Include(e => e.CategoriaEntrenamiento)
                .ToListAsync();
        }

        public async Task<Entrenamiento?> GetByIdAsync(int id)
        {
            return await _context.Entrenamientos
                .Include(e => e.Usuario)
                .Include(e => e.CategoriaEntrenamiento)
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<Entrenamiento> AddAsync(Entrenamiento entrenamiento)
        {
            _context.Entrenamientos.Add(entrenamiento);
            await _context.SaveChangesAsync();
            return entrenamiento;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entrenamiento = await _context.Entrenamientos.FindAsync(id);
            if (entrenamiento == null) return false;

            _context.Entrenamientos.Remove(entrenamiento);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

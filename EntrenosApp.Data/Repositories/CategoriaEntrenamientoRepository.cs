using EntrenosApp.Models;
using EntrenosApp.Data;
using Microsoft.EntityFrameworkCore;

namespace EntrenosApp.Data.Repositories
{
    public class CategoriaEntrenamientoRepository
    {
        private readonly EntrenosDbContext _context;

        public CategoriaEntrenamientoRepository(EntrenosDbContext context)
        {
            _context = context;
        }

        public async Task<List<CategoriaEntrenamiento>> GetAllAsync()
        {
            return await _context.CategoriaEntrenamientos.ToListAsync();
        }

        public async Task<CategoriaEntrenamiento?> GetByIdAsync(int id)
        {
            return await _context.CategoriaEntrenamientos.FindAsync(id);
        }

        public async Task<CategoriaEntrenamiento> AddAsync(CategoriaEntrenamiento categoria)
        {
            _context.CategoriaEntrenamientos.Add(categoria);
            await _context.SaveChangesAsync();
            return categoria;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var categoria = await _context.CategoriaEntrenamientos.FindAsync(id);
            if (categoria == null) return false;

            _context.CategoriaEntrenamientos.Remove(categoria);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

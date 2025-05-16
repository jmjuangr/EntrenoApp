using Microsoft.EntityFrameworkCore;
using EntrenosApp.Models;

namespace EntrenosApp.Data
{
    public class EntrenosDbContext : DbContext
    {
        public EntrenosDbContext(DbContextOptions<EntrenosDbContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Entrenamiento> Entrenamientos { get; set; }
    }
}

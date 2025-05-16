using System;

namespace EntrenosApp.Models.DTOs
{
    public class EntrenamientoCreateDTO
    {
        public int UsuarioId { get; set; }
        public int CategoriaEntrenamientoId { get; set; }
        public string Descripcion { get; set; }
        public int Duracion { get; set; }
        public DateTime Fecha { get; set; }
        public string Intensidad { get; set; }
        public bool Completado { get; set; }
        public int PuntosExperencia { get; set; }
    }
}

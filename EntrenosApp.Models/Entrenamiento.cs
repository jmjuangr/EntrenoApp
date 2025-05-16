using System;

namespace EntrenosApp.Models
{
    public class Entrenamiento
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        public string Tipo { get; set; } // "cardio", "fuerza", etc.
        public int Duracion { get; set; } // en minutos
        public DateTime Fecha { get; set; }
        public string Intensidad { get; set; } // "baja", "media", "alta"
        public bool Completado { get; set; }
    }
}

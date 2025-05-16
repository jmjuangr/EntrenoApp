namespace EntrenosApp.Models
{
    public class CategoriaEntrenamiento
    {
        public int Id { get; set; }
        public string Tipo { get; set; } // "cardio", "fuerza", etc.
        public string ColorVisual { get; set; }

        public ICollection<Entrenamiento> Entrenamientos { get; set; }
    }


}

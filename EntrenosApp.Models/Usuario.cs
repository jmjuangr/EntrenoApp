namespace EntrenosApp.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public string Genero { get; set; } // "M", "F", "Otro"
        public string Nivel { get; set; }  // "principiante", "intermedio", "avanzado"
        public bool Activo { get; set; }

        public ICollection<Entrenamiento> Entrenamientos { get; set; }
    }
}

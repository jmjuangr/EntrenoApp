namespace EntrenosApp.Models
{
    public class CategoriaEntramiento
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool Activa { get; set; }
        public string ColorVisual { get; set; }

        public ICollection<Entrenamiento> Entrenamientos { get; set; }
    }


}

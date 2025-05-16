namespace EntrenosApp.Models.DTOs
{
    public class UsuarioCreateDTO
    {
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public string Genero { get; set; }
        public string Nivel { get; set; }
        public bool Admin { get; set; }
        public string Pass { get; set; }
    }
}

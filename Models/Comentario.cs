
namespace backend.Models
{
    public class Comentario : UsuarioPublicacion
    {
        public int Id { get; set; }
        public string Contenido { get; set; } = string.Empty;
    }
}
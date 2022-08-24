using System.Text.Json.Serialization;

namespace BibliotecaAPIcodeFirst.Entities
{
    public class Autor
    {
        public int Id { get; set; }
        
        public string Nombre { get; set; }
        [JsonIgnore]
        public List<Libro>? Libros { get; set; }
    }
}

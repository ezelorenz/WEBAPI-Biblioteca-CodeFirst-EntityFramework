using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace BibliotecaAPIcodeFirst.Entities
{
    public class Libro
    {
        public int Id { get; set; }
        
        public string Titulo { get; set; }
        
        public int AutorId { get; set; }
        public virtual Autor oAutor { get; set; }

    }
}

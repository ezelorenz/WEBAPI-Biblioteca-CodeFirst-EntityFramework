using BibliotecaAPIcodeFirst.Context;
using BibliotecaAPIcodeFirst.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaAPIcodeFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibroController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        public LibroController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public ActionResult<List<Libro>> Get()
        {
            var libros = context.Libro.Include(x => x.oAutor).ToList();
            return libros;
        }

        [HttpGet("{id}", Name = "ObtenerLibro")]
        public ActionResult<Libro> Get(int id)
        {
            var libro = context.Libro.Include(x =>x.oAutor).FirstOrDefault(x => x.Id == id);
            if (libro == null)
            {
                NotFound();
            }
            return libro;
        }

        [HttpPost]
        public IActionResult Post([FromBody] Libro libro)
        {
            context.Libro.Add(libro);
            context.SaveChanges();
            return new CreatedAtRouteResult("ObtenerLibro", new { id = libro.Id }, libro);
        }

        [HttpPut("{id}")]
        public ActionResult Put([FromBody] Libro libro, int id)
        {
            if(id != libro.Id)
            {
                BadRequest();
            }
            context.Entry(libro).State = EntityState.Modified;
            context.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult<Libro> Delete(int id)
        {
            var libro = context.Libro.FirstOrDefault(x => x.Id == id);
            if (libro == null)
            {
                NotFound();
            }
            context.Libro.Remove(libro);
            context.SaveChanges();
            return libro;
        }
    }
}

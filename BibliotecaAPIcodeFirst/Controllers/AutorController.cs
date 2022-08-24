using BibliotecaAPIcodeFirst.Context;
using BibliotecaAPIcodeFirst.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BibliotecaAPIcodeFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        public AutorController(ApplicationDbContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Autor>> Get()
        {
            return context.Autor.Include(x => x.Libros).ToList();
        }


        [HttpGet("{id}", Name = "ObtenerAutor") ]
        public ActionResult<Autor> Get(int id)
        {
            var autor = context.Autor.Include(x => x.Libros).FirstOrDefault(x => x.Id == id);
            if (autor == null)
            {
                return NotFound();
            }
            return autor;
        }

        [HttpPost]
        public IActionResult Post([FromBody] Autor autor)
        {
            context.Autor.Add(autor);
            context.SaveChanges();
            return new CreatedAtRouteResult("ObtenerAutor", new { id = autor.Id }, autor);
        }

        [HttpPut("{id}")]
        public ActionResult Put([FromBody] Autor autor, int id)
        {
            if(id != autor.Id)
            {
                return BadRequest();
            }
            context.Entry(autor).State = EntityState.Modified;
            context.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult<Autor> Delete(int id)
        {
            var autor = context.Autor.FirstOrDefault(x => x.Id == id);
            if (autor == null){
                return NotFound();
            }
            context.Entry(autor).State= EntityState.Deleted;
            context.SaveChanges();
            return autor;
        }
    }
}

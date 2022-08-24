using BibliotecaAPIcodeFirst.Entities;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaAPIcodeFirst.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Autor>Autor { get; set; }
        public DbSet<Libro> Libro { get; set; }

    }
}

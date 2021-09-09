using Microsoft.EntityFrameworkCore;
using SistemaBuscador.Entities;

namespace SistemaBuscador
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Usuario> Usuarios { get; set; }
    }
}
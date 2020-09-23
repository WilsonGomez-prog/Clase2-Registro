using Microsoft.EntityFrameworkCore;
using Clase2_Registro.Entidades;

namespace Clase2_Registro.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Actores> Actores { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlite(@"Data Source=DATA\Peliculas.db");
        }
    }
}
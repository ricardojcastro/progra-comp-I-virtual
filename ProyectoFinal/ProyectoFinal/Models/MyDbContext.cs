using Microsoft.EntityFrameworkCore;

namespace ProyectoFinal.Models
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }
        public DbSet<Pelicula> Peliculas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Pelicula>().HasKey(pelicula => pelicula.IdPeliculas);

        }
    }
}

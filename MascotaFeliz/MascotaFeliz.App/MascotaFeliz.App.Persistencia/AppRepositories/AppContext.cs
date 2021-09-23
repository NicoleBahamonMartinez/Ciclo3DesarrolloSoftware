using Microsoft.EntityFrameworkCore;
using MascotaFeliz.App.Dominio;

namespace MascotaFeliz.App.Persistencia
{
    public class AppContext : DbContext
    {
        public DbSet<Usuario> Usuarios {get;set;}
        public DbSet<Dueño> Dueños {get;set;}
        public DbSet<Mascota> Mascotas {get;set;}
        public DbSet<Veterinario> Veterinarios {get;set;}
        public DbSet<VisitaDomiciliaria> VisitasDomiciliarias {get;set;}
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if(!optionsBuilder.IsConfigured)
        {
            optionsBuilder.
            UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog= MascotaFelizData");
        }
    }



    }
}
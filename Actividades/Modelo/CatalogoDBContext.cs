using Microsoft.EntityFrameworkCore;

namespace Actividades.Modelo
{
    public class CatalogoDBContext : DbContext
    {
        public CatalogoDBContext(DbContextOptions<CatalogoDBContext> options) : base(options)
        {
        }
        public DbSet<Persona> Personas { get; set; }
        public DbSet<Clasificacion> Clasificaciones { get; set; }
        public DbSet<Materiale> Materiales { get; set; }
    }
}

using Actividades.Modelo;
using Microsoft.EntityFrameworkCore;

namespace Actividades.Repositorio
{
    public class RepositorioClasificacion : IRepositorioClasificacion
    {
        private readonly CatalogoDBContext _context;

        public RepositorioClasificacion(CatalogoDBContext context)
        {
            _context = context;
        }
        public async Task<Clasificacion> Add(Clasificacion clasificacion)
        {
            await _context.Clasificaciones.AddAsync(clasificacion);
            await _context.SaveChangesAsync();
            return clasificacion;
        }

        public async Task Delete(int id)
        {
            var clasificacion = await _context.Clasificaciones.FindAsync(id);
            if (clasificacion != null)
            {
                _context.Clasificaciones.Remove(clasificacion);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Clasificacion?> Get(int id)
        {
            return await _context.Clasificaciones.FindAsync(id);
        }

        public async Task<List<Clasificacion>> GetAll()
        {
            return await _context.Clasificaciones.ToListAsync();
        }

        public async Task Update(int id, Clasificacion clasificacion)
        {
            var clasificacionactual = await _context.Clasificaciones.FindAsync(id);
            if (clasificacionactual != null)
            {
                clasificacionactual.Nombre = clasificacionactual.Nombre;
                await _context.SaveChangesAsync();
            }
        }
    }
}

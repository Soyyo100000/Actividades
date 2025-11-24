using Actividades.Modelo;
using Microsoft.EntityFrameworkCore;

namespace Actividades.Repositorio
{
    public class RepositorioMateriale : IRepositorioMateriales
    {
        private readonly CatalogoDBContext _context;

        public RepositorioMateriale(CatalogoDBContext context)
        {
            _context = context;
        }
        public async Task<Materiale> Add(Materiale materiales)
        {
            await _context.Materiales.AddAsync(materiales);
            await _context.SaveChangesAsync();
            return materiales;
        }

        public async Task Delete(int id)
        {
            var material = await _context.Materiales.FindAsync(id);
            if (material != null)
            {
                _context.Materiales.Remove(material);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Materiale?> Get(int id)
        {
            return await _context.Materiales.FindAsync(id);
        }

        public async Task<List<Materiale>> GetAll()
        {
            return await _context.Materiales.ToListAsync();
        }

        public async Task Update(int id, Materiale materiales)
        {
            var materialactual = await _context.Materiales.FindAsync(id);
            if (materialactual != null)
            {
                materialactual.Nombre = materialactual.Nombre;
                await _context.SaveChangesAsync();
            }
        }
    }
}

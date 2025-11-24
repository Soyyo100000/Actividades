using Actividades.Modelo;
using Microsoft.EntityFrameworkCore;

namespace Actividades.Repositorio
{
    public class RepositorioPersonas : IRepositorioPersonas
    {
        private readonly CatalogoDBContext _context;

        public RepositorioPersonas(CatalogoDBContext context)
        {
            _context = context;
        }

        public async Task<Persona> Add(Persona persona)
        {
            // Si vienen materiales con Id, enlazarlos con las entidades existentes
            if (persona.Materiales != null && persona.Materiales.Any())
            {
                var ids = persona.Materiales.Select(m => m.Id).ToArray();
                var materiales = await _context.Materiales.Where(m => ids.Contains(m.Id)).ToListAsync();
                persona.Materiales = materiales;
            }

            // Si sólo se proporciona ClasificacionId, EF lo resolverá por la FK
            await _context.Personas.AddAsync(persona);
            await _context.SaveChangesAsync();
            return persona;
        }

        public async Task Delete(int id)
        {
            // Cargar con relaciones por si hay necesidad de manipular la colección
            var persona = await _context.Personas
                .Include(p => p.Materiales)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (persona != null)
            {
                _context.Personas.Remove(persona);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Persona?> Get(int id)
        {
            // Incluir relaciones para que la vista tenga Clasificaciones y Materiales cargados
            return await _context.Personas
                .Include(p => p.Clasificaciones)
                .Include(p => p.Materiales)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<List<Persona>> GetAll()
        {
            // Incluir relaciones para que la lista traiga Clasificaciones y Materiales
            return await _context.Personas
                .Include(p => p.Clasificaciones)
                .Include(p => p.Materiales)
                .ToListAsync();
        }

        public async Task Update(int id, Persona persona)
        {
                // Cargar la entidad actual con las colecciones para actualizar correctamente
            var personaactual = await _context.Personas
                .Include(p => p.Materiales)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (personaactual != null)
            {
                // Propiedades simples
                personaactual.Nombre = persona.Nombre;
                personaactual.Correo = persona.Correo;
                personaactual.Telefono = persona.Telefono;

                // Clasificación (FK)
                personaactual.ClasificacionId = persona.ClasificacionId;

                // Actualizar la relación muchos-a-muchos de materiales
                if (persona.Materiales != null)
                {
                    var ids = persona.Materiales.Select(m => m.Id).ToArray();
                    var materiales = await _context.Materiales.Where(m => ids.Contains(m.Id)).ToListAsync();

                    // Reemplazamos la colección por las entidades traídas
                    personaactual.Materiales.Clear();
                    foreach (var mat in materiales)
                    {
                        personaactual.Materiales.Add(mat);
                    }
                }
                else
                {
                    // Si se envía null explícito, opcionalmente limpiamos la colección
                    // personaactual.Materiales.Clear();
                }

                await _context.SaveChangesAsync();
            }
        }
    }
}

using Actividades.Modelo;

namespace Actividades.Repositorio
{
    public interface IRepositorioPersonas
    {
        Task<List<Persona>> GetAll();
        Task<Persona?> Get(int id);
        Task<Persona> Add(Persona persona);
        Task Update(int id, Persona persona);
        Task Delete(int id);
    }
}

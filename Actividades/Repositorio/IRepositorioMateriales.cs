using Actividades.Modelo;
namespace Actividades.Repositorio
{
    public interface IRepositorioMateriales
    {
        Task<List<Materiale>> GetAll();
        Task<Materiale?> Get(int id);
        Task<Materiale> Add(Materiale materiales);
        Task Update(int id, Materiale materiales);
        Task Delete(int id);
    }
}

namespace Actividades.Modelo
{
    public class Clasificacion
    {
        public int Id { get; set; }
        public string ? Nombre { get; set; }

        virtual public ICollection<Persona>? Personas { get; set; }

    }
}

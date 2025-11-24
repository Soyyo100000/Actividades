using System.ComponentModel.DataAnnotations;

namespace Actividades.Modelo
{
    public class Persona
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre es requerido")]
        [StringLength(100, ErrorMessage = "Máximo 100 caracteres")]
        public string? Nombre { get; set; }
        [Required(ErrorMessage = "El correo es requerido")]
        [EmailAddress(ErrorMessage = "Debe ser un correo válido")]
        [StringLength(100, ErrorMessage = "Máximo 100 caracteres")]
        public string? Correo { get; set; }
        [Required(ErrorMessage = "El teléfono es requerido")]
        [StringLength(10, ErrorMessage = "Máximo 10 caracteres")]
        public string? Telefono { get; set; }

        public int ClasificacionId { get; set; }
        virtual public Clasificacion? Clasificaciones { get; set; }

        virtual public ICollection<Materiale>? Materiales { get; set; }
    }
}

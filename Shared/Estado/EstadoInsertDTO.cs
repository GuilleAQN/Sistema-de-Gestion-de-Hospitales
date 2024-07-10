using System.ComponentModel.DataAnnotations;

namespace Shared.Estado
{
    public class EstadoInsertDTO
    {
        [Required(ErrorMessage = "Nombre es requerido")]
        [MaxLength(30, ErrorMessage = "Nombre no puede ser mayor a 30 carácteres")]
        public string Nombre { get; set; } = null!;
    }
}

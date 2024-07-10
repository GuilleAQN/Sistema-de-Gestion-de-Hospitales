using System.ComponentModel.DataAnnotations;

namespace Shared.Tratamiento
{
    public class TratamientoUpdateDTO
    {
        [Required(ErrorMessage = "Id es requerido")]
        public int IdTratamiento { get; set; }
    }
}

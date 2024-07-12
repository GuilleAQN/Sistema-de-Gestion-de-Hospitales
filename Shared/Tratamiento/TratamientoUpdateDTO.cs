using System.ComponentModel.DataAnnotations;

namespace Sistema_de_Gestion_de_Hospitales.Shared.Tratamiento
{
    public class TratamientoUpdateDTO
    {
        [Required(ErrorMessage = "Id es requerido")]
        public int IdTratamiento { get; set; }
    }
}

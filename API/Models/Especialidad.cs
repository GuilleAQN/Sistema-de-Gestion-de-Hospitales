using System.ComponentModel.DataAnnotations;

namespace API.Models;

public partial class Especialidad
{
    [Key]
    public int IdEspecialidad { get; set; }

    public string Nombre { get; set; } = null!;

    public string Descripcion { get; set; } = null!;
}

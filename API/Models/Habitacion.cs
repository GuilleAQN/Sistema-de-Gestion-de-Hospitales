using System.ComponentModel.DataAnnotations;

namespace API.Models;

public partial class Habitacion
{
    [Key]
    public int IdHabitacion { get; set; }

    public string Numero { get; set; } = null!;

    public int Piso { get; set; }

    public string Tipo { get; set; } = null!;

    public int IdEstado { get; set; }

    public virtual Estado IdEstadoNavigation { get; set; } = null!;
}

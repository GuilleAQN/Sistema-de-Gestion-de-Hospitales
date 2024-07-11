using System.ComponentModel.DataAnnotations;

namespace API.Models;

public partial class Estado
{
    [Key]
    public int IdEstado { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Habitacion> Habitacion { get; set; } = new List<Habitacion>();
}

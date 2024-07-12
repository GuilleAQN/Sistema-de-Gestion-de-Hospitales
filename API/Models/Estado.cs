using System.ComponentModel.DataAnnotations;

namespace Sistema_de_Gestion_de_Hospitales.API.Models;

public partial class Estado
{
    [Key]
    public int IdEstado { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Habitacion> Habitacion { get; set; } = new List<Habitacion>();
}

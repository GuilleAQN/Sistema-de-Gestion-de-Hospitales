using System.ComponentModel.DataAnnotations;

namespace API.Models;

public partial class CategoriasCita
{
    [Key]
    public int IdCategoriaCita { get; set; }

    public string Nombre { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public virtual ICollection<Cita> Cita { get; set; } = new List<Cita>();
}

using System.ComponentModel.DataAnnotations;

namespace Sistema_de_Gestion_de_Hospitales.API.Models;

public partial class Especialidad
{
    [Key]
    public int IdEspecialidad { get; set; }

    public string Nombre { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public virtual ICollection<Doctor> Doctores { get; set; } = new List<Doctor>();
}

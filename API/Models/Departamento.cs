using System.ComponentModel.DataAnnotations;

namespace API.Models;

public partial class Departamento
{
    [Key]
    public int IdDepartamento { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public string? Ubicación { get; set; }

    public string Telefono { get; set; } = null!;

    public virtual ICollection<Doctor> Doctores { get; set; } = new List<Doctor>();

    public virtual ICollection<Enfermera> Enfermeras { get; set; } = new List<Enfermera>();
}

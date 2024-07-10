using System.ComponentModel.DataAnnotations;

namespace API.Models;

public partial class Paciente
{
    [Key]
    public int IdPaciente { get; set; }

    public string Cedula { get; set; } = null!;

    public string NombreCompleto { get; set; } = null!;

    public DateOnly FechaNacimiento { get; set; }

    public string Genero { get; set; } = null!;

    public string? Direccion { get; set; }

    public string Telefono { get; set; } = null!;

    public string? CorreoElectronico { get; set; }

    public virtual ICollection<Cita> Cita { get; set; } = new List<Cita>();

    public virtual ICollection<Diagnostico> Diagnosticos { get; set; } = new List<Diagnostico>();
}

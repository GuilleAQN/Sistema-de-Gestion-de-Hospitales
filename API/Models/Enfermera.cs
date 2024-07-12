using System.ComponentModel.DataAnnotations;

namespace Sistema_de_Gestion_de_Hospitales.API.Models;

public partial class Enfermera
{
    [Key]
    public int IdEnfermera { get; set; }

    public string Cedula { get; set; } = null!;

    public string NombreCompleto { get; set; } = null!;

    public DateOnly FechaContratacion { get; set; }

    public string? Direccion { get; set; }

    public string Telefono { get; set; } = null!;

    public string? CorreoElectronico { get; set; }

    public int IdDepartamento { get; set; }

    public virtual ICollection<Cita> Cita { get; set; } = new List<Cita>();

    public virtual Departamento IdDepartamentoNavigation { get; set; } = null!;
}

using System.ComponentModel.DataAnnotations;

namespace Sistema_de_Gestion_de_Hospitales.API.Models;

public partial class Tratamiento
{
    [Key]
    public int IdTratamiento { get; set; }

    public int? IdDiagnostico { get; set; }

    public int? IdDoctor { get; set; }

    public string Descripcion { get; set; } = null!;

    public DateOnly FechaInicio { get; set; }

    public DateOnly FechaFin { get; set; }

    public virtual Diagnostico? IdDiagnosticoNavigation { get; set; } = null!;

    public virtual Doctor? IdDoctorNavigation { get; set; } = null!;
}

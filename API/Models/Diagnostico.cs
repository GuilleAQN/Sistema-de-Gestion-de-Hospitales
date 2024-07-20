using System.ComponentModel.DataAnnotations;

namespace Sistema_de_Gestion_de_Hospitales.API.Models;

public partial class Diagnostico
{
    [Key]
    public int IdDiagnostico { get; set; }

    public int? IdPaciente { get; set; }

    public int? IdDoctor { get; set; }

    public DateOnly Fecha { get; set; }

    public string Descripcion { get; set; } = null!;

    public virtual Doctor? IdDoctorNavigation { get; set; } = null!;

    public virtual Paciente? IdPacienteNavigation { get; set; } = null!;

    public virtual ICollection<Tratamiento> Tratamientos { get; set; } = new List<Tratamiento>();
}

using System.ComponentModel.DataAnnotations;

namespace Sistema_de_Gestion_de_Hospitales.API.Models;

public partial class Cita
{
    [Key]
    public int IdCita { get; set; }

    public int? IdPaciente { get; set; }

    public int? IdDoctor { get; set; }

    public int? IdEnfermera { get; set; }

    public DateTime Fecha { get; set; }

    public int? IdCategoriaCita { get; set; }

    public string Descripción { get; set; } = null!;

    public virtual CategoriasCita IdCategoriaCitaNavigation { get; set; } = null!;

    public virtual Doctor IdDoctorNavigation { get; set; } = null!;

    public virtual Enfermera IdEnfermeraNavigation { get; set; } = null!;

    public virtual Paciente IdPacienteNavigation { get; set; } = null!;
}

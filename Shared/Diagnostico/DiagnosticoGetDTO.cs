namespace Shared.Diagnostico
{
    public class DiagnosticoGetDTO
    {
        public int IdDiagnostico { get; set; }

        public int IdPaciente { get; set; }

        public string NombrePaciente { get; set; } = null!;

        public int IdDoctor { get; set; }

        public string NombreDoctor { get; set; } = null!;

        public DateOnly Fecha { get; set; }

        public string Descripcion { get; set; } = null!;
    }
}

namespace API.Helper
{
    public class DiagnosticoQueryObject
    {
        public string? IdPaciente { get; set; }

        public string? IdDoctor { get; set; }

        public DateOnly Fecha { get; set; } = DateOnly.MinValue;
    }
}

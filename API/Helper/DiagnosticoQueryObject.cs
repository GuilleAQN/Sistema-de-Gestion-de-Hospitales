namespace API.Helper
{
    public class DiagnosticoQueryObject
    {
        public int IdPaciente { get; set; }

        public int IdDoctor { get; set; }

        public DateOnly Fecha { get; set; }

        public string? OrdenadoPor { get; set; } = null;

        public bool Descendiente { get; set; } = false;

        public int NumeroPagina { get; set; } = 1;

        public int TamanoPagina { get; set; } = 20;
    }
}

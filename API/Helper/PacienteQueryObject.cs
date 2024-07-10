namespace API.Helper
{
    public class PacienteQueryObject
    {
        public string NombreCompleto { get; set; } = null!;

        public DateOnly FechaNacimiento { get; set; }

        public string Genero { get; set; } = null!;

        public string? CorreoElectronico { get; set; }

        public string? OrdenadoPor { get; set; } = null;

        public bool Descendiente { get; set; } = false;

        public int NumeroPagina { get; set; } = 1;
    }
}

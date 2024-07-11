namespace API.Helper
{
    public class PacienteQueryObject
    {
        public string? NombreCompleto { get; set; } = null!;

        public DateOnly FechaNacimiento { get; set; } = DateOnly.MinValue;

        public string? Genero { get; set; } = null!;

        public string? CorreoElectronico { get; set; } = null!;
    }
}

namespace API.Helper
{
    public class EnfermeraQueryObject
    {

        public string? NombreCompleto { get; set; } = null!;

        public DateOnly FechaContratacion { get; set; } = DateOnly.MinValue;

        public string? CorreoElectronico { get; set; } = null!;
    }
}

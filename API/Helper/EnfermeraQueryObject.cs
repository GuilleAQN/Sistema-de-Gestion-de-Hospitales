namespace API.Helper
{
    public class EnfermeraQueryObject
    {

        public string NombreCompleto { get; set; } = null!;

        public DateOnly FechaContratacion { get; set; }

        public string? CorreoElectronico { get; set; }

        public int IdDepartamento { get; set; }

        public string? OrdenadoPor { get; set; } = null;

        public bool Descendiente { get; set; } = false;

        public int NumeroPagina { get; set; } = 1;
    }
}

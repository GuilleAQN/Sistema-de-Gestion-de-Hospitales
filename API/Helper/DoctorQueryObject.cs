namespace API.Helper
{
    public class DoctorQueryObject
    {

        public string NombreCompleto { get; set; } = null!;

        public DateOnly FechaContratacion { get; set; }

        public string? CorreoElectronico { get; set; }

        public string? IdEspecialidad { get; set; }

        public string? IdDepartamento { get; set; }
    }
}

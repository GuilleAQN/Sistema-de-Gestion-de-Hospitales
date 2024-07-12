namespace Sistema_de_Gestion_de_Hospitales.Shared.Tratamiento
{
    public class TratamientoGetDTO
    {
        public int IdTratamiento { get; set; }

        public int IdDiagnostico { get; set; }

        public string DescripcionDiagnostico { get; set; } = null!;

        public int IdDoctor { get; set; }

        public string NombreDoctor { get; set; } = null!;

        public string Descripcion { get; set; } = null!;

        public DateOnly FechaInicio { get; set; }

        public DateOnly FechaFin { get; set; }
    }
}

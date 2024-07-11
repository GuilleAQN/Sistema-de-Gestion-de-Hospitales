namespace API.Helper
{
    public class TratamientoQueryObject
    {
        public string? IdDoctor { get; set; } = null!;

        public DateOnly FechaInicio { get; set; } = DateOnly.MinValue;

        public DateOnly FechaFin { get; set; } = DateOnly.MinValue;
    }
}

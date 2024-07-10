namespace API.Helper
{
    public class TratamientoQueryObject
    {
        public int IdDoctor { get; set; }

        public DateOnly FechaInicio { get; set; }

        public DateOnly FechaFin { get; set; }

        public string? OrdenadoPor { get; set; } = null;

        public bool Descendiente { get; set; } = false;

        public int NumeroPagina { get; set; } = 1;

        public int TamanoPagina { get; set; } = 20;
    }
}

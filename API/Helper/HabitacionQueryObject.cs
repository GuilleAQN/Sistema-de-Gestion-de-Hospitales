namespace API.Helper
{
    public class HabitacionQueryObject
    {
        public int Piso { get; set; }

        public string Tipo { get; set; } = null!;

        public int IdEstado { get; set; }

        public string? OrdenadoPor { get; set; } = null;

        public bool Descendiente { get; set; } = false;

        public int NumeroPagina { get; set; } = 1;

        public int TamanoPagina { get; set; } = 20;
    }
}

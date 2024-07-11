namespace Shared.Habitacion
{
    public class HabitacionGetDTO
    {
        public int IdHabitacion { get; set; }

        public string Numero { get; set; } = null!;

        public int Piso { get; set; }

        public string Tipo { get; set; } = null!;

        public int IdEstado { get; set; }

        public string? NombreEstado { get; set; }
    }
}

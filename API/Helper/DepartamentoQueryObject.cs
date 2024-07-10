namespace API.Helper
{
    public class DepartamentoQueryObject
    {
        public string Nombre { get; set; } = null!;
        
        public string Telefono { get; set; } = null!;

        public string? OrdenadoPor { get; set; } = null;

        public bool Descendiente { get; set; } = false;

        public int NumeroPagina { get; set; } = 1;

        public int TamanoPagina { get; set; } = 20;
    }
}

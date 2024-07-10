using System.ComponentModel.DataAnnotations;

namespace API.Helper
{
    public class CitasQueryObject
    {
        public int IdPaciente { get; set; }

        public int IdDoctor { get; set; }

        public int IdEnfermera { get; set; }

        public DateTime Fecha { get; set; }

        public int IdCategoriaCita { get; set; }

        public string? OrdenadoPor{ get; set; } = null;

        public bool Descendiente { get; set; } = false;

        public int NumeroPagina { get; set; } = 1;
        
        public int TamanoPagina { get; set; } = 20;
    }
}

using System.ComponentModel.DataAnnotations;

namespace API.Helper
{
    public class CitasQueryObject
    {
        public DateTime Fecha { get; set; }
        
        public string? IdPaciente { get; set; } = null!;
        
        public string? IdDoctor { get; set; } = null!;
        
        public string? IdEnfermera { get; set; } = null!;

        public string? IdCategoriaCita { get; set; } = null!;
    }
}

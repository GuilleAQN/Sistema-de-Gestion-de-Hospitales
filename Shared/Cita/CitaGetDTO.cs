namespace Sistema_de_Gestion_de_Hospitales.Shared.Cita
{
    public class CitaGetDTO
    {
        public int IdCita { get; set; }
        public int IdPaciente { get; set; }
        public int IdDoctor { get; set; }
        public int IdEnfermera { get; set; }
        public DateTime Fecha { get; set; }
        public int IdCategoriaCita { get; set; }
        public string Descripcion { get; set; } = null!;
        public string NombrePaciente { get; set; } = null!;
        public string NombreDoctor { get; set; } = null!;
        public string NombreEnfermera { get; set; } = null!;
        public string CategoriaCitaNombre { get; set; } = null!;
    }
}

using Sistema_de_Gestion_de_Hospitales.Shared.Paciente;

namespace Sistema_de_Gestion_de_Hospitales.FrontEnd.Interfaces
{
    public interface IPacientesService
    {
        Task<IEnumerable<PacienteGetDTO>> GetPacientes();
        Task<PacienteGetDTO> GetPaciente(int id);
        Task<HttpResponseMessage> CreatePaciente(PacienteInsertDTO pacienteDto);
        Task<HttpResponseMessage> UpdatePaciente(int id, PacienteUpdateDTO pacienteDto);
        Task<bool> DeletePaciente(int id);
    }
}

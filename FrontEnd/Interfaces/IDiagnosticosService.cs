using Sistema_de_Gestion_de_Hospitales.Shared.Diagnostico;

namespace Sistema_de_Gestion_de_Hospitales.FrontEnd.Interfaces
{
    public interface IDiagnosticosService
    {
        Task<IEnumerable<DiagnosticoGetDTO>> GetDiagnosticos();
        Task<DiagnosticoGetDTO> GetDiagnostico(int id);
        Task<HttpResponseMessage> CreateDiagnostico(DiagnosticoInsertDTO diagnosticoDto);
        Task<HttpResponseMessage> UpdateDiagnostico(int id, DiagnosticoUpdateDTO diagnosticoDto);
        Task<bool> DeleteDiagnostico(int id);
    }
}

using Sistema_de_Gestion_de_Hospitales.Shared.Diagnostico;

namespace Sistema_de_Gestion_de_Hospitales.FrontEnd.Interfaces
{
    public interface IDiagnosticosService
    {
        Task<IEnumerable<DiagnosticoGetDTO>> GetDiagnosticos();
        Task<DiagnosticoGetDTO> GetDiagnostico(int id);
        Task<int> CreateDiagnostico(DiagnosticoInsertDTO diagnosticoDto);
        Task UpdateDiagnostico(int id, DiagnosticoUpdateDTO diagnosticoDto);
        Task DeleteDiagnostico(int id);
    }
}

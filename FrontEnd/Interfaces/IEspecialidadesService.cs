using Sistema_de_Gestion_de_Hospitales.Shared.Especialidad;

namespace Sistema_de_Gestion_de_Hospitales.FrontEnd.Interfaces
{
    public interface IEspecialidadesService
    {
        Task<IEnumerable<EspecialidadGetDTO>> GetEspecialidades();
        Task<EspecialidadGetDTO> GetEspecialidad(int id);
        Task<HttpResponseMessage> CreateEspecialidad(EspecialidadInsertDTO especialidadDto);
        Task<HttpResponseMessage> UpdateEspecialidad(int id, EspecialidadUpdateDTO especialidadDto);
        Task<bool> DeleteEspecialidad(int id);
    }
}

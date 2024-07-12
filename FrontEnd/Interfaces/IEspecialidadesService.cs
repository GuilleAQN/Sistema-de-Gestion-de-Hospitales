using Sistema_de_Gestion_de_Hospitales.Shared.Especialidad;

namespace Sistema_de_Gestion_de_Hospitales.FrontEnd.Interfaces
{
    public interface IEspecialidadesService
    {
        Task<IEnumerable<EspecialidadGetDTO>> GetEspecialidades();
        Task<EspecialidadGetDTO> GetEspecialidad(int id);
        Task<int> CreateEspecialidad(EspecialidadInsertDTO especialidadDto);
        Task UpdateEspecialidad(int id, EspecialidadUpdateDTO especialidadDto);
        Task DeleteEspecialidad(int id);
    }
}

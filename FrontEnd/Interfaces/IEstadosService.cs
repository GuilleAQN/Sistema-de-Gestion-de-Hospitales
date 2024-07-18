using Sistema_de_Gestion_de_Hospitales.Shared.Estado;

namespace Sistema_de_Gestion_de_Hospitales.FrontEnd.Interfaces
{
    public interface IEstadosService
    {
        Task<IEnumerable<EstadoGetDTO>> GetEstados();
        Task<EstadoGetDTO> GetEstado(int id);
        Task<int> CreateEstado(EstadoInsertDTO estadoDto);
        Task<bool> UpdateEstado(int id, EstadoUpdateDTO estadoDto);
        Task<bool> DeleteEstado(int id);
    }
}

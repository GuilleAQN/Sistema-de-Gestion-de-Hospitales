using Sistema_de_Gestion_de_Hospitales.Shared.Estado;

namespace Sistema_de_Gestion_de_Hospitales.FrontEnd.Interfaces
{
    public interface IEstadosService
    {
        Task<IEnumerable<EstadoGetDTO>> GetEstados();
        Task<EstadoGetDTO> GetEstado(int id);
        Task<HttpResponseMessage> CreateEstado(EstadoInsertDTO estadoDto);
        Task<HttpResponseMessage> UpdateEstado(int id, EstadoUpdateDTO estadoDto);
        Task<bool> DeleteEstado(int id);
    }
}

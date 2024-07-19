using Sistema_de_Gestion_de_Hospitales.Shared.Tratamiento;

namespace Sistema_de_Gestion_de_Hospitales.FrontEnd.Interfaces
{
    public interface ITratamientosService
    {
        Task<IEnumerable<TratamientoGetDTO>> GetTratamientos();
        Task<TratamientoGetDTO> GetTratamiento(int id);
        Task<HttpResponseMessage> CreateTratamiento(TratamientoInsertDTO tratamientoDto);
        Task<HttpResponseMessage> UpdateTratamiento(int id, TratamientoUpdateDTO tratamientoDto);
        Task<bool> DeleteTratamiento(int id);
    }
}

using Sistema_de_Gestion_de_Hospitales.Shared.Cita;

namespace Sistema_de_Gestion_de_Hospitales.FrontEnd.Interfaces
{
    public interface ICitasService
    {
        Task<IEnumerable<CitaGetDTO>> GetCitas();
        Task<CitaGetDTO> GetCita(int id);
        Task<int> CreateCita(CitaInsertDTO citaDto);
        Task<bool> UpdateCita(int id, CitaUpdateDTO citaDto);
        Task<bool> DeleteCita(int id);
    }
}

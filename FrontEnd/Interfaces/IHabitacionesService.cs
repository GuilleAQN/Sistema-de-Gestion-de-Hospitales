using Sistema_de_Gestion_de_Hospitales.Shared.Habitacion;

namespace Sistema_de_Gestion_de_Hospitales.FrontEnd.Interfaces
{
    public interface IHabitacionesService
    {
        Task<IEnumerable<HabitacionGetDTO>> GetHabitaciones();
        Task<HabitacionGetDTO> GetHabitacion(int id);
        Task<int> CreateHabitacion(HabitacionInsertDTO habitacionDto);
        Task<bool> UpdateHabitacion(int id, HabitacionUpdateDTO habitacionDto);
        Task<bool> DeleteHabitacion(int id);
    }
}

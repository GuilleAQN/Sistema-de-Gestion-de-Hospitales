using Sistema_de_Gestion_de_Hospitales.Shared.Doctor;

namespace Sistema_de_Gestion_de_Hospitales.FrontEnd.Interfaces
{
    public interface IDoctoresService
    {
        Task<IEnumerable<DoctorGetDTO>> GetDoctores();
        Task<DoctorGetDTO> GetDoctor(int id);
        Task<int> CreateDoctor(DoctorInsertDTO doctorDto);
        Task UpdateDoctor(int id, DoctorUpdateDTO doctorDto);
        Task DeleteDoctor(int id);
    }
}

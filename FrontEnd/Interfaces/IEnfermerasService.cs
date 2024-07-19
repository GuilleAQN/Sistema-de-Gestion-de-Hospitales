using Sistema_de_Gestion_de_Hospitales.Shared.Enfermera;

namespace Sistema_de_Gestion_de_Hospitales.FrontEnd.Interfaces
{
    public interface IEnfermerasService
    {
        Task<IEnumerable<EnfermeraGetDTO>> GetEnfermeras();
        Task<EnfermeraGetDTO> GetEnfermera(int id);
        Task<HttpResponseMessage> CreateEnfermera(EnfermeraInsertDTO enfermeraDto);
        Task<HttpResponseMessage> UpdateEnfermera(int id, EnfermeraUpdateDTO enfermeraDto);
        Task<bool> DeleteEnfermera(int id);
    }
}

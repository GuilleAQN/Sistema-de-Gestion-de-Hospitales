using Sistema_de_Gestion_de_Hospitales.Shared.Departamento;

namespace Sistema_de_Gestion_de_Hospitales.FrontEnd.Interfaces
{
    public interface IDepartamentosService
    {
        Task<IEnumerable<DepartamentoGetDTO>> GetDepartamentos();
        Task<DepartamentoGetDTO> GetDepartamento(int id);
        Task<int> CreateDepartamento(DepartamentoInsertDTO departamentoDto);
        Task<bool> UpdateDepartamento(int id, DepartamentoUpdateDTO departamentoDto);
        Task<bool> DeleteDepartamento(int id);
    }
}

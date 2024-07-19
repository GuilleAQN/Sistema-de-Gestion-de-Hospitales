using Sistema_de_Gestion_de_Hospitales.Shared.CategoriasCita;

namespace Sistema_de_Gestion_de_Hospitales.FrontEnd.Interfaces
{
    public interface ICategoriasCitasService
    {
        Task<IEnumerable<CategoriaCitaGetDTO>> GetCategoriasCitasAsync();
        Task<CategoriaCitaGetDTO> GetCategoriasCitaAsync(int id);
        Task<HttpResponseMessage> UpdateCategoriasCitaAsync(int id, CategoriaCitaUpdateDTO categoriasCitaDto);
        Task<HttpResponseMessage> CreateCategoriasCitaAsync(CategoriaCitaInsertDTO categoriasCitaDto);
        Task<bool> DeleteCategoriasCitaAsync(int id);
    }
}

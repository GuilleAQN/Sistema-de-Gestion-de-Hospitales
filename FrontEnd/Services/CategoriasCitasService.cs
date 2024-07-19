using Sistema_de_Gestion_de_Hospitales.FrontEnd.Interfaces;
using Sistema_de_Gestion_de_Hospitales.Shared.CategoriasCita;
using System.Net.Http.Json;

namespace Sistema_de_Gestion_de_Hospitales.FrontEnd.Services
{
    public class CategoriasCitasService : ICategoriasCitasService
    {
        private readonly HttpClient httpClient;
        private const string BaseUrl = "api/CategoriasCitas";

        public CategoriasCitasService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<CategoriaCitaGetDTO>> GetCategoriasCitasAsync()
        {
            return await httpClient.GetFromJsonAsync<IEnumerable<CategoriaCitaGetDTO>>(BaseUrl);
        }

        public async Task<CategoriaCitaGetDTO> GetCategoriasCitaAsync(int id)
        {
            return await httpClient.GetFromJsonAsync<CategoriaCitaGetDTO>($"{BaseUrl}/{id}");
        }

        public async Task<HttpResponseMessage> UpdateCategoriasCitaAsync(int id, CategoriaCitaUpdateDTO categoriasCitaDto)
        {
            return await httpClient.PutAsJsonAsync($"{BaseUrl}/{id}", categoriasCitaDto);
        }

        public async Task<HttpResponseMessage> CreateCategoriasCitaAsync(CategoriaCitaInsertDTO categoriasCitaDto)
        {
            return await httpClient.PostAsJsonAsync($"{BaseUrl}", categoriasCitaDto);
        }

        public async Task<bool> DeleteCategoriasCitaAsync(int id)
        {
            var response = await httpClient.DeleteAsync($"{BaseUrl}/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}

using Sistema_de_Gestion_de_Hospitales.FrontEnd.Interfaces;
using Sistema_de_Gestion_de_Hospitales.Shared.Departamento;
using System.Net.Http.Json;

namespace Sistema_de_Gestion_de_Hospitales.FrontEnd.Services
{
    public class DepartamentosService : IDepartamentosService
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "https://localhost:44382/api/departamentos"; // Actualiza con tu URL base

        public DepartamentosService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<DepartamentoGetDTO>> GetDepartamentos()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<DepartamentoGetDTO>>(BaseUrl);
        }

        public async Task<DepartamentoGetDTO> GetDepartamento(int id)
        {
            return await _httpClient.GetFromJsonAsync<DepartamentoGetDTO>($"{BaseUrl}/{id}");
        }

        public async Task<int> CreateDepartamento(DepartamentoInsertDTO departamentoDto)
        {
            var response = await _httpClient.PostAsJsonAsync(BaseUrl, departamentoDto);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<int>();
        }

        public async Task UpdateDepartamento(int id, DepartamentoUpdateDTO departamentoDto)
        {
            var response = await _httpClient.PutAsJsonAsync($"{BaseUrl}/{id}", departamentoDto);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteDepartamento(int id)
        {
            var response = await _httpClient.DeleteAsync($"{BaseUrl}/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}

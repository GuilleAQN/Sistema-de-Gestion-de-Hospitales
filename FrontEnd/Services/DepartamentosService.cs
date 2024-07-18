using Sistema_de_Gestion_de_Hospitales.FrontEnd.Interfaces;
using Sistema_de_Gestion_de_Hospitales.Shared.Departamento;
using System.Net.Http;
using System.Net.Http.Json;

namespace Sistema_de_Gestion_de_Hospitales.FrontEnd.Services
{
    public class DepartamentosService : IDepartamentosService
    {
        private readonly HttpClient httpClient;
        private const string BaseUrl = "https://localhost:44382/api/departamentos"; // Actualiza con tu URL base

        public DepartamentosService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<DepartamentoGetDTO>> GetDepartamentos()
        {
            return await httpClient.GetFromJsonAsync<IEnumerable<DepartamentoGetDTO>>(BaseUrl);
        }

        public async Task<DepartamentoGetDTO> GetDepartamento(int id)
        {
            return await httpClient.GetFromJsonAsync<DepartamentoGetDTO>($"{BaseUrl}/{id}");
        }

        public async Task<int> CreateDepartamento(DepartamentoInsertDTO departamentoDto)
        {
            var response = await httpClient.PostAsJsonAsync(BaseUrl, departamentoDto);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<int>();

        }

        public async Task<bool> UpdateDepartamento(int id, DepartamentoUpdateDTO departamentoDto)
        {
            var response = await httpClient.PutAsJsonAsync($"{BaseUrl}/{id}", departamentoDto);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteDepartamento(int id)
        {
            var response = await httpClient.DeleteAsync($"{BaseUrl}/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}

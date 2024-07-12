using Sistema_de_Gestion_de_Hospitales.FrontEnd.Interfaces;
using Sistema_de_Gestion_de_Hospitales.Shared.Diagnostico;
using System.Net.Http.Json;

namespace Sistema_de_Gestion_de_Hospitales.FrontEnd.Services
{
    public class DiagnosticosService : IDiagnosticosService
    {
        private readonly HttpClient httpClient;
        private const string BaseUrl = "api/Departamentos";

        public DiagnosticosService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<DiagnosticoGetDTO>> GetDiagnosticos()
        {
            return await httpClient.GetFromJsonAsync<IEnumerable<DiagnosticoGetDTO>>(BaseUrl);
        }

        public async Task<DiagnosticoGetDTO> GetDiagnostico(int id)
        {
            return await httpClient.GetFromJsonAsync<DiagnosticoGetDTO>($"{BaseUrl}/{id}");
        }

        public async Task<int> CreateDiagnostico(DiagnosticoInsertDTO diagnosticoDto)
        {
            var response = await httpClient.PostAsJsonAsync(BaseUrl, diagnosticoDto);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<int>();
        }

        public async Task UpdateDiagnostico(int id, DiagnosticoUpdateDTO diagnosticoDto)
        {
            var response = await httpClient.PutAsJsonAsync($"{BaseUrl}/{id}", diagnosticoDto);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteDiagnostico(int id)
        {
            var response = await httpClient.DeleteAsync($"{BaseUrl}/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}

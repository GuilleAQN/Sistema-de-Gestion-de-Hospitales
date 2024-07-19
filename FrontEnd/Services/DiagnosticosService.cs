using Sistema_de_Gestion_de_Hospitales.FrontEnd.Interfaces;
using Sistema_de_Gestion_de_Hospitales.Shared.Diagnostico;
using System.Net.Http.Json;

namespace Sistema_de_Gestion_de_Hospitales.FrontEnd.Services
{
    public class DiagnosticosService : IDiagnosticosService
    {
        private readonly HttpClient httpClient;
        private const string BaseUrl = "api/Diagnosticos";

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

        public async Task<HttpResponseMessage> CreateDiagnostico(DiagnosticoInsertDTO diagnosticoDto)
        {
            return await httpClient.PostAsJsonAsync(BaseUrl, diagnosticoDto);
        }

        public async Task<HttpResponseMessage> UpdateDiagnostico(int id, DiagnosticoUpdateDTO diagnosticoDto)
        {
            return await httpClient.PutAsJsonAsync($"{BaseUrl}/{id}", diagnosticoDto);
        }

        public async Task<bool> DeleteDiagnostico(int id)
        {
            var response = await httpClient.DeleteAsync($"{BaseUrl}/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
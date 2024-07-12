using Sistema_de_Gestion_de_Hospitales.FrontEnd.Interfaces;
using Sistema_de_Gestion_de_Hospitales.Shared.Estado;
using System.Net.Http.Json;

namespace Sistema_de_Gestion_de_Hospitales.FrontEnd.Services
{
    public class EstadosService : IEstadosService
    {
        private readonly HttpClient httpClient;
        private const string BaseUrl = "api/Estados";

        public EstadosService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<EstadoGetDTO>> GetEstados()
        {
            return await httpClient.GetFromJsonAsync<IEnumerable<EstadoGetDTO>>(BaseUrl);
        }

        public async Task<EstadoGetDTO> GetEstado(int id)
        {
            return await httpClient.GetFromJsonAsync<EstadoGetDTO>($"{BaseUrl}/{id}");
        }

        public async Task<int> CreateEstado(EstadoInsertDTO estadoDto)
        {
            var response = await httpClient.PostAsJsonAsync(BaseUrl, estadoDto);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<int>();
        }

        public async Task UpdateEstado(int id, EstadoUpdateDTO estadoDto)
        {
            var response = await httpClient.PutAsJsonAsync($"{BaseUrl}/{id}", estadoDto);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteEstado(int id)
        {
            var response = await httpClient.DeleteAsync($"{BaseUrl}/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}

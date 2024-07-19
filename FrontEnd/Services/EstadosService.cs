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

        public async Task<HttpResponseMessage> CreateEstado(EstadoInsertDTO estadoDto)
        {
            return await httpClient.PostAsJsonAsync(BaseUrl, estadoDto);
        }

        public async Task<HttpResponseMessage> UpdateEstado(int id, EstadoUpdateDTO estadoDto)
        {
            return await httpClient.PutAsJsonAsync($"{BaseUrl}/{id}", estadoDto);
        }

        public async Task<bool> DeleteEstado(int id)
        {
            var response = await httpClient.DeleteAsync($"{BaseUrl}/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}

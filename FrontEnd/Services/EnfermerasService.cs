using Sistema_de_Gestion_de_Hospitales.FrontEnd.Interfaces;
using Sistema_de_Gestion_de_Hospitales.Shared.Enfermera;
using System.Net.Http.Json;

namespace Sistema_de_Gestion_de_Hospitales.FrontEnd.Services
{
    public class EnfermerasService : IEnfermerasService
    {
        private readonly HttpClient httpClient;
        private const string BaseUrl = "api/Enfermeras";

        public EnfermerasService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<EnfermeraGetDTO>> GetEnfermeras()
        {
            return await httpClient.GetFromJsonAsync<IEnumerable<EnfermeraGetDTO>>(BaseUrl);
        }

        public async Task<EnfermeraGetDTO> GetEnfermera(int id)
        {
            return await httpClient.GetFromJsonAsync<EnfermeraGetDTO>($"{BaseUrl}/{id}");
        }

        public async Task<HttpResponseMessage> CreateEnfermera(EnfermeraInsertDTO enfermeraDto)
        {
            return await httpClient.PostAsJsonAsync(BaseUrl, enfermeraDto);
        }

        public async Task<HttpResponseMessage> UpdateEnfermera(int id, EnfermeraUpdateDTO enfermeraDto)
        {
            return await httpClient.PutAsJsonAsync($"{BaseUrl}/{id}", enfermeraDto);
        }

        public async Task<bool> DeleteEnfermera(int id)
        {
            var response = await httpClient.DeleteAsync($"{BaseUrl}/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}

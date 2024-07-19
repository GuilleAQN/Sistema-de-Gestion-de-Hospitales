using Sistema_de_Gestion_de_Hospitales.FrontEnd.Interfaces;
using Sistema_de_Gestion_de_Hospitales.Shared.Cita;
using System.Net.Http.Json;

namespace Sistema_de_Gestion_de_Hospitales.FrontEnd.Services
{
    public class CitasService : ICitasService
    {
        private readonly HttpClient httpClient;
        private const string BaseUrl = "api/Citas";

        public CitasService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<CitaGetDTO>> GetCitas()
        {
            return await httpClient.GetFromJsonAsync<IEnumerable<CitaGetDTO>>(BaseUrl);
        }

        public async Task<CitaGetDTO> GetCita(int id)
        {
            return await httpClient.GetFromJsonAsync<CitaGetDTO>($"{BaseUrl}/{id}");
        }

        public async Task<HttpResponseMessage> CreateCita(CitaInsertDTO citaDto)
        {
            return await httpClient.PostAsJsonAsync(BaseUrl, citaDto);
        }

        public async Task<HttpResponseMessage> UpdateCita(int id, CitaUpdateDTO citaDto)
        {
            return await httpClient.PutAsJsonAsync($"{BaseUrl}/{id}", citaDto);
        }

        public async Task<bool> DeleteCita(int id)
        {
            var response = await httpClient.DeleteAsync($"{BaseUrl}/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}

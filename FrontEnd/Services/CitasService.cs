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

        public async Task<int> CreateCita(CitaInsertDTO citaDto)
        {
            var response = await httpClient.PostAsJsonAsync(BaseUrl, citaDto);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<int>();
        }

        public async Task UpdateCita(int id, CitaUpdateDTO citaDto)
        {
            var response = await httpClient.PutAsJsonAsync($"{BaseUrl}/{id}", citaDto);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteCita(int id)
        {
            var response = await httpClient.DeleteAsync($"{BaseUrl}/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}

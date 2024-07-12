using Sistema_de_Gestion_de_Hospitales.FrontEnd.Interfaces;
using Sistema_de_Gestion_de_Hospitales.Shared.Habitacion;
using System.Net.Http.Json;

namespace Sistema_de_Gestion_de_Hospitales.FrontEnd.Services
{
    public class HabitacionesService : IHabitacionesService
    {
        private readonly HttpClient httpClient;
        private const string BaseUrl = "api/Habitaciones";

        public HabitacionesService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<HabitacionGetDTO>> GetHabitaciones()
        {
            return await httpClient.GetFromJsonAsync<IEnumerable<HabitacionGetDTO>>(BaseUrl);
        }

        public async Task<HabitacionGetDTO> GetHabitacion(int id)
        {
            return await httpClient.GetFromJsonAsync<HabitacionGetDTO>($"{BaseUrl}/{id}");
        }

        public async Task<int> CreateHabitacion(HabitacionInsertDTO habitacionDto)
        {
            var response = await httpClient.PostAsJsonAsync(BaseUrl, habitacionDto);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<int>();
        }

        public async Task UpdateHabitacion(int id, HabitacionUpdateDTO habitacionDto)
        {
            var response = await httpClient.PutAsJsonAsync($"{BaseUrl}/{id}", habitacionDto);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteHabitacion(int id)
        {
            var response = await httpClient.DeleteAsync($"{BaseUrl}/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}

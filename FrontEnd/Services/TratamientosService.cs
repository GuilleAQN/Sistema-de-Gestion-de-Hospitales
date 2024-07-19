using Sistema_de_Gestion_de_Hospitales.FrontEnd.Interfaces;
using Sistema_de_Gestion_de_Hospitales.Shared.Tratamiento;
using System.Net.Http.Json;

namespace Sistema_de_Gestion_de_Hospitales.FrontEnd.Services
{
    public class TratamientosService : ITratamientosService
    {
        private readonly HttpClient httpClient;
        private const string BaseUrl = "api/Tratamientos";

        public TratamientosService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<TratamientoGetDTO>> GetTratamientos()
        {
            return await httpClient.GetFromJsonAsync<IEnumerable<TratamientoGetDTO>>(BaseUrl);
        }

        public async Task<TratamientoGetDTO> GetTratamiento(int id)
        {
            return await httpClient.GetFromJsonAsync<TratamientoGetDTO>($"{BaseUrl}/{id}");
        }

        public async Task<HttpResponseMessage> CreateTratamiento(TratamientoInsertDTO tratamientoDto)
        {
            return await httpClient.PostAsJsonAsync(BaseUrl, tratamientoDto);
        }

        public async Task<HttpResponseMessage> UpdateTratamiento(int id, TratamientoUpdateDTO tratamientoDto)
        {
            return await httpClient.PutAsJsonAsync($"{BaseUrl}/{id}", tratamientoDto);
        }

        public async Task<bool> DeleteTratamiento(int id)
        {
            var response = await httpClient.DeleteAsync($"{BaseUrl}/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}

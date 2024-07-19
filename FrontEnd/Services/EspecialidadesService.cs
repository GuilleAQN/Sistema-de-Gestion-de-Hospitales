using Sistema_de_Gestion_de_Hospitales.FrontEnd.Interfaces;
using Sistema_de_Gestion_de_Hospitales.Shared.Especialidad;
using System.Net.Http.Json;

namespace Sistema_de_Gestion_de_Hospitales.FrontEnd.Services
{
    public class EspecialidadesService : IEspecialidadesService
    {
        private readonly HttpClient httpClient;
        private const string BaseUrl = "api/Especialidades";

        public EspecialidadesService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<EspecialidadGetDTO>> GetEspecialidades()
        {
            return await httpClient.GetFromJsonAsync<IEnumerable<EspecialidadGetDTO>>(BaseUrl);
        }

        public async Task<EspecialidadGetDTO> GetEspecialidad(int id)
        {
            return await httpClient.GetFromJsonAsync<EspecialidadGetDTO>($"{BaseUrl}/{id}");
        }

        public async Task<HttpResponseMessage> CreateEspecialidad(EspecialidadInsertDTO especialidadDto)
        {
            return await httpClient.PostAsJsonAsync(BaseUrl, especialidadDto);
        }

        public async Task<HttpResponseMessage> UpdateEspecialidad(int id, EspecialidadUpdateDTO especialidadDto)
        {
            return await httpClient.PutAsJsonAsync($"{BaseUrl}/{id}", especialidadDto);
        }

        public async Task<bool> DeleteEspecialidad(int id)
        {
            var response = await httpClient.DeleteAsync($"{BaseUrl}/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}

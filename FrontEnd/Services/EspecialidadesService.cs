using Sistema_de_Gestion_de_Hospitales.FrontEnd.Interfaces;
using Sistema_de_Gestion_de_Hospitales.Shared.Enfermera;
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

        public async Task<int> CreateEspecialidad(EspecialidadInsertDTO especialidadDto)
        {
            var response = await httpClient.PostAsJsonAsync(BaseUrl, especialidadDto);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<int>();
        }

        public async Task<bool> UpdateEspecialidad(int id, EspecialidadUpdateDTO especialidadDto)
        {
            var response = await httpClient.PutAsJsonAsync($"{BaseUrl}/{id}", especialidadDto);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteEspecialidad(int id)
        {
            var response = await httpClient.DeleteAsync($"{BaseUrl}/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}

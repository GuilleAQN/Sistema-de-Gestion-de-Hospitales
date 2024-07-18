using Sistema_de_Gestion_de_Hospitales.FrontEnd.Interfaces;
using Sistema_de_Gestion_de_Hospitales.Shared.Paciente;
using Sistema_de_Gestion_de_Hospitales.Shared.Tratamiento;
using System.Net.Http.Json;

namespace Sistema_de_Gestion_de_Hospitales.FrontEnd.Services
{
    public class PacientesService : IPacientesService
    {
        private readonly HttpClient httpClient;
        private const string BaseUrl = "api/Pacientes";

        public PacientesService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<PacienteGetDTO>> GetPacientes()
        {
            return await httpClient.GetFromJsonAsync<IEnumerable<PacienteGetDTO>>(BaseUrl);
        }

        public async Task<PacienteGetDTO> GetPaciente(int id)
        {
            return await httpClient.GetFromJsonAsync<PacienteGetDTO>($"{BaseUrl}/{id}");
        }

        public async Task<int> CreatePaciente(PacienteInsertDTO pacienteDto)
        {
            var response = await httpClient.PostAsJsonAsync(BaseUrl, pacienteDto);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<int>();
        }

        public async Task<bool> UpdatePaciente(int id, PacienteUpdateDTO pacienteDto)
        {
            var response = await httpClient.PutAsJsonAsync($"{BaseUrl}/{id}", pacienteDto);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeletePaciente(int id)
        {
            var response = await httpClient.DeleteAsync($"{BaseUrl}/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}

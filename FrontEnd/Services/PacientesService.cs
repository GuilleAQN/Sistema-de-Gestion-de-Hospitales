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

        public async Task<HttpResponseMessage> CreatePaciente(PacienteInsertDTO pacienteDto)
        {
            return await httpClient.PostAsJsonAsync(BaseUrl, pacienteDto);
        }

        public async Task<HttpResponseMessage> UpdatePaciente(int id, PacienteUpdateDTO pacienteDto)
        {
            return await httpClient.PutAsJsonAsync($"{BaseUrl}/{id}", pacienteDto);
        }

        public async Task<bool> DeletePaciente(int id)
        {
            var response = await httpClient.DeleteAsync($"{BaseUrl}/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}

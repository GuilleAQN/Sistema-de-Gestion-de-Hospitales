using Sistema_de_Gestion_de_Hospitales.FrontEnd.Interfaces;
using Sistema_de_Gestion_de_Hospitales.Shared.Doctor;
using System.Net.Http.Json;

namespace Sistema_de_Gestion_de_Hospitales.FrontEnd.Services
{
    public class DoctoresService : IDoctoresService
    {
        private readonly HttpClient httpClient;
        private const string BaseUrl = "api/Doctores";

        public DoctoresService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<DoctorGetDTO>> GetDoctores()
        {
            return await httpClient.GetFromJsonAsync<IEnumerable<DoctorGetDTO>>(BaseUrl);
        }

        public async Task<DoctorGetDTO> GetDoctor(int id)
        {
            return await httpClient.GetFromJsonAsync<DoctorGetDTO>($"{BaseUrl}/{id}");
        }

        public async Task<int> CreateDoctor(DoctorInsertDTO doctorDto)
        {
            var response = await httpClient.PostAsJsonAsync($"{BaseUrl}", doctorDto);
            if (response.IsSuccessStatusCode)
            {
                var id = await response.Content.ReadFromJsonAsync<int>();
                return id;
            }

            return 0;
        }

        public async Task<bool> UpdateDoctor(int id, DoctorUpdateDTO doctorDto)
        {
            var response = await httpClient.PutAsJsonAsync($"{BaseUrl}/{id}", doctorDto);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteDoctor(int id)
        {
            var response = await httpClient.DeleteAsync($"{BaseUrl}/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}

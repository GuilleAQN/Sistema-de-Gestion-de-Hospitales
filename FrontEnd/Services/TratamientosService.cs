﻿using Sistema_de_Gestion_de_Hospitales.FrontEnd.Interfaces;
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

        public async Task<int> CreateTratamiento(TratamientoInsertDTO tratamientoDto)
        {
            var response = await httpClient.PostAsJsonAsync(BaseUrl, tratamientoDto);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<int>();
        }

        public async Task UpdateTratamiento(int id, TratamientoUpdateDTO tratamientoDto)
        {
            var response = await httpClient.PutAsJsonAsync($"{BaseUrl}/{id}", tratamientoDto);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteTratamiento(int id)
        {
            var response = await httpClient.DeleteAsync($"{BaseUrl}/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}
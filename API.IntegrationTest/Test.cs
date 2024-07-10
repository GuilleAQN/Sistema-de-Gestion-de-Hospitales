using System.Net;
using System.Text;
using System.Text.Json;

namespace API.IntegrationTest
{
    public class Tests
    {
        private HttpClient _client;

        [SetUp]
        public void ConfigurarClienteHttp()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("http://localhost:5432"); // Obtener la URL base de una variable de entorno
        }

        [Test]
        public async Task AgregarCategoriaCita_DeberiaAgregarCorrectamente()
        {
            var nuevaCategoriaCita = new 
            { 
                Nombre = "Categoria 1", 
                Descripcion = "Descripcion 1" 
            };

            var json = JsonSerializer.Serialize(nuevaCategoriaCita);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync("/api/CategoriasCitas", content);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [TearDown]
        public void Teardown()
        {
            _client.Dispose();
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using Sistema_de_Gestion_de_Hospitales.API.Controller;
using Sistema_de_Gestion_de_Hospitales.API.Models;
using Sistema_de_Gestion_de_Hospitales.API.Data;
using API.UnitTest;

namespace Sistema_de_Gestion_de_Hospitales.API.UnitTest
{
    public class PacienteControllerTest
    {
        private PacientesController _controller;
        private DbTestFixture<SistemaHospitalDbContext> _fixture;

        public PacienteControllerTest()
        {
            _fixture = new DbTestFixture<SistemaHospitalDbContext>();
            _controller = new PacientesController(_fixture.Context, _fixture.Mapper);
        }

        [Fact]
        public void Setup()
        {
            SeedDataTest.SeedData(_fixture.Context);
        }

        [Fact]
        public async Task GetPacientes_ReturnsOkResult()
        {
            Setup();

            // Act
            var result = await _controller.GetPacientes();

            // Assert
            Assert.IsType<OkObjectResult>(result.Result);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using API.Controller;
using API.Models;
using API.Data;

namespace API.UnitTest
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
        public async Task GetPacientes_ReturnsOkResult()
        {
            // Act
            var result = await _controller.GetPacientes();

            // Assert
            Assert.IsType<OkObjectResult>(result.Result);
        }
    }
}

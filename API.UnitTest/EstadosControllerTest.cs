using Microsoft.AspNetCore.Mvc;
using API.Controller;
using Shared.Estado;
using API.Data;

namespace API.UnitTest
{
    public class EstadosControllerTest
    {
        private EstadosController _controller;
        private DbTestFixture<SistemaHospitalDbContext> _fixture;

        public EstadosControllerTest()
        {
            _fixture = new DbTestFixture<SistemaHospitalDbContext>();
            _controller = new EstadosController(_fixture.Context, _fixture.Mapper);
        }

        [Fact]
        public async Task GetEstados_ReturnsOkResult()
        {
            // Act
            var result = await _controller.GetEstados();

            // Assert
            Assert.IsType<OkObjectResult>(result.Result);
        }
    }
}

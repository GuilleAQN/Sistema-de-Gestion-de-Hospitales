using Microsoft.AspNetCore.Mvc;
using API.Controller;
using API.Models;
using API.Data;

namespace API.UnitTest
{
    public class TratamientosControllerTest
    {
        private TratamientosController _controller;
        private DbTestFixture<SistemaHospitalDbContext> _fixture;

        public TratamientosControllerTest()
        {
            _fixture = new DbTestFixture<SistemaHospitalDbContext>();
            _controller = new TratamientosController(_fixture.Context, _fixture.Mapper);
        }

        [Fact]
        public async Task GetTratamientos_ReturnsOkResult()
        {
            // Act
            var result = await _controller.GetTratamientos();

            // Assert
            Assert.IsType<OkObjectResult>(result.Result);
        }
    }
}

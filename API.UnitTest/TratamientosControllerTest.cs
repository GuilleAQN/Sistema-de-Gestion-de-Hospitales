using Microsoft.AspNetCore.Mvc;
using Sistema_de_Gestion_de_Hospitales.API.Controller;
using Sistema_de_Gestion_de_Hospitales.API.Data;
using API.UnitTest;
using Sistema_de_Gestion_de_Hospitales.Shared.Tratamiento;

namespace Sistema_de_Gestion_de_Hospitales.API.UnitTest
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
        public void Setup()
        {
            SeedDataTest.SeedData(_fixture.Context);
        }

        [Fact]
        public async Task GetTratamientos_ReturnsOkResult()
        {
            Setup();
            // Act
            var result = await _controller.GetTratamientos();

            // Assert
            Assert.IsType<OkObjectResult>(result.Result);

            var okResult = result.Result as OkObjectResult;
            
            var tratamientos = okResult.Value as IEnumerable<TratamientoGetDTO>;
            Assert.NotNull(tratamientos);

            Assert.Equal(2, tratamientos.Count());
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Sistema_de_Gestion_de_Hospitales.API.Controller;
using Sistema_de_Gestion_de_Hospitales.Shared.Enfermera;
using Sistema_de_Gestion_de_Hospitales.API.Models;
using Sistema_de_Gestion_de_Hospitales.API.Data;
using API.UnitTest;

namespace Sistema_de_Gestion_de_Hospitales.API.UnitTest
{
    public class EnfermerasControllerTest
    {
        private EnfermerasController _controller;
        private DbTestFixture<SistemaHospitalDbContext> _fixture;

        public EnfermerasControllerTest()
        {
            _fixture = new DbTestFixture<SistemaHospitalDbContext>();
            _controller = new EnfermerasController(_fixture.Context, _fixture.Mapper);
        }

        [Fact]
        public void Setup()
        {
            SeedDataTest.SeedData(_fixture.Context);
        }

        [Fact]
        public async Task GetEnfermeras_ReturnsOkResult()
        {
            // Arrange
            Setup();

            // Act
            var result = await _controller.GetEnfermeras();

            // Assert
            Assert.IsType<OkObjectResult>(result.Result);

            // Verificar que el valor devuelto no es nulo
            Assert.NotNull(result.Result);

            // Verificar los datos devueltos
            var okResult = result.Result as OkObjectResult;
            Assert.NotNull(okResult);

            var enfermeras = okResult.Value as IEnumerable<EnfermeraGetDTO>;
            Assert.NotNull(enfermeras);

            Assert.Equal(2, enfermeras.Count()); // Verificar que se devuelvan todas las enfermeras
        }

        [Fact]
        public async Task PostEnfermera_ReturnsOkResult_WithValidData()
        {
            // Arrange
            Setup();
            var newEnfermeraDto = new EnfermeraInsertDTO
            {
                Cedula = "11298765432",
                NombreCompleto = "Dra. María González",
                FechaContratacion = new DateOnly(2021, 5, 10),
                Direccion = "Avenida Central 456",
                Telefono = "987-654-3210",
                CorreoElectronico = "maria.gonzalez@example.com",
                IdDepartamento = 2
            };

            // Act
            var result = await _controller.PostEnfermera(newEnfermeraDto);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            Assert.IsType<int>(okResult.Value);
        }

        [Fact]
        public async Task DeleteEnfermera_ReturnsNoContent_WithValidId()
        {
            // Act
            Setup();
            var result = await _controller.DeleteEnfermera(1);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }
    }
}

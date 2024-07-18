using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema_de_Gestion_de_Hospitales.API.Controller;
using Sistema_de_Gestion_de_Hospitales.Shared.Departamento;
using Sistema_de_Gestion_de_Hospitales.API.Models;
using Sistema_de_Gestion_de_Hospitales.API.Data;
using API.UnitTest;

namespace Sistema_de_Gestion_de_Hospitales.API.UnitTest
{
    public class DepartamentoControllerTest
    {
        private DepartamentosController _controller;
        private DbTestFixture<SistemaHospitalDbContext> _fixture;

        public DepartamentoControllerTest()
        {
            _fixture = new DbTestFixture<SistemaHospitalDbContext>();
            _controller = new DepartamentosController(_fixture.Context, _fixture.Mapper);
        }

        [Fact]
        public void Setup()
        {
            SeedDataTest.SeedData(_fixture.Context);
        }

        [Fact]
        public async Task GetDepartamentos_ReturnsOkResult()
        {
            // Arrange
            Setup();

            // Act
            var result = await _controller.GetDepartamentos();

            // Assert
            Assert.IsType<OkObjectResult>(result.Result);

            // Verificar que el valor devuelto no es nulo
            Assert.NotNull(result.Result);

            // Verificar los datos devueltos
            var okResult = result.Result as OkObjectResult;
            Assert.NotNull(okResult);

            var departamentos = okResult.Value as IEnumerable<DepartamentoGetDTO>;
            Assert.NotNull(departamentos);

            Assert.Equal(2, departamentos.Count()); // Verificar que se devuelvan todas las habitaciones
        }

        [Fact]
        public async Task GetDepartamento_ReturnsOkResult_WithValidId()
        {
            // Arrange
            Setup();
            var departamento = new Departamento
            {
                IdDepartamento = 2,
                Nombre = "Cardiología",
                Descripcion = "Departamento de Cardiología",
                Ubicación = "Edificio A, Planta 2",
                Telefono = "555-1234"
            };

            // Act
            var result = await _controller.GetDepartamento(2);

            // Assert
            var departamentoDto = Assert.IsType<DepartamentoGetDTO>(result.Value);
            Assert.Equal(departamento.IdDepartamento, departamentoDto.IdDepartamento);
        }

        [Fact]
        public async Task PostDepartamentos_ReturnsOkResult_WithValidData()
        {
            // Arrange
            Setup();
            var departamentoDto = new DepartamentoInsertDTO
            {
                Nombre = "Cardiología",
                Descripcion = "Departamento de Cardiología",
                Ubicación = "Edificio A, Planta 2",
                Telefono = "555-1234"
            };

            // Act
            var result = await _controller.PostDepartamento(departamentoDto);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            Assert.IsType<int>(okResult.Value);
        }

        [Fact]
        public async Task PutDepartamento_ReturnsNoContent_WithValidId()
        {
            // Arrange
            Setup();
            var departamentoDto = new DepartamentoInsertDTO
            {
                Nombre = "El mejorlogia",
                Descripcion = "Departamento de Cardiología",
                Ubicación = "Edificio A, Planta 2",
                Telefono = "555-1234"
            };

            await _controller.PostDepartamento(departamentoDto);

            // Desatachar la entidad que se acaba de insertar para evitar conflictos
            var insertedDepartamento = _fixture.Context.Departamentos.Local.FirstOrDefault(h => h.IdDepartamento == 3);
            if (insertedDepartamento != null)
            {
                _fixture.Context.Entry(insertedDepartamento).State = EntityState.Detached;
            }

            var departamentoUpdateDto = new DepartamentoUpdateDTO
            {
                IdDepartamento = 3,
                Nombre = "Tontologia",
                Descripcion = "Departamento de Tontologia",
                Ubicación = "Edificio A, Planta 2",
                Telefono = "555-1234"
            };

            // Act
            var result = await _controller.PutDepartamento(3, departamentoUpdateDto);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }


        [Fact]
        public async Task DeleteDepartamento_ReturnsNoContent_WithValidId()
        {
            // Act
            Setup();
            var result = await _controller.DeleteDepartamento(1);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }
    }
}

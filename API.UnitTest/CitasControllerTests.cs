using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema_de_Gestion_de_Hospitales.API.Controller;
using Sistema_de_Gestion_de_Hospitales.Shared.Cita;
using Sistema_de_Gestion_de_Hospitales.API.Models;
using Sistema_de_Gestion_de_Hospitales.API.Data;
using AutoMapper;
using Sistema_de_Gestion_de_Hospitales.API.Mapping;
using Xunit.Abstractions;
using API.UnitTest;

namespace Sistema_de_Gestion_de_Hospitales.API.UnitTest
{
    public class CitasControllerTests
    {
        private CitasController _controller;
        private DbTestFixture<SistemaHospitalDbContext> _fixture;
        private readonly ITestOutputHelper output;

        public CitasControllerTests()
        {
            this.output = output;
            _fixture = new DbTestFixture<SistemaHospitalDbContext>();
            _controller = new CitasController(_fixture.Context, _fixture.Mapper);
        }

        [Fact]
        public void Setup()
        {
            SeedDataTest.SeedData(_fixture.Context);
        }

        [Fact]
        public async Task GetCitas_ReturnsOkResult()
        {
            Setup();

            // Act
            var result = await _controller.GetCitas();

            // Assert
            Assert.IsType<OkObjectResult>(result.Result);

            // Verificar que el valor devuelto no es nulo
            Assert.NotNull(result.Result);

            // Verificar los datos devueltos
            var okResult = result.Result as OkObjectResult;
            Assert.NotNull(okResult);

            var cita = okResult.Value as IEnumerable<CitaGetDTO>;
            Assert.NotNull(cita);

            Assert.Equal(2, cita.Count()); // Verificar que se devuelvan todas las habitaciones
        }

        [Fact]
        public async Task GetCita_ReturnsOkResult_WithValidId()
        {
            Setup();
            var cita = new Cita
            {
                IdCita = 2,
                IdPaciente = 1,
                IdDoctor = 1,
                IdEnfermera = 1,
                Fecha = DateTime.Now,
                IdCategoriaCita = 1,
                Descripción = "Revisión general",
            };

            // Act
            var result = await _controller.GetCita(2);

            // Assert
            var citaDto = Assert.IsType<CitaGetDTO>(result.Value);
            
            Assert.Equal(cita.IdCita, citaDto.IdCita);
        }

        [Fact]
        public async Task PostCitas_ReturnsOkResult_WithValidData()
        {
            var citaDto = new CitaInsertDTO
            {
                IdPaciente = 1,
                IdDoctor = 1,
                IdEnfermera = 1,
                Fecha = DateTime.Now,
                IdCategoriaCita = 1,
                Descripción = "Revisión general",
            };

            // Act
            var result = await _controller.PostCita(citaDto);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            Assert.IsType<int>(okResult.Value);
        }

        [Fact]
        public async Task PutCitas_ReturnsNoContent_WithValidId()
        {
            // Arrange
            Setup();
            var citaDto = new CitaInsertDTO
            {
                IdPaciente = 1,
                IdDoctor = 1,
                IdEnfermera = 1,
                Fecha = DateTime.Now,
                IdCategoriaCita = 1,
                Descripción = "Revisión general",
            };

            await _controller.PostCita(citaDto);

            // Desatachar la entidad que se acaba de insertar para evitar conflictos
            var insertedCita = _fixture.Context.Citas.Local.FirstOrDefault(h => h.IdCita == 3);
            if (insertedCita != null)
            {
                _fixture.Context.Entry(insertedCita).State = EntityState.Detached;
            }

            var citaUpdateDto = new CitaUpdateDTO
            {
                IdCita = 3,
                IdPaciente = 1,
                IdDoctor = 1,
                IdEnfermera = 1,
                Fecha = DateTime.Now,
                IdCategoriaCita = 1,
                Descripción = "Revisión general",
            };

            // Act
            var result = await _controller.PutCita(3, citaUpdateDto);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }


        [Fact]
        public async Task DeleteCitas_ReturnsNoContent_WithValidId()
        {
            // Act
            Setup();
            var result = await _controller.DeleteCita(1);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }
    }
}

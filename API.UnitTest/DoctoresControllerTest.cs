using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema_de_Gestion_de_Hospitales.API.Controller;
using Sistema_de_Gestion_de_Hospitales.Shared.Doctor;
using Sistema_de_Gestion_de_Hospitales.API.Models;
using Sistema_de_Gestion_de_Hospitales.API.Data;
using API.UnitTest;

namespace Sistema_de_Gestion_de_Hospitales.API.UnitTest
{
    public class DoctoresControllerTest
    {
        private DoctoresController _controller;
        private DbTestFixture<SistemaHospitalDbContext> _fixture;

        public DoctoresControllerTest()
        {
            _fixture = new DbTestFixture<SistemaHospitalDbContext>();
            _controller = new DoctoresController(_fixture.Context, _fixture.Mapper);
        }

        [Fact]
        public void Setup()
        {
            SeedDataTest.SeedData(_fixture.Context);
        }

        [Fact]
        public async Task GetDoctores_ReturnsOkResult()
        {
            Setup();
            // Act
            var result = await _controller.GetDoctores();

            // Assert
            Assert.IsType<OkObjectResult>(result.Result);

            // Verificar que el valor devuelto no es nulo
            Assert.NotNull(result.Result);

            // Verificar los datos devueltos
            var okResult = result.Result as OkObjectResult;
            Assert.NotNull(okResult);

            var doctores = okResult.Value as IEnumerable<DoctorGetDTO>;
            Assert.NotNull(doctores);

            Assert.Equal(2, doctores.Count()); // Verificar que se devuelvan todas las habitaciones
        }

        [Fact]
        public async Task GetDoctor_ReturnsOkResult_WithValidId()
        {
            // Arrange
            Setup();
            var doctor = new Doctor
            {
                IdDoctor = 2,
                Cedula = "00298765432",
                NombreCompleto = "Dra. Maria Gonzalez",
                FechaContratacion = new DateOnly(2018, 5, 10),
                Direccion = "Avenida Central 456",
                Telefono = "987-654-3210",
                CorreoElectronico = "maria.gonzalez@example.com",
                IdEspecialidad = 2,
                IdDepartamento = 2
            };

            // Act
            var result = await _controller.GetDoctor(2);

            // Assert
            var doctorDto = Assert.IsType<DoctorGetDTO>(result.Value);
            Assert.Equal(doctor.IdDoctor, doctorDto.IdDoctor);
        }

        [Fact]
        public async Task PostDoctor_ReturnsOkResult_WithValidData()
        {
            // Arrange
            Setup();
            var doctorDto = new DoctorInsertDTO
            {
                Cedula = "11298765432",
                NombreCompleto = "Dra. Maria Gonzalez",
                FechaContratacion = new DateOnly(2018, 5, 10),
                Direccion = "Avenida Central 456",
                Telefono = "987-654-3210",
                CorreoElectronico = "maria.gonzalez@example.com",
                IdEspecialidad = 2,
                IdDepartamento = 2
            };

            // Act
            var result = await _controller.PostDoctor(doctorDto);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            Assert.IsType<int>(okResult.Value);
        }

        [Fact]
        public async Task PutDoctor_ReturnsNoContent_WithValidId()
        {
            // Arrange
            Setup();
            var doctorDto = new DoctorInsertDTO
            {
                Cedula = "15298765432",
                NombreCompleto = "Dra. Maria Gonzalez",
                FechaContratacion = new DateOnly(2018, 5, 10),
                Direccion = "Avenida Central 456",
                Telefono = "987-654-3210",
                CorreoElectronico = "maria.gonzalez@example.com",
                IdEspecialidad = 2,
                IdDepartamento = 2
            };

            await _controller.PostDoctor(doctorDto);

            // Desatachar la entidad que se acaba de insertar para evitar conflictos
            var insertedDoctor = _fixture.Context.Doctores.Local.FirstOrDefault(h => h.IdDoctor == 3);
            if (insertedDoctor != null)
            {
                _fixture.Context.Entry(insertedDoctor).State = EntityState.Detached;
            }

            var doctorUpdateDto = new DoctorUpdateDTO
            {
                IdDoctor = 3,
                Cedula = "15298765000",
                NombreCompleto = "Dra. Maria Gonzalez",
                FechaContratacion = new DateOnly(2018, 5, 10),
                Direccion = "Avenida Central 456",
                Telefono = "987-654-3210",
                CorreoElectronico = "maria.gonzalez@example.com",
                IdEspecialidad = 2,
                IdDepartamento = 2
            };

            // Act
            var result = await _controller.PutDoctor(3, doctorUpdateDto);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }


        [Fact]
        public async Task DeleteDoctor_ReturnsNoContent_WithValidId()
        {
            // Act
            Setup();
            var result = await _controller.DeleteDoctor(1);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }
    }
}

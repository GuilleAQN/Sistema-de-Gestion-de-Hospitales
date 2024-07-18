using Sistema_de_Gestion_de_Hospitales.API.Data;
using Sistema_de_Gestion_de_Hospitales.API.Models;

namespace API.UnitTest
{
    public static class SeedDataTest
    {
        public static void SeedData(SistemaHospitalDbContext dbContext)
        {
            var categoriasCitas = new List<CategoriasCita>
            {
                new CategoriasCita 
                { 
                    IdCategoriaCita = 1, 
                    Nombre = "Categoria 1", 
                    Descripcion = "Descripcion 1" 
                },
                new CategoriasCita 
                { 
                    IdCategoriaCita = 2, 
                    Nombre = "Categoria 1", 
                    Descripcion = "Descripcion 2" 
                }
            };

            var pacientes = new List<Paciente>{
                new Paciente
                {
                    IdPaciente = 1,
                    Cedula = "00101010100",
                    NombreCompleto = "Juan Perez",
                    FechaNacimiento = new DateOnly(1990, 1, 1),
                    Genero = "M",
                    Direccion = "Calle Falsa 123",
                    Telefono = "1234567890",
                    CorreoElectronico = "juan.perez@example.com"
                },
                new Paciente
                {
                    IdPaciente = 2,
                    Cedula = "00202020200",
                    NombreCompleto = "Maria Rodriguez",
                    FechaNacimiento = new DateOnly(1985, 2, 2),
                    Genero = "Femenino",
                    Direccion = "Avenida Siempre Viva 456",
                    Telefono = "0987654321",
                    CorreoElectronico = "maria.rodriguez@example.com"
                } };

            var departamentos = new List<Departamento>
            {
                new Departamento
                {
                    IdDepartamento = 1,
                    Nombre = "Cardiología",
                    Descripcion = "Departamento de Cardiología",
                    Ubicación = "Edificio A, Planta 2",
                    Telefono = "555-1234"
                },
                new Departamento
                {
                    IdDepartamento = 2,
                    Nombre = "Neurología",
                    Descripcion = "Departamento de Neurología",
                    Ubicación = "Edificio B, Planta 3",
                    Telefono = "555-5678"
                }
            };

            var enfermeras = new List<Enfermera>
            {
                new Enfermera
                {
                    IdEnfermera = 1,
                    Cedula = "00101010100",
                    NombreCompleto = "Enfermera Carla Sanchez",
                    FechaContratacion = new DateOnly(2020, 5, 5),
                    Direccion = "Plaza de la Salud 202",
                    Telefono = "3334445556",
                    CorreoElectronico = "carla.sanchez@example.com",
                    IdDepartamento = 1
                },
                new Enfermera
                {
                    IdEnfermera = 2,
                    Cedula = "00202020200",
                    NombreCompleto = "Enfermero Pedro Jimenez",
                    FechaContratacion = new DateOnly(2019, 6, 6),
                    Direccion = "Avenida Enfermeria 303",
                    Telefono = "4445556667",
                    CorreoElectronico = "pedro.jimenez@example.com",
                    IdDepartamento = 2
                }
            };

            var especialidades = new List<Especialidad>
            {
                new Especialidad
                {
                    IdEspecialidad = 1,
                    Nombre = "Cardiología",
                    Descripcion = "Especialidad médica que se encarga del estudio, diagnóstico y tratamiento de las enfermedades del corazón y del aparato circulatorio."
                },
                new Especialidad
                {
                    IdEspecialidad = 2,
                    Nombre = "Dermatología",
                    Descripcion = "Especialidad médica que se encarga del estudio, diagnóstico y tratamiento de las enfermedades de la piel, cabello y uñas."
                }
            };

            var citas = new List<Cita>
            {
                new Cita
                {
                    IdCita = 1,
                    IdPaciente = 1,
                    IdDoctor = 1,
                    IdEnfermera = 1,
                    Fecha = DateTime.Now,
                    IdCategoriaCita = 1,
                    Descripción = "Revisión general",
                },
                new Cita
                {
                    IdCita = 2,
                    IdPaciente = 2,
                    IdDoctor = 2,
                    IdEnfermera = 2,
                    Fecha = DateTime.Now.AddDays(1),
                    IdCategoriaCita = 2,
                    Descripción = "Consulta de especialidad",
                }
            };

            var habitaciones = new List<Habitacion>
            {
                new Habitacion 
                {
                    Numero = "1", 
                    Piso = 1, 
                    Tipo = "Tipo A", 
                    IdEstado = 1 
                },
                new Habitacion 
                { 
                    Numero = "2", 
                    Piso = 2, 
                    Tipo = "Tipo B", 
                    IdEstado = 2 
                }
            };

            var doctores = new List<Doctor>
            {
                new Doctor
                {
                    IdDoctor = 1,
                    Cedula = "00101010100",
                    NombreCompleto = "Dr. Luis Gomez",
                    FechaContratacion = new DateOnly(2015, 3, 3),
                    Direccion = "Boulevard de los Médicos 789",
                    Telefono = "1112223334",
                    CorreoElectronico = "luis.gomez@example.com",
                    IdEspecialidad = 1,
                    IdDepartamento = 1
                },
                new Doctor
                {
                    IdDoctor = 2,
                    Cedula = "00202020200",
                    NombreCompleto = "Dra. Ana Lopez",
                    FechaContratacion = new DateOnly(2018, 4, 4),
                    Direccion = "Calle de la Salud 101",
                    Telefono = "2223334445",
                    CorreoElectronico = "ana.lopez@example.com",
                    IdEspecialidad = 2,
                    IdDepartamento = 2
                }
            };

            var estados = new List<Estado>
            {
                new Estado { Nombre = "B" },
                new Estado { Nombre = "C" }
            };

            var tratamientos = new List<Tratamiento>
            {
                new Tratamiento
                {
                    IdTratamiento = 1,
                    Descripcion = "Descripcion 1",
                    FechaInicio = new DateOnly(2019, 6, 6),
                    FechaFin = new DateOnly(2020, 6, 6),
                    IdDiagnostico = 1,
                    IdDoctor = 1
                },
                new Tratamiento
                {
                    IdTratamiento = 2,
                    Descripcion = "Descripcion 2",
                    FechaInicio = new DateOnly(2019, 6, 6),
                    FechaFin = new DateOnly(2020, 6, 6),
                    IdDiagnostico = 2,
                    IdDoctor = 2
                },
            };

            dbContext.CategoriasCitas.AddRange(categoriasCitas);
            dbContext.Especialidades.AddRange(especialidades);
            dbContext.Estados.AddRange(estados);
            dbContext.Departamentos.AddRange(departamentos);
            dbContext.Pacientes.AddRange(pacientes);
            dbContext.Enfermeras.AddRange(enfermeras);
            dbContext.Doctores.AddRange(doctores);
            dbContext.Tratamientos.AddRange(tratamientos);
            dbContext.Habitaciones.AddRange(habitaciones);
            dbContext.Citas.AddRange(citas);
            dbContext.SaveChanges();
        }
    }
}

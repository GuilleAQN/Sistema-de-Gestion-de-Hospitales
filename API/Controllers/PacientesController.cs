using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shared.Paciente;
using API.Models;
using API.Data;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using API.Helper;

namespace API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacientesController : ControllerBase
    {
        private readonly SistemaHospitalDbContext context;
        private readonly IMapper mapper;

        public PacientesController(SistemaHospitalDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PacienteGetDTO>>> GetPacientes([FromQuery] PacienteQueryObject query)
        {
            var pacientes = context.Pacientes.AsQueryable();

            if (query != null)
            {
                pacientes = query switch
                {
                    _ when !string.IsNullOrWhiteSpace(query.NombreCompleto) =>
                    pacientes.Where(s => s.NombreCompleto.Contains(query.NombreCompleto)),
                    _ when !(query.FechaNacimiento != DateOnly.MinValue) =>
                    pacientes.Where(s => s.FechaNacimiento >= query.FechaNacimiento.AddDays(-5) && s.FechaNacimiento <= query.FechaNacimiento.AddDays(5)),
                    _ when !string.IsNullOrWhiteSpace(query.Genero) =>
                    pacientes.Where(s => s.Genero.Contains(query.Genero)),
                    _ when !string.IsNullOrWhiteSpace(query.CorreoElectronico) =>
                    pacientes.Where(s => s.CorreoElectronico.Contains(query.CorreoElectronico)),
                    _ => pacientes
                };
            }

            var pacienteList = await pacientes.ToListAsync();
            var pacientesDto = mapper.Map<IEnumerable<PacienteGetDTO>>(pacienteList);
            return Ok(pacientesDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PacienteGetDTO>> GetPaciente(int id)
        {
            var paciente = await context.Pacientes.FindAsync(id);

            if (paciente == null)
            {
                return NotFound(new ProblemDetails
                {
                    Status = StatusCodes.Status404NotFound,
                    Title = "Paciente no encontrado",
                    Detail = $"No se encontró un paciente con el ID {id}.",
                    Instance = HttpContext.Request.Path
                });
            }

            var pacienteDto = mapper.Map<PacienteGetDTO>(paciente);
            return pacienteDto;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPaciente(int id, PacienteUpdateDTO pacienteDto)
        {
            if (id != pacienteDto.IdPaciente)
            {
                return BadRequest(new ProblemDetails
                {
                    Status = StatusCodes.Status400BadRequest,
                    Title = "ID no coincide",
                    Detail = "El ID proporcionado no coincide con el ID del paciente.",
                    Instance = HttpContext.Request.Path
                });
            }

            var paciente = mapper.Map<Paciente>(pacienteDto);
            context.Entry(paciente).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await PacienteExists(id))
                {
                    return NotFound(new ProblemDetails
                    {
                        Status = StatusCodes.Status404NotFound,
                        Title = "Paciente no encontrado",
                        Detail = $"No se encontró un paciente con el ID {id}.",
                        Instance = HttpContext.Request.Path
                    });
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Paciente>> PostPaciente(PacienteInsertDTO pacienteDto)
        {
            var paciente = mapper.Map<Paciente>(pacienteDto);

            if (await PacienteExists(paciente?.Cedula))
            {
                return BadRequest(new ProblemDetails
                {
                    Status = StatusCodes.Status400BadRequest,
                    Title = "Cédula no coincide",
                    Detail = "La cédula proporcionada no coincide con la cédula del paciente.",
                    Instance = HttpContext.Request.Path
                });
            }

            context.Pacientes.Add(paciente);
            await context.SaveChangesAsync();

            return Ok(paciente.IdPaciente);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePaciente(int id)
        {
            var paciente = await context.Pacientes.FindAsync(id);
            if (paciente == null)
            {
                return NotFound(new ProblemDetails
                {
                    Status = StatusCodes.Status404NotFound,
                    Title = "Paciente no encontrado",
                    Detail = $"No se encontró un paciente con el ID {id}.",
                    Instance = HttpContext.Request.Path
                });
            }

            context.Pacientes.Remove(paciente);
            await context.SaveChangesAsync();

            return NoContent();
        }

        private async Task<bool> PacienteExists(int id)
        {
            return await context.Pacientes.AnyAsync(e => e.IdPaciente == id);
        }

        private async Task<bool> PacienteExists(string cedula)
        {
            return await context.Pacientes.AnyAsync(e => e.Cedula == cedula);
        }
    }
}

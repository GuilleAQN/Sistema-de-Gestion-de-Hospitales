using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shared.Cita;
using API.Models;
using API.Helper;
using API.Data;

namespace API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitasController : ControllerBase
    {
        private readonly SistemaHospitalDbContext context;
        private readonly IMapper mapper;

        public CitasController(SistemaHospitalDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CitaGetDTO>>> GetCitas([FromQuery] CitasQueryObject query)
        {
            var citas = context.Citas
                .Include(c => c.IdPacienteNavigation)
                .Include(c => c.IdDoctorNavigation)
                .Include(c => c.IdEnfermeraNavigation)
                .Include(c => c.IdCategoriaCitaNavigation)
                .AsQueryable();

            if (query != null)
            {
                citas = query switch
                {
                    _ when !string.IsNullOrWhiteSpace(query.IdPaciente) => citas.Where(s => s.IdPaciente.Equals(query.IdPaciente)),
                    _ when !string.IsNullOrWhiteSpace(query.IdDoctor) => citas.Where(s => s.IdDoctor.Equals(query.IdDoctor)),
                    _ when !string.IsNullOrWhiteSpace(query.IdEnfermera) => citas.Where(s => s.IdEnfermera.Equals(query.IdEnfermera)),
                    _ when !string.IsNullOrWhiteSpace(query.IdCategoriaCita) => citas.Where(s => s.IdCategoriaCita.Equals(query.IdCategoriaCita)),
                    _ when !(query.Fecha != DateTime.MinValue) => 
                    citas.Where(s => s.Fecha <= query.Fecha),
                    _ => citas
                };
            }

            var citasList = await citas.ToListAsync();
            var citasDto = mapper.Map<IEnumerable<CitaGetDTO>>(citasList);
            return Ok(citasDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CitaGetDTO>> GetCita(int id)
        {
            var cita = await context.Citas.FindAsync(id);

            if (cita == null)
            {
                return NotFound(new ProblemDetails
                {
                    Status = StatusCodes.Status404NotFound,
                    Title = "Cita no encontrada",
                    Detail = $"No se encontró una cita con el ID {id}.",
                    Instance = HttpContext.Request.Path
                });
            }

            var citaDto = mapper.Map<CitaGetDTO>(cita);
            return citaDto;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCita(int id, CitaUpdateDTO citaDto)
        {
            if (id != citaDto.IdCita)
            {
                return BadRequest(new ProblemDetails
                {
                    Status = StatusCodes.Status400BadRequest,
                    Title = "ID no coincide",
                    Detail = "El ID proporcionado no coincide con el ID de la cita.",
                    Instance = HttpContext.Request.Path
                });
            }

            var cita = mapper.Map<Cita>(citaDto);
            context.Entry(cita).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await CitaExists(id))
                {
                    return NotFound(new ProblemDetails
                    {
                        Status = StatusCodes.Status404NotFound,
                        Title = "Cita no encontrada",
                        Detail = $"No se encontró una cita con el ID {id}.",
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
        public async Task<ActionResult<Cita>> PostCita(CitaInsertDTO citaDto)
        {
            var cita = mapper.Map<Cita>(citaDto);
            context.Citas.Add(cita);
            await context.SaveChangesAsync();

            return Ok(cita.IdCita);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCita(int id)
        {
            var cita = await context.Citas.FindAsync(id);
            if (cita == null)
            {
                return NotFound(new ProblemDetails
                {
                    Status = StatusCodes.Status404NotFound,
                    Title = "Cita no encontrada",
                    Detail = $"No se encontró una cita con el ID {id}.",
                    Instance = HttpContext.Request.Path
                });
            }

            context.Citas.Remove(cita);
            await context.SaveChangesAsync();

            return NoContent();
        }

        private async Task<bool> CitaExists(int id)
        {
            return await context.Citas.AnyAsync(e => e.IdCita == id);
        }
    }
}

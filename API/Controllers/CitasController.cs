using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema_de_Gestion_de_Hospitales.Shared.Cita;
using Sistema_de_Gestion_de_Hospitales.API.Models;
using Sistema_de_Gestion_de_Hospitales.API.Data;

namespace Sistema_de_Gestion_de_Hospitales.API.Controller
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
        public async Task<ActionResult<IEnumerable<CitaGetDTO>>> GetCitas()
        {
            var citasList = await context.Citas
                .Include(c => c.IdPacienteNavigation)
                .Include(c => c.IdDoctorNavigation)
                .Include(c => c.IdEnfermeraNavigation)
                .Include(c => c.IdCategoriaCitaNavigation)
                .ToListAsync();
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

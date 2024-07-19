using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema_de_Gestion_de_Hospitales.Shared.Especialidad;
using Sistema_de_Gestion_de_Hospitales.API.Data;
using Sistema_de_Gestion_de_Hospitales.API.Models;
using Sistema_de_Gestion_de_Hospitales.Shared.Cita;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EspecialidadesController : ControllerBase
    {
        private readonly SistemaHospitalDbContext context;
        private readonly IMapper mapper;

        public EspecialidadesController(SistemaHospitalDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EspecialidadGetDTO>>> GetEspecialidades()
        {
            var especialidadesList = await context.Especialidades.ToListAsync();
            var especialidadesDto = mapper.Map<IEnumerable<EspecialidadGetDTO>>(especialidadesList);
            return Ok(especialidadesDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EspecialidadGetDTO>> GetEspecialidad(int id)
        {
            var especialidad = await context.Especialidades.FindAsync(id);

            if (especialidad == null)
            {
                return NotFound(new ProblemDetails
                {
                    Status = StatusCodes.Status404NotFound,
                    Title = "Especialidad no encontrada",
                    Detail = $"No se encontró una especialidad con el ID {id}.",
                    Instance = HttpContext.Request.Path
                });
            }

            var especialidadDto = mapper.Map<EspecialidadGetDTO>(especialidad);
            return especialidadDto;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutEspecialidad(int id, EspecialidadUpdateDTO especialidadDto)
        {
            if (id != especialidadDto.IdEspecialidad)
            {
                return BadRequest(new ProblemDetails
                {
                    Status = StatusCodes.Status400BadRequest,
                    Title = "ID no coincide",
                    Detail = "El ID proporcionado no coincide con el ID de la especialidad.",
                    Instance = HttpContext.Request.Path
                });
            }

            var especialidad = mapper.Map<Especialidad>(especialidadDto);
            context.Entry(especialidad).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await EspecialidadExists(id))
                {
                    return NotFound(new ProblemDetails
                    {
                        Status = StatusCodes.Status404NotFound,
                        Title = "Especialidad no encontrada",
                        Detail = $"No se encontró una especialidad con el ID {id}.",
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
        public async Task<ActionResult<Especialidad>> PostEspecialidad(EspecialidadInsertDTO especialidadDto)
        {
            var especialidad = mapper.Map<Especialidad>(especialidadDto);
            await context.Especialidades.AddAsync(especialidad);
            await context.SaveChangesAsync();

            return Ok(especialidad.IdEspecialidad);
        }

        // DELETE: api/Especialidades/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEspecialidad(int id)
        {
            var especialidad = await context.Especialidades.FindAsync(id);
            if (especialidad == null)
            {
                return NotFound(new ProblemDetails
                {
                    Status = StatusCodes.Status404NotFound,
                    Title = "Especialidad no encontrada",
                    Detail = $"No se encontró una especialidad con el ID {id}.",
                    Instance = HttpContext.Request.Path
                });
            }

            context.Especialidades.Remove(especialidad);
            await context.SaveChangesAsync();

            return NoContent();
        }

        private async Task<bool> EspecialidadExists(int id)
        {
            return await context.Especialidades.AnyAsync(e => e.IdEspecialidad == id);
        }
    }
}

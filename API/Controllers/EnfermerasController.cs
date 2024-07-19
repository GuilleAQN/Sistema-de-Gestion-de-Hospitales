﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema_de_Gestion_de_Hospitales.Shared.Enfermera;
using Sistema_de_Gestion_de_Hospitales.API.Models;
using Sistema_de_Gestion_de_Hospitales.API.Data;

namespace Sistema_de_Gestion_de_Hospitales.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnfermerasController : ControllerBase
    {
        private readonly SistemaHospitalDbContext context;
        private readonly IMapper mapper;

        public EnfermerasController(SistemaHospitalDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EnfermeraGetDTO>>> GetEnfermeras()
        {
            var enfermeraList = await context.Enfermeras
                .Include(c => c.IdDepartamentoNavigation)
                .ToListAsync();
            var enfermerasDto = mapper.Map<IEnumerable<EnfermeraGetDTO>>(enfermeraList);
            return Ok(enfermerasDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EnfermeraGetDTO>> GetEnfermera(int id)
        {
            var enfermera = await context.Enfermeras.FindAsync(id);

            if (enfermera == null)
            {
                return NotFound(new ProblemDetails
                {
                    Status = StatusCodes.Status404NotFound,
                    Title = "Enfermera no encontrada",
                    Detail = $"No se encontró una enfermera con el ID {id}.",
                    Instance = HttpContext.Request.Path
                });
            }

            var enfermeraDto = mapper.Map<EnfermeraGetDTO>(enfermera);
            return enfermeraDto;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutEnfermera(int id, EnfermeraUpdateDTO enfermeraDto)
        {
            if (id != enfermeraDto.IdEnfermera)
            {
                return BadRequest(new ProblemDetails
                {
                    Status = StatusCodes.Status400BadRequest,
                    Title = "ID no coincide",
                    Detail = "El ID proporcionado no coincide con el ID de la enfermera.",
                    Instance = HttpContext.Request.Path
                });
            }

            var enfermera = mapper.Map<Enfermera>(enfermeraDto);
            context.Entry(enfermera).State = EntityState.Modified;

            try
            {
                if (await EnfermeraExists(enfermeraDto.Cedula))
                {
                    return BadRequest(new ProblemDetails
                    {
                        Status = StatusCodes.Status400BadRequest,
                        Title = "Cédula existente",
                        Detail = "La cédula proporcionada ya existe.",
                        Instance = HttpContext.Request.Path
                    });
                }
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await EnfermeraExists(id))
                {
                    return NotFound(new ProblemDetails
                    {
                        Status = StatusCodes.Status404NotFound,
                        Title = "Enfermera no encontrada",
                        Detail = $"No se encontró una enfermera con el ID {id}.",
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
        public async Task<ActionResult<Enfermera>> PostEnfermera(EnfermeraInsertDTO enfermeraDto)
        {
            var enfermera = mapper.Map<Enfermera>(enfermeraDto);

            if (await EnfermeraExists(enfermera?.Cedula))
            {
                return BadRequest(new ProblemDetails
                {
                    Status = StatusCodes.Status400BadRequest,
                    Title = "Cédula existente",
                    Detail = "La cédula proporcionada ya existe.",
                    Instance = HttpContext.Request.Path
                });
            }

            context.Enfermeras.Add(enfermera);
            await context.SaveChangesAsync();

            return Ok(enfermera.IdEnfermera);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEnfermera(int id)
        {
            var enfermera = await context.Enfermeras.FindAsync(id);
            if (enfermera == null)
            {
                return NotFound(new ProblemDetails
                {
                    Status = StatusCodes.Status404NotFound,
                    Title = "Enfermera no encontrada",
                    Detail = $"No se encontró una enfermera con el ID {id}.",
                    Instance = HttpContext.Request.Path
                });
            }

            context.Enfermeras.Remove(enfermera);
            await context.SaveChangesAsync();

            return NoContent();
        }

        private async Task<bool> EnfermeraExists(int id)
        {
            return await context.Enfermeras.AnyAsync(e => e.IdEnfermera == id);
        }

        private async Task<bool> EnfermeraExists(string cedula)
        {
            return await context.Enfermeras.AnyAsync(e => e.Cedula == cedula);
        }
    }
}

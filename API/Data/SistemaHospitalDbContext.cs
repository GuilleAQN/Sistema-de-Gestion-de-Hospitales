using API.Models;
using API.Models.ModelConfiguration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public partial class SistemaHospitalDbContext : IdentityDbContext
{
    public SistemaHospitalDbContext()
    {
    }

    public SistemaHospitalDbContext(DbContextOptions<SistemaHospitalDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CategoriasCita> CategoriasCitas { get; set; }

    public virtual DbSet<Cita> Citas { get; set; }

    public virtual DbSet<Departamento> Departamentos { get; set; }

    public virtual DbSet<Diagnostico> Diagnosticos { get; set; }

    public virtual DbSet<Doctor> Doctores { get; set; }

    public virtual DbSet<Enfermera> Enfermeras { get; set; }

    public virtual DbSet<Especialidad> Especialidades { get; set; }

    public virtual DbSet<Estado> Estados { get; set; }

    public virtual DbSet<Habitacion> Habitaciones { get; set; }

    public virtual DbSet<Paciente> Pacientes { get; set; }

    public virtual DbSet<Tratamiento> Tratamientos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("name=DefaultConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new CategoriaCitasConfiguration());

        modelBuilder.ApplyConfiguration(new CitasConfiguration());
        
        modelBuilder.ApplyConfiguration(new DepartamentosConfiguration());
        
        modelBuilder.ApplyConfiguration(new DiagnosticosConfiguration());
        
        modelBuilder.ApplyConfiguration(new EnfermerasConfiguration());
        
        modelBuilder.ApplyConfiguration(new EspecialidadesConfiguration());
        
        modelBuilder.ApplyConfiguration(new EstadosConfiguration());
        
        modelBuilder.ApplyConfiguration(new HabitacionesConfiguration());

        modelBuilder.ApplyConfiguration(new PacientesConfiguration());

        modelBuilder.ApplyConfiguration(new TratamientosConfiguration());

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

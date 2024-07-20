using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Sistema_de_Gestion_de_Hospitales.API.Models.ModelConfiguration
{
    public class CitasConfiguration : IEntityTypeConfiguration<Cita>
    {
        public void Configure(EntityTypeBuilder<Cita> entity)
        {
            entity.HasKey(e => e.IdCita).HasName("PK__Citas__394B0202326FDFC1");

            entity.Property(e => e.Descripción).HasMaxLength(200);

            entity.HasOne(d => d.IdCategoriaCitaNavigation).WithMany(p => p.Cita)
                .HasForeignKey(d => d.IdCategoriaCita)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Citas__IdCategor__3C69FB99");

            entity.HasOne(d => d.IdDoctorNavigation).WithMany(p => p.Cita)
                .HasForeignKey(d => d.IdDoctor)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK__Citas__IdDoctor__3A81B327");

            entity.HasOne(d => d.IdEnfermeraNavigation).WithMany(p => p.Cita)
                .HasForeignKey(d => d.IdEnfermera)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Citas__IdEnferme__3B75D760");

            entity.HasOne(d => d.IdPacienteNavigation).WithMany(p => p.Cita)
                .HasForeignKey(d => d.IdPaciente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Citas__IdPacient__398D8EEE");
        }
    }
}

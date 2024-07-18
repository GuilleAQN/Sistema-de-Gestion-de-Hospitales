using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Sistema_de_Gestion_de_Hospitales.API.Models.ModelConfiguration
{
    public class DoctoresConfiguration : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> entity)
        {
            entity.HasKey(e => e.IdDoctor).HasName("PK__Doctores__F838DB3E706836D6");

            entity.Property(e => e.Cedula).HasMaxLength(11);
            entity.Property(e => e.CorreoElectronico).HasMaxLength(60);
            entity.Property(e => e.Direccion).HasMaxLength(200);
            entity.Property(e => e.NombreCompleto).HasMaxLength(150);
            entity.Property(e => e.Telefono).HasMaxLength(10);

            entity.HasOne(d => d.IdDepartamentoNavigation).WithMany(p => p.Doctores)
                .HasForeignKey(d => d.IdDepartamento)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Doctores__IdDepa__31EC6D26");

            entity.HasOne(d => d.IdEspecialidadNavigation).WithMany(p => p.Doctores)
                .HasForeignKey(d => d.IdEspecialidad)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Doctores__IdEspecialidad__3C34244G9365KKNSVB");
        }
    }
}

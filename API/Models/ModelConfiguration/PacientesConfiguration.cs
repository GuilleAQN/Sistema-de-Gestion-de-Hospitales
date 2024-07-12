using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Sistema_de_Gestion_de_Hospitales.API.Models.ModelConfiguration
{
    public class PacientesConfiguration : IEntityTypeConfiguration<Paciente>
    {
        public void Configure(EntityTypeBuilder<Paciente> entity)
        {
            entity.HasKey(e => e.IdPaciente).HasName("PK__Paciente__C93DB49B253BFD35");

            entity.Property(e => e.Cedula).HasMaxLength(11);
            entity.Property(e => e.CorreoElectronico).HasMaxLength(60);
            entity.Property(e => e.Direccion).HasMaxLength(200);
            entity.Property(e => e.Genero)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.NombreCompleto).HasMaxLength(150);
            entity.Property(e => e.Telefono).HasMaxLength(10);
        }
    }
}

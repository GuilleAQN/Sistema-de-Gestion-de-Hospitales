using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Models.ModelConfiguration
{
    public class EnfermerasConfiguration : IEntityTypeConfiguration<Enfermera>
    {
        public void Configure(EntityTypeBuilder<Enfermera> entity)
        {
            entity.HasKey(e => e.IdEnfermera).HasName("PK__Enfermer__56277F23CD120B8E");

            entity.Property(e => e.Cedula).HasMaxLength(11);
            entity.Property(e => e.CorreoElectronico).HasMaxLength(60);
            entity.Property(e => e.Direccion).HasMaxLength(200);
            entity.Property(e => e.NombreCompleto).HasMaxLength(150);
            entity.Property(e => e.Telefono).HasMaxLength(10);

            entity.HasOne(d => d.IdDepartamentoNavigation).WithMany(p => p.Enfermeras)
                .HasForeignKey(d => d.IdDepartamento)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Enfermera__IdDep__34C8D9D1");
        }
    }
}

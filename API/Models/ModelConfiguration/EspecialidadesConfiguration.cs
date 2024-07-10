using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Models.ModelConfiguration
{
    public class EspecialidadesConfiguration : IEntityTypeConfiguration<Especialidad>
    {
        public void Configure(EntityTypeBuilder<Especialidad> entity)
        {
            entity.HasKey(e => e.IdEspecialidad).HasName("PK__Especial__693FA0AF70A82E6A");

            entity.Property(e => e.Descripcion).HasMaxLength(150);
            entity.Property(e => e.Nombre).HasMaxLength(35);
        }
    }
}

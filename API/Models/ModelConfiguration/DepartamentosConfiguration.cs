using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Models.ModelConfiguration
{
    public class DepartamentosConfiguration : IEntityTypeConfiguration<Departamento>
    {
        public void Configure(EntityTypeBuilder<Departamento> entity)
        {
            entity.HasKey(e => e.IdDepartamento).HasName("PK__Departam__787A433D539991D3");

            entity.Property(e => e.Descripcion).HasMaxLength(150);
            entity.Property(e => e.Nombre).HasMaxLength(80);
            entity.Property(e => e.Telefono).HasMaxLength(10);
            entity.Property(e => e.Ubicación).HasMaxLength(50);
        }
    }
}

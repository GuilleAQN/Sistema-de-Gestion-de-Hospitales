using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Models.ModelConfiguration
{
    public class CategoriaCitasConfiguration : IEntityTypeConfiguration<CategoriasCita>
    {
        public void Configure(EntityTypeBuilder<CategoriasCita> entity)
        {
            entity.HasKey(e => e.IdCategoriaCita).HasName("PK__Categori__114A2E92A651349A");
            entity.Property(e => e.Descripcion).HasMaxLength(150);
            entity.Property(e => e.Nombre).HasMaxLength(35);
        }
    }
}

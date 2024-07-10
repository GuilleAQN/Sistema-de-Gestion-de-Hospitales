using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Models.ModelConfiguration
{
    public class EstadosConfiguration : IEntityTypeConfiguration<Estado>
    {
        public void Configure(EntityTypeBuilder<Estado> entity)
        {
            entity.HasKey(e => e.IdEstado).HasName("PK__Estados__FBB0EDC1662ECE55");

            entity.Property(e => e.Nombre).HasMaxLength(30);
        }
    }
}

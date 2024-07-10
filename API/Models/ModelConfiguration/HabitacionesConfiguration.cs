using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Models.ModelConfiguration
{
    public class HabitacionesConfiguration : IEntityTypeConfiguration<Habitacion>
    {
        public void Configure(EntityTypeBuilder<Habitacion> entity)
        {
            entity.HasKey(e => e.IdHabitacion).HasName("PK__Habitaci__8BBBF9010102AE43");

            entity.Property(e => e.Numero).HasMaxLength(5);
            entity.Property(e => e.Tipo).HasMaxLength(50);
        }
    }
}

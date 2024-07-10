using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Models.ModelConfiguration
{
    public class DiagnosticosConfiguration : IEntityTypeConfiguration<Diagnostico>
    {
        public void Configure(EntityTypeBuilder<Diagnostico> entity)
        {
            entity.HasKey(e => e.IdDiagnostico).HasName("PK__Diagnost__BD16DB691D10418D");

            entity.Property(e => e.Descripcion).HasColumnType("text");

            entity.HasOne(d => d.IdDoctorNavigation).WithMany(p => p.Diagnosticos)
                .HasForeignKey(d => d.IdDoctor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Diagnosti__IdDoc__403A8C7D");

            entity.HasOne(d => d.IdPacienteNavigation).WithMany(p => p.Diagnosticos)
                .HasForeignKey(d => d.IdPaciente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Diagnosti__IdPac__3F466844");
        }
    }
}

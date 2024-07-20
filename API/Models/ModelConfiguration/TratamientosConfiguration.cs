﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Sistema_de_Gestion_de_Hospitales.API.Models.ModelConfiguration
{
    public class TratamientosConfiguration : IEntityTypeConfiguration<Tratamiento>
    {
        public void Configure(EntityTypeBuilder<Tratamiento> entity)
        {
            entity.HasKey(e => e.IdTratamiento).HasName("PK__Tratamie__5CB7E7530EAF222C");

            entity.Property(e => e.Descripcion).HasColumnType("text");

            entity.HasOne(d => d.IdDiagnosticoNavigation).WithMany(p => p.Tratamientos)
                .HasForeignKey(d => d.IdDiagnostico)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK__Tratamien__IdDia__4316F928");

            entity.HasOne(d => d.IdDoctorNavigation).WithMany(p => p.Tratamientos)
                .HasForeignKey(d => d.IdDoctor)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK__Tratamien__IdDoc__440B1D61");
        }
    }
}

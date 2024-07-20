﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Sistema_de_Gestion_de_Hospitales.API.Data;

#nullable disable

namespace API.Migrations
{
    [DbContext(typeof(SistemaHospitalDbContext))]
    partial class SistemaHospitalDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Sistema_de_Gestion_de_Hospitales.API.Models.AppUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Sistema_de_Gestion_de_Hospitales.API.Models.CategoriasCita", b =>
                {
                    b.Property<int>("IdCategoriaCita")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCategoriaCita"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(35)
                        .HasColumnType("nvarchar(35)");

                    b.HasKey("IdCategoriaCita")
                        .HasName("PK__Categori__114A2E92A651349A");

                    b.ToTable("CategoriasCitas");
                });

            modelBuilder.Entity("Sistema_de_Gestion_de_Hospitales.API.Models.Cita", b =>
                {
                    b.Property<int>("IdCita")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCita"));

                    b.Property<string>("Descripción")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<int?>("IdCategoriaCita")
                        .HasColumnType("int");

                    b.Property<int?>("IdDoctor")
                        .HasColumnType("int");

                    b.Property<int?>("IdEnfermera")
                        .HasColumnType("int");

                    b.Property<int?>("IdPaciente")
                        .HasColumnType("int");

                    b.HasKey("IdCita")
                        .HasName("PK__Citas__394B0202326FDFC1");

                    b.HasIndex("IdCategoriaCita");

                    b.HasIndex("IdDoctor");

                    b.HasIndex("IdEnfermera");

                    b.HasIndex("IdPaciente");

                    b.ToTable("Citas");
                });

            modelBuilder.Entity("Sistema_de_Gestion_de_Hospitales.API.Models.Departamento", b =>
                {
                    b.Property<int>("IdDepartamento")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdDepartamento"));

                    b.Property<string>("Descripcion")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Ubicación")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IdDepartamento")
                        .HasName("PK__Departam__787A433D539991D3");

                    b.ToTable("Departamentos");
                });

            modelBuilder.Entity("Sistema_de_Gestion_de_Hospitales.API.Models.Diagnostico", b =>
                {
                    b.Property<int>("IdDiagnostico")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdDiagnostico"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateOnly>("Fecha")
                        .HasColumnType("date");

                    b.Property<int?>("IdDoctor")
                        .HasColumnType("int");

                    b.Property<int?>("IdPaciente")
                        .HasColumnType("int");

                    b.HasKey("IdDiagnostico")
                        .HasName("PK__Diagnost__BD16DB691D10418D");

                    b.HasIndex("IdDoctor");

                    b.HasIndex("IdPaciente");

                    b.ToTable("Diagnosticos");
                });

            modelBuilder.Entity("Sistema_de_Gestion_de_Hospitales.API.Models.Doctor", b =>
                {
                    b.Property<int>("IdDoctor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdDoctor"));

                    b.Property<string>("Cedula")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("CorreoElectronico")
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<string>("Direccion")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateOnly>("FechaContratacion")
                        .HasColumnType("date");

                    b.Property<int?>("IdDepartamento")
                        .HasColumnType("int");

                    b.Property<int?>("IdEspecialidad")
                        .HasColumnType("int");

                    b.Property<string>("NombreCompleto")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("IdDoctor")
                        .HasName("PK__Doctores__F838DB3E706836D6");

                    b.HasIndex("IdDepartamento");

                    b.HasIndex("IdEspecialidad");

                    b.ToTable("Doctores");
                });

            modelBuilder.Entity("Sistema_de_Gestion_de_Hospitales.API.Models.Enfermera", b =>
                {
                    b.Property<int>("IdEnfermera")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdEnfermera"));

                    b.Property<string>("Cedula")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("CorreoElectronico")
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<string>("Direccion")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateOnly>("FechaContratacion")
                        .HasColumnType("date");

                    b.Property<int?>("IdDepartamento")
                        .HasColumnType("int");

                    b.Property<string>("NombreCompleto")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("IdEnfermera")
                        .HasName("PK__Enfermer__56277F23CD120B8E");

                    b.HasIndex("IdDepartamento");

                    b.ToTable("Enfermeras");
                });

            modelBuilder.Entity("Sistema_de_Gestion_de_Hospitales.API.Models.Especialidad", b =>
                {
                    b.Property<int>("IdEspecialidad")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdEspecialidad"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(35)
                        .HasColumnType("nvarchar(35)");

                    b.HasKey("IdEspecialidad")
                        .HasName("PK__Especial__693FA0AF70A82E6A");

                    b.ToTable("Especialidades");
                });

            modelBuilder.Entity("Sistema_de_Gestion_de_Hospitales.API.Models.Estado", b =>
                {
                    b.Property<int>("IdEstado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdEstado"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("IdEstado")
                        .HasName("PK__Estados__FBB0EDC1662ECE55");

                    b.ToTable("Estados");
                });

            modelBuilder.Entity("Sistema_de_Gestion_de_Hospitales.API.Models.Habitacion", b =>
                {
                    b.Property<int>("IdHabitacion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdHabitacion"));

                    b.Property<int?>("IdEstado")
                        .HasColumnType("int");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.Property<int>("Piso")
                        .HasColumnType("int");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IdHabitacion")
                        .HasName("PK__Habitaci__8BBBF9010102AE43");

                    b.HasIndex("IdEstado");

                    b.ToTable("Habitaciones");
                });

            modelBuilder.Entity("Sistema_de_Gestion_de_Hospitales.API.Models.Paciente", b =>
                {
                    b.Property<int>("IdPaciente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPaciente"));

                    b.Property<string>("Cedula")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("CorreoElectronico")
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<string>("Direccion")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateOnly>("FechaNacimiento")
                        .HasColumnType("date");

                    b.Property<string>("Genero")
                        .IsRequired()
                        .HasMaxLength(1)
                        .IsUnicode(false)
                        .HasColumnType("char(1)")
                        .IsFixedLength();

                    b.Property<string>("NombreCompleto")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("IdPaciente")
                        .HasName("PK__Paciente__C93DB49B253BFD35");

                    b.ToTable("Pacientes");
                });

            modelBuilder.Entity("Sistema_de_Gestion_de_Hospitales.API.Models.Tratamiento", b =>
                {
                    b.Property<int>("IdTratamiento")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdTratamiento"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateOnly>("FechaFin")
                        .HasColumnType("date");

                    b.Property<DateOnly>("FechaInicio")
                        .HasColumnType("date");

                    b.Property<int?>("IdDiagnostico")
                        .HasColumnType("int");

                    b.Property<int?>("IdDoctor")
                        .HasColumnType("int");

                    b.HasKey("IdTratamiento")
                        .HasName("PK__Tratamie__5CB7E7530EAF222C");

                    b.HasIndex("IdDiagnostico");

                    b.HasIndex("IdDoctor");

                    b.ToTable("Tratamientos");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Sistema_de_Gestion_de_Hospitales.API.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Sistema_de_Gestion_de_Hospitales.API.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Sistema_de_Gestion_de_Hospitales.API.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Sistema_de_Gestion_de_Hospitales.API.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Sistema_de_Gestion_de_Hospitales.API.Models.Cita", b =>
                {
                    b.HasOne("Sistema_de_Gestion_de_Hospitales.API.Models.CategoriasCita", "IdCategoriaCitaNavigation")
                        .WithMany("Cita")
                        .HasForeignKey("IdCategoriaCita")
                        .HasConstraintName("FK__Citas__IdCategor__3C69FB99");

                    b.HasOne("Sistema_de_Gestion_de_Hospitales.API.Models.Doctor", "IdDoctorNavigation")
                        .WithMany("Cita")
                        .HasForeignKey("IdDoctor")
                        .HasConstraintName("FK__Citas__IdDoctor__3A81B327");

                    b.HasOne("Sistema_de_Gestion_de_Hospitales.API.Models.Enfermera", "IdEnfermeraNavigation")
                        .WithMany("Cita")
                        .HasForeignKey("IdEnfermera")
                        .HasConstraintName("FK__Citas__IdEnferme__3B75D760");

                    b.HasOne("Sistema_de_Gestion_de_Hospitales.API.Models.Paciente", "IdPacienteNavigation")
                        .WithMany("Cita")
                        .HasForeignKey("IdPaciente")
                        .HasConstraintName("FK__Citas__IdPacient__398D8EEE");

                    b.Navigation("IdCategoriaCitaNavigation");

                    b.Navigation("IdDoctorNavigation");

                    b.Navigation("IdEnfermeraNavigation");

                    b.Navigation("IdPacienteNavigation");
                });

            modelBuilder.Entity("Sistema_de_Gestion_de_Hospitales.API.Models.Diagnostico", b =>
                {
                    b.HasOne("Sistema_de_Gestion_de_Hospitales.API.Models.Doctor", "IdDoctorNavigation")
                        .WithMany("Diagnosticos")
                        .HasForeignKey("IdDoctor")
                        .HasConstraintName("FK__Diagnosti__IdDoc__403A8C7D");

                    b.HasOne("Sistema_de_Gestion_de_Hospitales.API.Models.Paciente", "IdPacienteNavigation")
                        .WithMany("Diagnosticos")
                        .HasForeignKey("IdPaciente")
                        .HasConstraintName("FK__Diagnosti__IdPac__3F466844");

                    b.Navigation("IdDoctorNavigation");

                    b.Navigation("IdPacienteNavigation");
                });

            modelBuilder.Entity("Sistema_de_Gestion_de_Hospitales.API.Models.Doctor", b =>
                {
                    b.HasOne("Sistema_de_Gestion_de_Hospitales.API.Models.Departamento", "IdDepartamentoNavigation")
                        .WithMany("Doctores")
                        .HasForeignKey("IdDepartamento")
                        .HasConstraintName("FK__Doctores__IdDepa__31EC6D26");

                    b.HasOne("Sistema_de_Gestion_de_Hospitales.API.Models.Especialidad", "IdEspecialidadNavigation")
                        .WithMany("Doctores")
                        .HasForeignKey("IdEspecialidad")
                        .HasConstraintName("FK__Doctores__IdEspecialidad__3C34244G9365KKNSVB");

                    b.Navigation("IdDepartamentoNavigation");

                    b.Navigation("IdEspecialidadNavigation");
                });

            modelBuilder.Entity("Sistema_de_Gestion_de_Hospitales.API.Models.Enfermera", b =>
                {
                    b.HasOne("Sistema_de_Gestion_de_Hospitales.API.Models.Departamento", "IdDepartamentoNavigation")
                        .WithMany("Enfermeras")
                        .HasForeignKey("IdDepartamento")
                        .HasConstraintName("FK__Enfermera__IdDep__34C8D9D1");

                    b.Navigation("IdDepartamentoNavigation");
                });

            modelBuilder.Entity("Sistema_de_Gestion_de_Hospitales.API.Models.Habitacion", b =>
                {
                    b.HasOne("Sistema_de_Gestion_de_Hospitales.API.Models.Estado", "IdEstadoNavigation")
                        .WithMany("Habitacion")
                        .HasForeignKey("IdEstado")
                        .HasConstraintName("FK__Estado__Habitacion__3C3456532CG");

                    b.Navigation("IdEstadoNavigation");
                });

            modelBuilder.Entity("Sistema_de_Gestion_de_Hospitales.API.Models.Tratamiento", b =>
                {
                    b.HasOne("Sistema_de_Gestion_de_Hospitales.API.Models.Diagnostico", "IdDiagnosticoNavigation")
                        .WithMany("Tratamientos")
                        .HasForeignKey("IdDiagnostico")
                        .HasConstraintName("FK__Tratamien__IdDia__4316F928");

                    b.HasOne("Sistema_de_Gestion_de_Hospitales.API.Models.Doctor", "IdDoctorNavigation")
                        .WithMany("Tratamientos")
                        .HasForeignKey("IdDoctor")
                        .HasConstraintName("FK__Tratamien__IdDoc__440B1D61");

                    b.Navigation("IdDiagnosticoNavigation");

                    b.Navigation("IdDoctorNavigation");
                });

            modelBuilder.Entity("Sistema_de_Gestion_de_Hospitales.API.Models.CategoriasCita", b =>
                {
                    b.Navigation("Cita");
                });

            modelBuilder.Entity("Sistema_de_Gestion_de_Hospitales.API.Models.Departamento", b =>
                {
                    b.Navigation("Doctores");

                    b.Navigation("Enfermeras");
                });

            modelBuilder.Entity("Sistema_de_Gestion_de_Hospitales.API.Models.Diagnostico", b =>
                {
                    b.Navigation("Tratamientos");
                });

            modelBuilder.Entity("Sistema_de_Gestion_de_Hospitales.API.Models.Doctor", b =>
                {
                    b.Navigation("Cita");

                    b.Navigation("Diagnosticos");

                    b.Navigation("Tratamientos");
                });

            modelBuilder.Entity("Sistema_de_Gestion_de_Hospitales.API.Models.Enfermera", b =>
                {
                    b.Navigation("Cita");
                });

            modelBuilder.Entity("Sistema_de_Gestion_de_Hospitales.API.Models.Especialidad", b =>
                {
                    b.Navigation("Doctores");
                });

            modelBuilder.Entity("Sistema_de_Gestion_de_Hospitales.API.Models.Estado", b =>
                {
                    b.Navigation("Habitacion");
                });

            modelBuilder.Entity("Sistema_de_Gestion_de_Hospitales.API.Models.Paciente", b =>
                {
                    b.Navigation("Cita");

                    b.Navigation("Diagnosticos");
                });
#pragma warning restore 612, 618
        }
    }
}

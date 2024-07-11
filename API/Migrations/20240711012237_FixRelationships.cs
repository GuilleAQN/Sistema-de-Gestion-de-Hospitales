using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class FixRelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdEspecialidadNavigationIdEspecialidad",
                table: "Doctores",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Habitaciones_IdEstado",
                table: "Habitaciones",
                column: "IdEstado");

            migrationBuilder.CreateIndex(
                name: "IX_Doctores_IdEspecialidadNavigationIdEspecialidad",
                table: "Doctores",
                column: "IdEspecialidadNavigationIdEspecialidad");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctores_Especialidades_IdEspecialidadNavigationIdEspecialidad",
                table: "Doctores",
                column: "IdEspecialidadNavigationIdEspecialidad",
                principalTable: "Especialidades",
                principalColumn: "IdEspecialidad",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK__Estado__Habitacion__3C3456532CG",
                table: "Habitaciones",
                column: "IdEstado",
                principalTable: "Estados",
                principalColumn: "IdEstado");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctores_Especialidades_IdEspecialidadNavigationIdEspecialidad",
                table: "Doctores");

            migrationBuilder.DropForeignKey(
                name: "FK__Estado__Habitacion__3C3456532CG",
                table: "Habitaciones");

            migrationBuilder.DropIndex(
                name: "IX_Habitaciones_IdEstado",
                table: "Habitaciones");

            migrationBuilder.DropIndex(
                name: "IX_Doctores_IdEspecialidadNavigationIdEspecialidad",
                table: "Doctores");

            migrationBuilder.DropColumn(
                name: "IdEspecialidadNavigationIdEspecialidad",
                table: "Doctores");
        }
    }
}

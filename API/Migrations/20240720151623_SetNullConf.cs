using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class SetNullConf : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__Citas__IdDoctor__3A81B327",
                table: "Citas");

            migrationBuilder.DropForeignKey(
                name: "FK__Diagnosti__IdDoc__403A8C7D",
                table: "Diagnosticos");

            migrationBuilder.DropForeignKey(
                name: "FK__Tratamien__IdDoc__440B1D61",
                table: "Tratamientos");

            migrationBuilder.AddForeignKey(
                name: "FK__Citas__IdDoctor__3A81B327",
                table: "Citas",
                column: "IdDoctor",
                principalTable: "Doctores",
                principalColumn: "IdDoctor",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK__Diagnosti__IdDoc__403A8C7D",
                table: "Diagnosticos",
                column: "IdDoctor",
                principalTable: "Doctores",
                principalColumn: "IdDoctor",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK__Tratamien__IdDoc__440B1D61",
                table: "Tratamientos",
                column: "IdDoctor",
                principalTable: "Doctores",
                principalColumn: "IdDoctor",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__Citas__IdDoctor__3A81B327",
                table: "Citas");

            migrationBuilder.DropForeignKey(
                name: "FK__Diagnosti__IdDoc__403A8C7D",
                table: "Diagnosticos");

            migrationBuilder.DropForeignKey(
                name: "FK__Tratamien__IdDoc__440B1D61",
                table: "Tratamientos");

            migrationBuilder.AddForeignKey(
                name: "FK__Citas__IdDoctor__3A81B327",
                table: "Citas",
                column: "IdDoctor",
                principalTable: "Doctores",
                principalColumn: "IdDoctor");

            migrationBuilder.AddForeignKey(
                name: "FK__Diagnosti__IdDoc__403A8C7D",
                table: "Diagnosticos",
                column: "IdDoctor",
                principalTable: "Doctores",
                principalColumn: "IdDoctor");

            migrationBuilder.AddForeignKey(
                name: "FK__Tratamien__IdDoc__440B1D61",
                table: "Tratamientos",
                column: "IdDoctor",
                principalTable: "Doctores",
                principalColumn: "IdDoctor");
        }
    }
}

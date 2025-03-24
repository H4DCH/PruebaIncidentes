using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PruebaJunior.Migrations
{
    public partial class AgregadoComentarios2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ComentarioDetalle",
                table: "Comentarios",
                newName: "Texto");

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaCreacion",
                table: "Comentarios",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "IncidenteId",
                table: "Comentarios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Comentarios_IncidenteId",
                table: "Comentarios",
                column: "IncidenteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comentarios_Incidente_IncidenteId",
                table: "Comentarios",
                column: "IncidenteId",
                principalTable: "Incidente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comentarios_Incidente_IncidenteId",
                table: "Comentarios");

            migrationBuilder.DropIndex(
                name: "IX_Comentarios_IncidenteId",
                table: "Comentarios");

            migrationBuilder.DropColumn(
                name: "FechaCreacion",
                table: "Comentarios");

            migrationBuilder.DropColumn(
                name: "IncidenteId",
                table: "Comentarios");

            migrationBuilder.RenameColumn(
                name: "Texto",
                table: "Comentarios",
                newName: "ComentarioDetalle");
        }
    }
}

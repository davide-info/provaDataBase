using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace database.Migrations
{
    public partial class migr1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Utenti",
                table: "Utenti");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Utenti");

            migrationBuilder.AddColumn<int>(
                name: "IdStudente",
                table: "Utenti",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "StudenteIdStudente",
                table: "Utenti",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Utenti",
                table: "Utenti",
                column: "IdStudente");

            migrationBuilder.CreateTable(
                name: "Esami",
                columns: table => new
                {
                    IdEsame = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudenteForeignKey = table.Column<int>(nullable: false),
                    StudenteKeyIdStudente = table.Column<int>(nullable: true),
                    VotoEsame = table.Column<int>(nullable: false),
                    DataEsame = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Esami", x => x.IdEsame);
                    table.ForeignKey(
                        name: "FK_Esami_Utenti_StudenteKeyIdStudente",
                        column: x => x.StudenteKeyIdStudente,
                        principalTable: "Utenti",
                        principalColumn: "IdStudente",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Utenti_StudenteIdStudente",
                table: "Utenti",
                column: "StudenteIdStudente");

            migrationBuilder.CreateIndex(
                name: "IX_Esami_StudenteKeyIdStudente",
                table: "Esami",
                column: "StudenteKeyIdStudente");

            migrationBuilder.AddForeignKey(
                name: "FK_Utenti_Utenti_StudenteIdStudente",
                table: "Utenti",
                column: "StudenteIdStudente",
                principalTable: "Utenti",
                principalColumn: "IdStudente",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Utenti_Utenti_StudenteIdStudente",
                table: "Utenti");

            migrationBuilder.DropTable(
                name: "Esami");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Utenti",
                table: "Utenti");

            migrationBuilder.DropIndex(
                name: "IX_Utenti_StudenteIdStudente",
                table: "Utenti");

            migrationBuilder.DropColumn(
                name: "IdStudente",
                table: "Utenti");

            migrationBuilder.DropColumn(
                name: "StudenteIdStudente",
                table: "Utenti");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Utenti",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Utenti",
                table: "Utenti",
                column: "Id");
        }
    }
}

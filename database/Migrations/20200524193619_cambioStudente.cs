using Microsoft.EntityFrameworkCore.Migrations;

namespace database.Migrations
{
    public partial class cambioStudente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Esami_Utenti_StudenteKeyIdStudente",
                table: "Esami");

            migrationBuilder.DropForeignKey(
                name: "FK_Utenti_Utenti_StudenteIdStudente",
                table: "Utenti");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Utenti",
                table: "Utenti");

            migrationBuilder.RenameTable(
                name: "Utenti",
                newName: "Studenti");

            migrationBuilder.RenameIndex(
                name: "IX_Utenti_StudenteIdStudente",
                table: "Studenti",
                newName: "IX_Studenti_StudenteIdStudente");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Studenti",
                table: "Studenti",
                column: "IdStudente");

            migrationBuilder.AddForeignKey(
                name: "FK_Esami_Studenti_StudenteKeyIdStudente",
                table: "Esami",
                column: "StudenteKeyIdStudente",
                principalTable: "Studenti",
                principalColumn: "IdStudente",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Studenti_Studenti_StudenteIdStudente",
                table: "Studenti",
                column: "StudenteIdStudente",
                principalTable: "Studenti",
                principalColumn: "IdStudente",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Esami_Studenti_StudenteKeyIdStudente",
                table: "Esami");

            migrationBuilder.DropForeignKey(
                name: "FK_Studenti_Studenti_StudenteIdStudente",
                table: "Studenti");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Studenti",
                table: "Studenti");

            migrationBuilder.RenameTable(
                name: "Studenti",
                newName: "Utenti");

            migrationBuilder.RenameIndex(
                name: "IX_Studenti_StudenteIdStudente",
                table: "Utenti",
                newName: "IX_Utenti_StudenteIdStudente");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Utenti",
                table: "Utenti",
                column: "IdStudente");

            migrationBuilder.AddForeignKey(
                name: "FK_Esami_Utenti_StudenteKeyIdStudente",
                table: "Esami",
                column: "StudenteKeyIdStudente",
                principalTable: "Utenti",
                principalColumn: "IdStudente",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Utenti_Utenti_StudenteIdStudente",
                table: "Utenti",
                column: "StudenteIdStudente",
                principalTable: "Utenti",
                principalColumn: "IdStudente",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

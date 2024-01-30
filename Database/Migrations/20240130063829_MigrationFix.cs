using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    public partial class MigrationFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Series_Productos_IdGeneroPrimario",
                table: "Series");

            migrationBuilder.DropForeignKey(
                name: "FK_Series_Productos_IdGeneroSecundario",
                table: "Series");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Productos",
                table: "Productos");

            migrationBuilder.RenameTable(
                name: "Productos",
                newName: "Generos");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Generos",
                table: "Generos",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Series_Generos_IdGeneroPrimario",
                table: "Series",
                column: "IdGeneroPrimario",
                principalTable: "Generos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Series_Generos_IdGeneroSecundario",
                table: "Series",
                column: "IdGeneroSecundario",
                principalTable: "Generos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Series_Generos_IdGeneroPrimario",
                table: "Series");

            migrationBuilder.DropForeignKey(
                name: "FK_Series_Generos_IdGeneroSecundario",
                table: "Series");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Generos",
                table: "Generos");

            migrationBuilder.RenameTable(
                name: "Generos",
                newName: "Productos");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Productos",
                table: "Productos",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Series_Productos_IdGeneroPrimario",
                table: "Series",
                column: "IdGeneroPrimario",
                principalTable: "Productos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Series_Productos_IdGeneroSecundario",
                table: "Series",
                column: "IdGeneroSecundario",
                principalTable: "Productos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

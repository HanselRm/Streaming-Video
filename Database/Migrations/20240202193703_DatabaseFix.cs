using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    public partial class DatabaseFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Series_Imagenes_IdImagen",
                table: "Series");

            migrationBuilder.DropTable(
                name: "Imagenes");

            migrationBuilder.DropIndex(
                name: "IX_Series_IdImagen",
                table: "Series");

            migrationBuilder.DropColumn(
                name: "IdImagen",
                table: "Series");

            migrationBuilder.AddColumn<string>(
                name: "ImagenUrl",
                table: "Series",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagenUrl",
                table: "Series");

            migrationBuilder.AddColumn<int>(
                name: "IdImagen",
                table: "Series",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Imagenes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ruta = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Imagenes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Series_IdImagen",
                table: "Series",
                column: "IdImagen");

            migrationBuilder.AddForeignKey(
                name: "FK_Series_Imagenes_IdImagen",
                table: "Series",
                column: "IdImagen",
                principalTable: "Imagenes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

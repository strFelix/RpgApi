using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RpgApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_PERSONAGENS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PontosVida = table.Column<int>(type: "int", nullable: false),
                    Forca = table.Column<int>(type: "int", nullable: false),
                    Defesa = table.Column<int>(type: "int", nullable: false),
                    Inteligencia = table.Column<int>(type: "int", nullable: false),
                    Classe = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_PERSONAGENS", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "TB_PERSONAGENS",
                columns: new[] { "Id", "Classe", "Defesa", "Forca", "Inteligencia", "Nome", "PontosVida" },
                values: new object[,]
                {
                    { 1, 1, 23, 17, 33, "Frodo", 100 },
                    { 2, 1, 25, 15, 30, "Sam", 100 },
                    { 3, 3, 21, 18, 35, "Galadriel", 100 },
                    { 4, 2, 18, 18, 37, "Gandalf", 100 },
                    { 5, 1, 17, 20, 31, "Hobbit", 100 },
                    { 6, 3, 13, 21, 34, "Celeborn", 100 },
                    { 7, 2, 11, 25, 35, "Radagast", 100 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_PERSONAGENS");
        }
    }
}

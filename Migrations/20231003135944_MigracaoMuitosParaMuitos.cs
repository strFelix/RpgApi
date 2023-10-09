using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RpgApi.Migrations
{
    /// <inheritdoc />
    public partial class MigracaoMuitosParaMuitos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Derrotas",
                table: "TB_PERSONAGENS",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Disputas",
                table: "TB_PERSONAGENS",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Vitorias",
                table: "TB_PERSONAGENS",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TB_HABILIDADES",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dano = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_HABILIDADES", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_PERSONAGENS_HABILIDADES",
                columns: table => new
                {
                    PersonagemId = table.Column<int>(type: "int", nullable: false),
                    HabilidadeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_PERSONAGENS_HABILIDADES", x => new { x.PersonagemId, x.HabilidadeId });
                    table.ForeignKey(
                        name: "FK_TB_PERSONAGENS_HABILIDADES_TB_HABILIDADES_HabilidadeId",
                        column: x => x.HabilidadeId,
                        principalTable: "TB_HABILIDADES",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_PERSONAGENS_HABILIDADES_TB_PERSONAGENS_PersonagemId",
                        column: x => x.PersonagemId,
                        principalTable: "TB_PERSONAGENS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "TB_HABILIDADES",
                columns: new[] { "Id", "Dano", "Nome" },
                values: new object[,]
                {
                    { 1, 39, "Adormecer" },
                    { 2, 41, "Congelar" },
                    { 3, 37, "Hipnotizar" }
                });

            migrationBuilder.UpdateData(
                table: "TB_PERSONAGENS",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Derrotas", "Disputas", "Vitorias" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "TB_PERSONAGENS",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Derrotas", "Disputas", "Vitorias" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "TB_PERSONAGENS",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Derrotas", "Disputas", "Vitorias" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "TB_PERSONAGENS",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Derrotas", "Disputas", "Vitorias" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "TB_PERSONAGENS",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Derrotas", "Disputas", "Vitorias" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "TB_PERSONAGENS",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Derrotas", "Disputas", "Vitorias" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "TB_PERSONAGENS",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Derrotas", "Disputas", "Vitorias" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "TB_USUARIOS",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 204, 126, 57, 39, 92, 92, 116, 152, 46, 221, 12, 47, 79, 32, 162, 101, 138, 176, 184, 40, 21, 22, 11, 58, 44, 251, 238, 45, 203, 85, 166, 196, 81, 175, 65, 116, 90, 235, 6, 61, 225, 179, 92, 214, 247, 234, 161, 216, 158, 45, 239, 217, 23, 70, 73, 37, 148, 244, 49, 126, 71, 223, 135, 27 }, new byte[] { 162, 160, 216, 195, 60, 217, 202, 137, 217, 77, 85, 221, 210, 29, 151, 254, 103, 50, 62, 3, 40, 152, 162, 235, 233, 16, 233, 3, 26, 105, 7, 38, 228, 155, 115, 206, 20, 174, 129, 14, 232, 44, 76, 20, 219, 169, 237, 247, 253, 87, 227, 116, 171, 233, 81, 242, 152, 88, 7, 217, 103, 248, 2, 76, 220, 100, 104, 247, 67, 125, 187, 19, 81, 158, 101, 30, 5, 52, 191, 236, 166, 193, 97, 159, 209, 55, 231, 243, 207, 255, 12, 30, 114, 52, 4, 189, 65, 54, 212, 118, 210, 160, 209, 221, 57, 69, 1, 254, 225, 46, 49, 223, 73, 181, 122, 22, 83, 150, 108, 142, 80, 44, 75, 90, 201, 39, 92, 4 } });

            migrationBuilder.InsertData(
                table: "TB_PERSONAGENS_HABILIDADES",
                columns: new[] { "HabilidadeId", "PersonagemId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 2, 2 },
                    { 2, 3 },
                    { 3, 3 },
                    { 3, 4 },
                    { 1, 5 },
                    { 2, 6 },
                    { 3, 7 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_PERSONAGENS_HABILIDADES_HabilidadeId",
                table: "TB_PERSONAGENS_HABILIDADES",
                column: "HabilidadeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_PERSONAGENS_HABILIDADES");

            migrationBuilder.DropTable(
                name: "TB_HABILIDADES");

            migrationBuilder.DropColumn(
                name: "Derrotas",
                table: "TB_PERSONAGENS");

            migrationBuilder.DropColumn(
                name: "Disputas",
                table: "TB_PERSONAGENS");

            migrationBuilder.DropColumn(
                name: "Vitorias",
                table: "TB_PERSONAGENS");

            migrationBuilder.UpdateData(
                table: "TB_USUARIOS",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 204, 222, 73, 166, 240, 76, 163, 182, 23, 83, 249, 30, 251, 79, 168, 182, 163, 113, 131, 246, 10, 19, 121, 228, 190, 248, 14, 147, 140, 58, 205, 17, 7, 11, 99, 58, 100, 96, 204, 242, 139, 38, 158, 51, 83, 164, 23, 253, 221, 23, 138, 252, 162, 128, 128, 199, 159, 179, 239, 146, 11, 148, 8, 249 }, new byte[] { 122, 0, 122, 37, 20, 49, 220, 6, 48, 67, 119, 25, 17, 90, 237, 243, 179, 210, 127, 70, 172, 216, 68, 250, 79, 111, 26, 41, 186, 92, 169, 24, 12, 57, 236, 19, 28, 141, 32, 201, 2, 132, 112, 55, 142, 254, 31, 56, 54, 219, 28, 222, 195, 85, 45, 89, 107, 207, 125, 164, 180, 82, 103, 61, 39, 51, 67, 15, 122, 88, 117, 231, 223, 107, 229, 150, 239, 91, 198, 221, 160, 200, 74, 54, 221, 24, 88, 233, 143, 203, 93, 216, 153, 20, 245, 150, 183, 242, 190, 122, 69, 162, 20, 103, 143, 150, 4, 191, 4, 48, 20, 252, 123, 70, 40, 44, 28, 201, 237, 57, 45, 209, 143, 34, 80, 158, 95, 196 } });
        }
    }
}

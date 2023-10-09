using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RpgApi.Migrations
{
    /// <inheritdoc />
    public partial class MigracaoUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "FotoPersonagem",
                table: "TB_PERSONAGENS",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "TB_PERSONAGENS",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TB_USUARIOS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Foto = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Latitude = table.Column<double>(type: "float", nullable: true),
                    Longitude = table.Column<double>(type: "float", nullable: true),
                    DataAcesso = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Perfil = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: "Jogador"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_USUARIOS", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "TB_PERSONAGENS",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FotoPersonagem", "UsuarioId" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "TB_PERSONAGENS",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FotoPersonagem", "UsuarioId" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "TB_PERSONAGENS",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "FotoPersonagem", "UsuarioId" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "TB_PERSONAGENS",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "FotoPersonagem", "UsuarioId" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "TB_PERSONAGENS",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "FotoPersonagem", "UsuarioId" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "TB_PERSONAGENS",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "FotoPersonagem", "UsuarioId" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "TB_PERSONAGENS",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "FotoPersonagem", "UsuarioId" },
                values: new object[] { null, null });

            migrationBuilder.InsertData(
                table: "TB_USUARIOS",
                columns: new[] { "Id", "DataAcesso", "Email", "Foto", "Latitude", "Longitude", "PasswordHash", "PasswordSalt", "Perfil", "Username" },
                values: new object[] { 1, null, "seuEmail@gmail.com", null, -23.520024100000001, -46.596497999999997, new byte[] { 141, 255, 185, 43, 140, 82, 42, 149, 65, 158, 216, 37, 133, 7, 126, 84, 150, 1, 201, 142, 166, 238, 232, 169, 8, 21, 251, 160, 146, 103, 47, 42, 85, 138, 24, 154, 62, 142, 179, 160, 244, 180, 253, 12, 88, 185, 75, 45, 133, 201, 171, 34, 124, 110, 165, 10, 130, 52, 31, 184, 244, 52, 249, 25 }, new byte[] { 42, 39, 32, 43, 25, 212, 95, 43, 47, 84, 127, 22, 245, 187, 28, 2, 242, 106, 33, 102, 222, 211, 29, 254, 19, 120, 154, 36, 13, 144, 204, 110, 138, 102, 139, 143, 193, 73, 92, 64, 215, 195, 66, 217, 247, 252, 50, 76, 168, 130, 38, 40, 229, 26, 205, 30, 94, 31, 8, 151, 140, 89, 92, 106, 45, 50, 33, 36, 44, 157, 237, 57, 76, 17, 189, 251, 135, 62, 138, 243, 49, 245, 15, 64, 130, 112, 150, 232, 153, 219, 213, 103, 175, 214, 234, 198, 24, 167, 209, 48, 198, 209, 112, 171, 202, 158, 239, 220, 203, 35, 67, 225, 54, 98, 250, 3, 93, 137, 164, 120, 74, 66, 142, 246, 201, 244, 117, 156 }, "Admin", "UsuarioAdmin" });

            migrationBuilder.CreateIndex(
                name: "IX_TB_PERSONAGENS_UsuarioId",
                table: "TB_PERSONAGENS",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_PERSONAGENS_TB_USUARIOS_UsuarioId",
                table: "TB_PERSONAGENS",
                column: "UsuarioId",
                principalTable: "TB_USUARIOS",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_PERSONAGENS_TB_USUARIOS_UsuarioId",
                table: "TB_PERSONAGENS");

            migrationBuilder.DropTable(
                name: "TB_USUARIOS");

            migrationBuilder.DropIndex(
                name: "IX_TB_PERSONAGENS_UsuarioId",
                table: "TB_PERSONAGENS");

            migrationBuilder.DropColumn(
                name: "FotoPersonagem",
                table: "TB_PERSONAGENS");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "TB_PERSONAGENS");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RpgApi.Migrations
{
    /// <inheritdoc />
    public partial class MigracaoUmParaUm : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PersonagemId",
                table: "TB_ARMAS",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "TB_ARMAS",
                keyColumn: "Id",
                keyValue: 1,
                column: "PersonagemId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "TB_ARMAS",
                keyColumn: "Id",
                keyValue: 2,
                column: "PersonagemId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "TB_ARMAS",
                keyColumn: "Id",
                keyValue: 3,
                column: "PersonagemId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "TB_ARMAS",
                keyColumn: "Id",
                keyValue: 4,
                column: "PersonagemId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "TB_ARMAS",
                keyColumn: "Id",
                keyValue: 5,
                column: "PersonagemId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "TB_ARMAS",
                keyColumn: "Id",
                keyValue: 6,
                column: "PersonagemId",
                value: 6);

            migrationBuilder.UpdateData(
                table: "TB_ARMAS",
                keyColumn: "Id",
                keyValue: 7,
                column: "PersonagemId",
                value: 7);

            migrationBuilder.UpdateData(
                table: "TB_USUARIOS",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 204, 222, 73, 166, 240, 76, 163, 182, 23, 83, 249, 30, 251, 79, 168, 182, 163, 113, 131, 246, 10, 19, 121, 228, 190, 248, 14, 147, 140, 58, 205, 17, 7, 11, 99, 58, 100, 96, 204, 242, 139, 38, 158, 51, 83, 164, 23, 253, 221, 23, 138, 252, 162, 128, 128, 199, 159, 179, 239, 146, 11, 148, 8, 249 }, new byte[] { 122, 0, 122, 37, 20, 49, 220, 6, 48, 67, 119, 25, 17, 90, 237, 243, 179, 210, 127, 70, 172, 216, 68, 250, 79, 111, 26, 41, 186, 92, 169, 24, 12, 57, 236, 19, 28, 141, 32, 201, 2, 132, 112, 55, 142, 254, 31, 56, 54, 219, 28, 222, 195, 85, 45, 89, 107, 207, 125, 164, 180, 82, 103, 61, 39, 51, 67, 15, 122, 88, 117, 231, 223, 107, 229, 150, 239, 91, 198, 221, 160, 200, 74, 54, 221, 24, 88, 233, 143, 203, 93, 216, 153, 20, 245, 150, 183, 242, 190, 122, 69, 162, 20, 103, 143, 150, 4, 191, 4, 48, 20, 252, 123, 70, 40, 44, 28, 201, 237, 57, 45, 209, 143, 34, 80, 158, 95, 196 } });

            migrationBuilder.CreateIndex(
                name: "IX_TB_ARMAS_PersonagemId",
                table: "TB_ARMAS",
                column: "PersonagemId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TB_ARMAS_TB_PERSONAGENS_PersonagemId",
                table: "TB_ARMAS",
                column: "PersonagemId",
                principalTable: "TB_PERSONAGENS",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_ARMAS_TB_PERSONAGENS_PersonagemId",
                table: "TB_ARMAS");

            migrationBuilder.DropIndex(
                name: "IX_TB_ARMAS_PersonagemId",
                table: "TB_ARMAS");

            migrationBuilder.DropColumn(
                name: "PersonagemId",
                table: "TB_ARMAS");

            migrationBuilder.UpdateData(
                table: "TB_USUARIOS",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 141, 255, 185, 43, 140, 82, 42, 149, 65, 158, 216, 37, 133, 7, 126, 84, 150, 1, 201, 142, 166, 238, 232, 169, 8, 21, 251, 160, 146, 103, 47, 42, 85, 138, 24, 154, 62, 142, 179, 160, 244, 180, 253, 12, 88, 185, 75, 45, 133, 201, 171, 34, 124, 110, 165, 10, 130, 52, 31, 184, 244, 52, 249, 25 }, new byte[] { 42, 39, 32, 43, 25, 212, 95, 43, 47, 84, 127, 22, 245, 187, 28, 2, 242, 106, 33, 102, 222, 211, 29, 254, 19, 120, 154, 36, 13, 144, 204, 110, 138, 102, 139, 143, 193, 73, 92, 64, 215, 195, 66, 217, 247, 252, 50, 76, 168, 130, 38, 40, 229, 26, 205, 30, 94, 31, 8, 151, 140, 89, 92, 106, 45, 50, 33, 36, 44, 157, 237, 57, 76, 17, 189, 251, 135, 62, 138, 243, 49, 245, 15, 64, 130, 112, 150, 232, 153, 219, 213, 103, 175, 214, 234, 198, 24, 167, 209, 48, 198, 209, 112, 171, 202, 158, 239, 220, 203, 35, 67, 225, 54, 98, 250, 3, 93, 137, 164, 120, 74, 66, 142, 246, 201, 244, 117, 156 } });
        }
    }
}

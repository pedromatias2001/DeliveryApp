using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AManeira.Data.Migrations
{
    public partial class updatepratos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a",
                column: "ConcurrencyStamp",
                value: "bdf1926b-9752-40d3-aa33-6aacd589a0b9");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c",
                column: "ConcurrencyStamp",
                value: "d57a6905-b172-4126-a595-36f900de9152");

            migrationBuilder.UpdateData(
                table: "Pratos",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Descricao", "NumStock" },
                values: new object[] { "Tostas de Queijo e Fiambre", 5 });

            migrationBuilder.UpdateData(
                table: "Pratos",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Descricao", "Nome", "NumStock" },
                values: new object[] { "Pizza de 4 Queijos com orégãos", "Pizza", 7 });

            migrationBuilder.UpdateData(
                table: "Pratos",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Descricao", "Nome", "NumStock" },
                values: new object[] { "Hamburguer com Queijo, Tomate e Bacon", "Hamburguer", 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a",
                column: "ConcurrencyStamp",
                value: "8c7d4b86-e81d-438e-b3d0-e18a1012cf2e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c",
                column: "ConcurrencyStamp",
                value: "ed377732-9634-47e5-8a33-1fbecba0047a");

            migrationBuilder.UpdateData(
                table: "Pratos",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Descricao", "NumStock" },
                values: new object[] { null, 0 });

            migrationBuilder.UpdateData(
                table: "Pratos",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Descricao", "Nome", "NumStock" },
                values: new object[] { null, "Pizza de 4 Queijos", 0 });

            migrationBuilder.UpdateData(
                table: "Pratos",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Descricao", "Nome", "NumStock" },
                values: new object[] { null, "Hamburguer de Queijo e Fiambre", 0 });
        }
    }
}

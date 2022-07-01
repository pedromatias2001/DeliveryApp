using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AManeira.Data.Migrations
{
    public partial class PrecoADecimal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Preco",
                table: "Pratos",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a",
                column: "ConcurrencyStamp",
                value: "ef172267-8396-4390-927c-728e87461c51");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c",
                column: "ConcurrencyStamp",
                value: "d95185f9-edd9-4ae7-8efe-b9b265aa8b54");

            migrationBuilder.UpdateData(
                table: "Pratos",
                keyColumn: "Id",
                keyValue: 1,
                column: "Preco",
                value: 4.5m);

            migrationBuilder.UpdateData(
                table: "Pratos",
                keyColumn: "Id",
                keyValue: 2,
                column: "Preco",
                value: 7.5m);

            migrationBuilder.UpdateData(
                table: "Pratos",
                keyColumn: "Id",
                keyValue: 3,
                column: "Preco",
                value: 5.5m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Preco",
                table: "Pratos",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a",
                column: "ConcurrencyStamp",
                value: "0df63dbc-ce6d-4a87-ac20-54f83e2fa1a4");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c",
                column: "ConcurrencyStamp",
                value: "b69e842e-1ef3-43ce-baa9-69d309492510");

            migrationBuilder.UpdateData(
                table: "Pratos",
                keyColumn: "Id",
                keyValue: 1,
                column: "Preco",
                value: 4.5);

            migrationBuilder.UpdateData(
                table: "Pratos",
                keyColumn: "Id",
                keyValue: 2,
                column: "Preco",
                value: 7.5);

            migrationBuilder.UpdateData(
                table: "Pratos",
                keyColumn: "Id",
                keyValue: 3,
                column: "Preco",
                value: 5.5);
        }
    }
}

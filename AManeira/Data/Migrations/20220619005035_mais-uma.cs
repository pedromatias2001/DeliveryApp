using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AManeira.Data.Migrations
{
    public partial class maisuma : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                keyValue: 2,
                column: "Descricao",
                value: "Pizza de Pepperoni");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a",
                column: "ConcurrencyStamp",
                value: "23589212-eb5e-45b9-8a70-06ed7e4329f6");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c",
                column: "ConcurrencyStamp",
                value: "9e66580a-e69a-4f17-ac06-93491338e29c");

            migrationBuilder.UpdateData(
                table: "Pratos",
                keyColumn: "Id",
                keyValue: 2,
                column: "Descricao",
                value: "Pizza de 4 Queijos com orégãos");
        }
    }
}

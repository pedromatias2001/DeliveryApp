using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AManeira.Data.Migrations
{
    public partial class porfavorv2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                column: "Foto",
                value: "tostas1.jpg");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a",
                column: "ConcurrencyStamp",
                value: "f9c19d95-bcbe-453d-b773-1d70b0b0e6a9");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c",
                column: "ConcurrencyStamp",
                value: "34509c55-b9e8-4a74-93c3-cf715f84a841");

            migrationBuilder.UpdateData(
                table: "Pratos",
                keyColumn: "Id",
                keyValue: 1,
                column: "Foto",
                value: "tostas1.png");
        }
    }
}

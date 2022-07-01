using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AManeira.Data.Migrations
{
    public partial class replaceImgFormats : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a",
                column: "ConcurrencyStamp",
                value: "daabd203-5edd-45dd-924c-8589262bfcd7");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c",
                column: "ConcurrencyStamp",
                value: "f2137e02-4995-421e-9f97-6a236f636906");

            migrationBuilder.InsertData(
                table: "Fotos",
                columns: new[] { "Id", "Name", "PratoFK" },
                values: new object[,]
                {
                    { 1, "tostas2.jpg", 1 },
                    { 2, "tostas3.jpg", 1 },
                    { 3, "hamburguer2.jpg", 3 },
                    { 4, "pizza2.jpg", 2 },
                    { 5, "pizza3.jpg", 2 },
                    { 6, "hamburguer3.jpg", 3 },
                    { 7, "tostas4.jpg", 1 },
                    { 8, "pizza4.jpg", 2 },
                    { 9, "hamburguer4.jpg", 3 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Fotos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Fotos",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Fotos",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Fotos",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Fotos",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Fotos",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Fotos",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Fotos",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Fotos",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a",
                column: "ConcurrencyStamp",
                value: "51aa1efc-7fa6-4b98-a248-ed7c14fce8d4");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c",
                column: "ConcurrencyStamp",
                value: "9f3e9e65-0ddf-4951-a6bb-01d48e48a2a5");
        }
    }
}

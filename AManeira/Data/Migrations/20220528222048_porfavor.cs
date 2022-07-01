using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AManeira.Data.Migrations
{
    public partial class porfavor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Preco",
                table: "Pratos",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataRegisto",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "Fotos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PratoFK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fotos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fotos_Pratos_PratoFK",
                        column: x => x.PratoFK,
                        principalTable: "Pratos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a", "f9c19d95-bcbe-453d-b773-1d70b0b0e6a9", "Admin", "ADMIN" },
                    { "c", "34509c55-b9e8-4a74-93c3-cf715f84a841", "Cliente", "CLIENTE" }
                });

            migrationBuilder.InsertData(
                table: "Pratos",
                columns: new[] { "Id", "Descricao", "Foto", "Nome", "NumStock", "Preco" },
                values: new object[,]
                {
                    { 1, null, "tostas1.png", "Tostas Mistas", 0, 4.5 },
                    { 2, null, "pizza1.jpg", "Pizza de 4 Queijos", 0, 7.5 },
                    { 3, null, "burguer1.jpg", "Hamburguer de Queijo e Fiambre", 0, 5.5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Fotos_PratoFK",
                table: "Fotos",
                column: "PratoFK");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Fotos");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c");

            migrationBuilder.DeleteData(
                table: "Pratos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Pratos",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Pratos",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "DataRegisto",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<decimal>(
                name: "Preco",
                table: "Pratos",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");
        }
    }
}

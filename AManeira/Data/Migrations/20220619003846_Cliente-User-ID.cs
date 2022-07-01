using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AManeira.Data.Migrations
{
    public partial class ClienteUserID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EncomendasPratos_Encomendas_ListaEncomendasId",
                table: "EncomendasPratos");

            migrationBuilder.DropForeignKey(
                name: "FK_EncomendasPratos_Pratos_ListaPratosId",
                table: "EncomendasPratos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EncomendasPratos",
                table: "EncomendasPratos");

            migrationBuilder.DropIndex(
                name: "IX_EncomendasPratos_ListaPratosId",
                table: "EncomendasPratos");

            migrationBuilder.RenameColumn(
                name: "ListaPratosId",
                table: "EncomendasPratos",
                newName: "Quantidade");

            migrationBuilder.RenameColumn(
                name: "ListaEncomendasId",
                table: "EncomendasPratos",
                newName: "PratoFK");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "EncomendasPratos",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "EncomendaFK",
                table: "EncomendasPratos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "Preco",
                table: "EncomendasPratos",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "UserID",
                table: "Clientes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_EncomendasPratos",
                table: "EncomendasPratos",
                column: "Id");

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

            migrationBuilder.CreateIndex(
                name: "IX_EncomendasPratos_EncomendaFK",
                table: "EncomendasPratos",
                column: "EncomendaFK");

            migrationBuilder.CreateIndex(
                name: "IX_EncomendasPratos_PratoFK",
                table: "EncomendasPratos",
                column: "PratoFK");

            migrationBuilder.AddForeignKey(
                name: "FK_EncomendasPratos_Encomendas_EncomendaFK",
                table: "EncomendasPratos",
                column: "EncomendaFK",
                principalTable: "Encomendas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EncomendasPratos_Pratos_PratoFK",
                table: "EncomendasPratos",
                column: "PratoFK",
                principalTable: "Pratos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EncomendasPratos_Encomendas_EncomendaFK",
                table: "EncomendasPratos");

            migrationBuilder.DropForeignKey(
                name: "FK_EncomendasPratos_Pratos_PratoFK",
                table: "EncomendasPratos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EncomendasPratos",
                table: "EncomendasPratos");

            migrationBuilder.DropIndex(
                name: "IX_EncomendasPratos_EncomendaFK",
                table: "EncomendasPratos");

            migrationBuilder.DropIndex(
                name: "IX_EncomendasPratos_PratoFK",
                table: "EncomendasPratos");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "EncomendasPratos");

            migrationBuilder.DropColumn(
                name: "EncomendaFK",
                table: "EncomendasPratos");

            migrationBuilder.DropColumn(
                name: "Preco",
                table: "EncomendasPratos");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Clientes");

            migrationBuilder.RenameColumn(
                name: "Quantidade",
                table: "EncomendasPratos",
                newName: "ListaPratosId");

            migrationBuilder.RenameColumn(
                name: "PratoFK",
                table: "EncomendasPratos",
                newName: "ListaEncomendasId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EncomendasPratos",
                table: "EncomendasPratos",
                columns: new[] { "ListaEncomendasId", "ListaPratosId" });

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

            migrationBuilder.CreateIndex(
                name: "IX_EncomendasPratos_ListaPratosId",
                table: "EncomendasPratos",
                column: "ListaPratosId");

            migrationBuilder.AddForeignKey(
                name: "FK_EncomendasPratos_Encomendas_ListaEncomendasId",
                table: "EncomendasPratos",
                column: "ListaEncomendasId",
                principalTable: "Encomendas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EncomendasPratos_Pratos_ListaPratosId",
                table: "EncomendasPratos",
                column: "ListaPratosId",
                principalTable: "Pratos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AManeira.Data.Migrations
{
    public partial class pratoscontrollerfinal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NumStock",
                table: "Pratos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumStock",
                table: "Pratos");
        }
    }
}

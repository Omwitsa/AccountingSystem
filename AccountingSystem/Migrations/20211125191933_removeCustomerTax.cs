using Microsoft.EntityFrameworkCore.Migrations;

namespace AccountingSystem.Migrations
{
    public partial class removeCustomerTax : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerTax",
                table: "VProducts");

            migrationBuilder.DropColumn(
                name: "VenderTax",
                table: "CProducts");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CustomerTax",
                table: "VProducts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VenderTax",
                table: "CProducts",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}

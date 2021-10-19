using Microsoft.EntityFrameworkCore.Migrations;

namespace AccountingSystem.Migrations
{
    public partial class Vpaymentstatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "VPayments",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "VPayments");
        }
    }
}

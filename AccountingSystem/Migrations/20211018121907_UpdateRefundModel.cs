using Microsoft.EntityFrameworkCore.Migrations;

namespace AccountingSystem.Migrations
{
    public partial class UpdateRefundModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BillRef",
                table: "VPayments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BillRef",
                table: "Refunds",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BillRef",
                table: "VPayments");

            migrationBuilder.DropColumn(
                name: "BillRef",
                table: "Refunds");
        }
    }
}

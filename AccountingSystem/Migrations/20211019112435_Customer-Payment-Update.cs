using Microsoft.EntityFrameworkCore.Migrations;

namespace AccountingSystem.Migrations
{
    public partial class CustomerPaymentUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Customer",
                table: "CPayments");

            migrationBuilder.DropColumn(
                name: "IsPayable",
                table: "CPayments");

            migrationBuilder.DropColumn(
                name: "IsReceivable",
                table: "CPayments");

            migrationBuilder.RenameColumn(
                name: "PartnerType",
                table: "CPayments",
                newName: "Vender");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Vender",
                table: "CPayments",
                newName: "PartnerType");

            migrationBuilder.AddColumn<string>(
                name: "Customer",
                table: "CPayments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsPayable",
                table: "CPayments",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsReceivable",
                table: "CPayments",
                type: "bit",
                nullable: true);
        }
    }
}

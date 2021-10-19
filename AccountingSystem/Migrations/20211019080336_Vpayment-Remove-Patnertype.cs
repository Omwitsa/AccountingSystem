using Microsoft.EntityFrameworkCore.Migrations;

namespace AccountingSystem.Migrations
{
    public partial class VpaymentRemovePatnertype : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPayable",
                table: "VPayments");

            migrationBuilder.DropColumn(
                name: "IsReceivable",
                table: "VPayments");

            migrationBuilder.DropColumn(
                name: "PartnerType",
                table: "VPayments");

            migrationBuilder.RenameColumn(
                name: "Vendor",
                table: "VPayments",
                newName: "Customer");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Customer",
                table: "VPayments",
                newName: "Vendor");

            migrationBuilder.AddColumn<bool>(
                name: "IsPayable",
                table: "VPayments",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsReceivable",
                table: "VPayments",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PartnerType",
                table: "VPayments",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}

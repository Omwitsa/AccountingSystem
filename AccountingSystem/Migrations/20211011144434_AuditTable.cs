using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AccountingSystem.Migrations
{
    public partial class AuditTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NotDepreciationVale",
                table: "Assets",
                newName: "NotDepreciationValue");

            migrationBuilder.RenameColumn(
                name: "DepreciationVale",
                table: "Assets",
                newName: "DepreciationValue");

            migrationBuilder.AddColumn<bool>(
                name: "Closed",
                table: "VProducts",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "VProducts",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "VProducts",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Personnel",
                table: "VProducts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "VPayments",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "VPayments",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Personnel",
                table: "VPayments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Closed",
                table: "Venders",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Venders",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Venders",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Personnel",
                table: "Venders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Taxs",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Taxs",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Personnel",
                table: "Taxs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Settings",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Settings",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Personnel",
                table: "Settings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Refunds",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Refunds",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Personnel",
                table: "Refunds",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "ReconciliationModels",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "ReconciliationModels",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Personnel",
                table: "ReconciliationModels",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "ProductCategories",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "ProductCategories",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Personnel",
                table: "ProductCategories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "LockDates",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "LockDates",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Personnel",
                table: "LockDates",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Closed",
                table: "Journals",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Journals",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Journals",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Personnel",
                table: "Journals",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "JournalEntries",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "JournalEntries",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Personnel",
                table: "JournalEntries",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "IPaymentTerms",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "IPaymentTerms",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Personnel",
                table: "IPaymentTerms",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "IPaymentFollowupLevels",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "IPaymentFollowupLevels",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Personnel",
                table: "IPaymentFollowupLevels",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "IncoTerms",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "IncoTerms",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Personnel",
                table: "IncoTerms",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "DefferredRevenues",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "DefferredRevenues",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Personnel",
                table: "DefferredRevenues",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "DefferredRevenueModels",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "DefferredRevenueModels",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Personnel",
                table: "DefferredRevenueModels",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "DefferredExpenses",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "DefferredExpenses",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Personnel",
                table: "DefferredExpenses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "DefferredExpenseModels",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "DefferredExpenseModels",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Personnel",
                table: "DefferredExpenseModels",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Closed",
                table: "Customers",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Customers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Customers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Personnel",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "CreditNotes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "CreditNotes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Personnel",
                table: "CreditNotes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Closed",
                table: "CProducts",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "CProducts",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "CProducts",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Personnel",
                table: "CProducts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "CPayments",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "CPayments",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Personnel",
                table: "CPayments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "CInvoices",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "CInvoices",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Personnel",
                table: "CInvoices",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Bills",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Bills",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Personnel",
                table: "Bills",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Closed",
                table: "Banks",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Banks",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Banks",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Personnel",
                table: "Banks",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "AutoTransfers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "AutoTransfers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Personnel",
                table: "AutoTransfers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Closed",
                table: "Assets",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Assets",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Assets",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Personnel",
                table: "Assets",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "AssetModels",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "AssetModels",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Personnel",
                table: "AssetModels",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Closed",
                table: "AccountCharts",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "AccountCharts",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "AccountCharts",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Personnel",
                table: "AccountCharts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Audits",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Reference = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModuleId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Audits", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Audits");

            migrationBuilder.DropColumn(
                name: "Closed",
                table: "VProducts");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "VProducts");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "VProducts");

            migrationBuilder.DropColumn(
                name: "Personnel",
                table: "VProducts");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "VPayments");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "VPayments");

            migrationBuilder.DropColumn(
                name: "Personnel",
                table: "VPayments");

            migrationBuilder.DropColumn(
                name: "Closed",
                table: "Venders");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Venders");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Venders");

            migrationBuilder.DropColumn(
                name: "Personnel",
                table: "Venders");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Taxs");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Taxs");

            migrationBuilder.DropColumn(
                name: "Personnel",
                table: "Taxs");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "Personnel",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Refunds");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Refunds");

            migrationBuilder.DropColumn(
                name: "Personnel",
                table: "Refunds");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "ReconciliationModels");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "ReconciliationModels");

            migrationBuilder.DropColumn(
                name: "Personnel",
                table: "ReconciliationModels");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "ProductCategories");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "ProductCategories");

            migrationBuilder.DropColumn(
                name: "Personnel",
                table: "ProductCategories");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "LockDates");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "LockDates");

            migrationBuilder.DropColumn(
                name: "Personnel",
                table: "LockDates");

            migrationBuilder.DropColumn(
                name: "Closed",
                table: "Journals");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Journals");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Journals");

            migrationBuilder.DropColumn(
                name: "Personnel",
                table: "Journals");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "JournalEntries");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "JournalEntries");

            migrationBuilder.DropColumn(
                name: "Personnel",
                table: "JournalEntries");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "IPaymentTerms");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "IPaymentTerms");

            migrationBuilder.DropColumn(
                name: "Personnel",
                table: "IPaymentTerms");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "IPaymentFollowupLevels");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "IPaymentFollowupLevels");

            migrationBuilder.DropColumn(
                name: "Personnel",
                table: "IPaymentFollowupLevels");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "IncoTerms");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "IncoTerms");

            migrationBuilder.DropColumn(
                name: "Personnel",
                table: "IncoTerms");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "DefferredRevenues");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "DefferredRevenues");

            migrationBuilder.DropColumn(
                name: "Personnel",
                table: "DefferredRevenues");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "DefferredRevenueModels");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "DefferredRevenueModels");

            migrationBuilder.DropColumn(
                name: "Personnel",
                table: "DefferredRevenueModels");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "DefferredExpenses");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "DefferredExpenses");

            migrationBuilder.DropColumn(
                name: "Personnel",
                table: "DefferredExpenses");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "DefferredExpenseModels");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "DefferredExpenseModels");

            migrationBuilder.DropColumn(
                name: "Personnel",
                table: "DefferredExpenseModels");

            migrationBuilder.DropColumn(
                name: "Closed",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Personnel",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "CreditNotes");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "CreditNotes");

            migrationBuilder.DropColumn(
                name: "Personnel",
                table: "CreditNotes");

            migrationBuilder.DropColumn(
                name: "Closed",
                table: "CProducts");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "CProducts");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "CProducts");

            migrationBuilder.DropColumn(
                name: "Personnel",
                table: "CProducts");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "CPayments");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "CPayments");

            migrationBuilder.DropColumn(
                name: "Personnel",
                table: "CPayments");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "CInvoices");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "CInvoices");

            migrationBuilder.DropColumn(
                name: "Personnel",
                table: "CInvoices");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Bills");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Bills");

            migrationBuilder.DropColumn(
                name: "Personnel",
                table: "Bills");

            migrationBuilder.DropColumn(
                name: "Closed",
                table: "Banks");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Banks");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Banks");

            migrationBuilder.DropColumn(
                name: "Personnel",
                table: "Banks");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "AutoTransfers");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "AutoTransfers");

            migrationBuilder.DropColumn(
                name: "Personnel",
                table: "AutoTransfers");

            migrationBuilder.DropColumn(
                name: "Closed",
                table: "Assets");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Assets");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Assets");

            migrationBuilder.DropColumn(
                name: "Personnel",
                table: "Assets");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "AssetModels");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "AssetModels");

            migrationBuilder.DropColumn(
                name: "Personnel",
                table: "AssetModels");

            migrationBuilder.DropColumn(
                name: "Closed",
                table: "AccountCharts");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "AccountCharts");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "AccountCharts");

            migrationBuilder.DropColumn(
                name: "Personnel",
                table: "AccountCharts");

            migrationBuilder.RenameColumn(
                name: "NotDepreciationValue",
                table: "Assets",
                newName: "NotDepreciationVale");

            migrationBuilder.RenameColumn(
                name: "DepreciationValue",
                table: "Assets",
                newName: "DepreciationVale");
        }
    }
}

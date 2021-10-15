using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AccountingSystem.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccountCharts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AllowReconciliation = table.Column<bool>(type: "bit", nullable: true),
                    DefaultTax = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AllowJournal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tag = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Closed = table.Column<bool>(type: "bit", nullable: true),
                    Personnel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountCharts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AssetModels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GlAccount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DepreciationMethod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DepreciationDuration = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DepreciationGlAccount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExpenseGlAccount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Journal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Personnel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Assets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OriginalValue = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    AcquisitionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NotDepreciationValue = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DepreciationValue = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    BookValue = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DepreciationMethod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DepreciationDuration = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDepreciation = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AssetGlAccount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DepreciationGlAccount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExpenseGlAccount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Journal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Closed = table.Column<bool>(type: "bit", nullable: true),
                    Personnel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assets", x => x.Id);
                });

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

            migrationBuilder.CreateTable(
                name: "AutoTransfers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    From = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    To = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Journal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Frequency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Personnel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutoTransfers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Banks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdentifierCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Closed = table.Column<bool>(type: "bit", nullable: true),
                    Personnel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bills",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Vender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ref = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Journal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RecipientBank = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IncoTerm = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FiscalPosition = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Personnel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bills", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CInvoices",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Customer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ref = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Journal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SalesPerson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RecipientBank = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IncoTerm = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FiscalPosition = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Personnel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CInvoices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CPayments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsPayable = table.Column<bool>(type: "bit", nullable: true),
                    IsReceivable = table.Column<bool>(type: "bit", nullable: true),
                    PartnerType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Customer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GlAccount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsInternalTransfer = table.Column<bool>(type: "bit", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Memo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Journal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BankAccount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Personnel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CPayments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CProducts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ref = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BarCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CustomerTax = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cost = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VenderTax = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ARGlAccount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    APGlAccount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Closed = table.Column<bool>(type: "bit", nullable: true),
                    Personnel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CProducts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CreditNotes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Customer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ref = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvoiceDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Journal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SalesPerson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReceipientBank = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IncoTerm = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FiscalPosition = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Personnel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditNotes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Street1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Street2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WebSite = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SalesPerson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PurchasePaymentTerms = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SalesPaymentTerms = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FiscalPosition = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ARGlAccount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    APGlAccount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bank = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Closed = table.Column<bool>(type: "bit", nullable: true),
                    Personnel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DefferredExpenseModels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GlAccount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DepreciationMethod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DepreciationDuration = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DepreciationGlAccount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RevenueGlAccount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Journal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Personnel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DefferredExpenseModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DefferredExpenses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OriginalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    AcquisitionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ResidualAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DefferredAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    RecognitionMonths = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RecognitionYears = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstRecognitionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ExpenseGlAccount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeferredGlAccount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Journal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Personnel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DefferredExpenses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DefferredRevenueModels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GlAccount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DepreciationMethod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DepreciationDuration = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DepreciationGlAccount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RevenueGlAccount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Journal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Personnel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DefferredRevenueModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DefferredRevenues",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OriginalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    AcquisitionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ResidualAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DefferredAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    RecognitionMonths = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RecognitionYears = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstRecognitionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RevenueGlAccount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeferredGlAccount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Journal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Personnel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DefferredRevenues", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IncoTerms",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Personnel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IncoTerms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IPaymentFollowupLevels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Level = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Personnel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IPaymentFollowupLevels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IPaymentTerms",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Term = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Personnel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IPaymentTerms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JournalEntries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    No = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Partner = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ref = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Journal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Personnel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JournalEntries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Journals",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Closed = table.Column<bool>(type: "bit", nullable: true),
                    Personnel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Journals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LockDates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NonAdvisor = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AllUsers = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Tax = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Personnel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LockDates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParentCategory = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IncomeGlAccount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExpenseGlAccount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Closed = table.Column<bool>(type: "bit", nullable: true),
                    Personnel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReconciliationModels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Journal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Personnel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReconciliationModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Refunds",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Vendor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ref = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BillDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Journal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReceipientBank = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IncoTerm = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FiscalPosition = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Personnel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Refunds", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Settings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SalesTax = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PurchaseTax = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Periodicity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Reminder = table.Column<int>(type: "int", nullable: false),
                    Journal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoundingMethod = table.Column<int>(type: "int", nullable: false),
                    FiscalCountry = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MainCurrency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MultiCurrency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FiscalPeriod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Personnel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Taxes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Computation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Scope = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Closed = table.Column<bool>(type: "bit", nullable: true),
                    Personnel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Taxes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Venders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Street1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Street2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WebSite = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SalesPerson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PurchasePaymentTerms = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SalesPaymentTerms = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FiscalPosition = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ref = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Industry = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ARGlAccount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    APGlAccount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bank = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Closed = table.Column<bool>(type: "bit", nullable: true),
                    Personnel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Venders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VPayments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsPayable = table.Column<bool>(type: "bit", nullable: true),
                    IsReceivable = table.Column<bool>(type: "bit", nullable: true),
                    PartnerType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Vendor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GlAccount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsInternalTransfer = table.Column<bool>(type: "bit", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Memo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Journal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BankAccount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Personnel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VPayments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VProducts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ref = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BarCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CustomerTax = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cost = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VenderTax = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ARGlAccount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    APGlAccount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Closed = table.Column<bool>(type: "bit", nullable: true),
                    Personnel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VProducts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DepreciationBoards",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AssetId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Ref = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DepreciationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Depreciation = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CumulativeDepreciation = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DepreciableValue = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    journalEntry = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepreciationBoards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DepreciationBoards_Assets_AssetId",
                        column: x => x.AssetId,
                        principalTable: "Assets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OriginalAccounts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AutoTransferId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GlAccount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GlAccountType = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OriginalAccounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OriginalAccounts_AutoTransfers_AutoTransferId",
                        column: x => x.AutoTransferId,
                        principalTable: "AutoTransfers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TransferredToAccounts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AutoTransferId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Percentage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Partner = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GlAccount = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransferredToAccounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TransferredToAccounts_AutoTransfers_AutoTransferId",
                        column: x => x.AutoTransferId,
                        principalTable: "AutoTransfers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BillDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BillId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Product = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Label = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GlAccount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Tax = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BillDetails_Bills_BillId",
                        column: x => x.BillId,
                        principalTable: "Bills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BillJournals",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BillId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    GlAccount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Label = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Debit = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Credit = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillJournals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BillJournals_Bills_BillId",
                        column: x => x.BillId,
                        principalTable: "Bills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CInvoiceDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CInvoiceId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Product = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Label = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GlAccount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Tax = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CInvoiceDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CInvoiceDetails_CInvoices_CInvoiceId",
                        column: x => x.CInvoiceId,
                        principalTable: "CInvoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CInvoiceJournal",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CInvoiceId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    GlAccount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Label = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Debit = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Credit = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CInvoiceJournal", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CInvoiceJournal_CInvoices_CInvoiceId",
                        column: x => x.CInvoiceId,
                        principalTable: "CInvoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CreditNoteDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreditNoteId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Product = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Lable = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GlAccount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Tax = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditNoteDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CreditNoteDetails_CreditNotes_CreditNoteId",
                        column: x => x.CreditNoteId,
                        principalTable: "CreditNotes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CreditNoteJournals",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreditNoteId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    GlAccount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Label = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Debit = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Credit = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditNoteJournals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CreditNoteJournals_CreditNotes_CreditNoteId",
                        column: x => x.CreditNoteId,
                        principalTable: "CreditNotes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ExpenseBoards",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DefferredExpenseId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Ref = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExpenseDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Expense = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CummulativeExpense = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    NextPeriodExpense = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    JournalEntry = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpenseBoards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExpenseBoards_DefferredExpenses_DefferredExpenseId",
                        column: x => x.DefferredExpenseId,
                        principalTable: "DefferredExpenses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RevenueBoards",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DefferredRevenueId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Ref = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RevenueDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Revenue = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CummulativeRevenue = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    NextPeriodRevenue = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    JournalEntry = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RevenueBoards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RevenueBoards_DefferredRevenues_DefferredRevenueId",
                        column: x => x.DefferredRevenueId,
                        principalTable: "DefferredRevenues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RefundDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RefundId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Product = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Lable = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GlAccount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Tax = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefundDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefundDetails_Refunds_RefundId",
                        column: x => x.RefundId,
                        principalTable: "Refunds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RefundJournals",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RefundId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    GlAccount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Label = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Debit = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Credit = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefundJournals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefundJournals_Refunds_RefundId",
                        column: x => x.RefundId,
                        principalTable: "Refunds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BillDetails_BillId",
                table: "BillDetails",
                column: "BillId");

            migrationBuilder.CreateIndex(
                name: "IX_BillJournals_BillId",
                table: "BillJournals",
                column: "BillId");

            migrationBuilder.CreateIndex(
                name: "IX_CInvoiceDetails_CInvoiceId",
                table: "CInvoiceDetails",
                column: "CInvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_CInvoiceJournal_CInvoiceId",
                table: "CInvoiceJournal",
                column: "CInvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_CreditNoteDetails_CreditNoteId",
                table: "CreditNoteDetails",
                column: "CreditNoteId");

            migrationBuilder.CreateIndex(
                name: "IX_CreditNoteJournals_CreditNoteId",
                table: "CreditNoteJournals",
                column: "CreditNoteId");

            migrationBuilder.CreateIndex(
                name: "IX_DepreciationBoards_AssetId",
                table: "DepreciationBoards",
                column: "AssetId");

            migrationBuilder.CreateIndex(
                name: "IX_ExpenseBoards_DefferredExpenseId",
                table: "ExpenseBoards",
                column: "DefferredExpenseId");

            migrationBuilder.CreateIndex(
                name: "IX_OriginalAccounts_AutoTransferId",
                table: "OriginalAccounts",
                column: "AutoTransferId");

            migrationBuilder.CreateIndex(
                name: "IX_RefundDetails_RefundId",
                table: "RefundDetails",
                column: "RefundId");

            migrationBuilder.CreateIndex(
                name: "IX_RefundJournals_RefundId",
                table: "RefundJournals",
                column: "RefundId");

            migrationBuilder.CreateIndex(
                name: "IX_RevenueBoards_DefferredRevenueId",
                table: "RevenueBoards",
                column: "DefferredRevenueId");

            migrationBuilder.CreateIndex(
                name: "IX_TransferredToAccounts_AutoTransferId",
                table: "TransferredToAccounts",
                column: "AutoTransferId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountCharts");

            migrationBuilder.DropTable(
                name: "AssetModels");

            migrationBuilder.DropTable(
                name: "Audits");

            migrationBuilder.DropTable(
                name: "Banks");

            migrationBuilder.DropTable(
                name: "BillDetails");

            migrationBuilder.DropTable(
                name: "BillJournals");

            migrationBuilder.DropTable(
                name: "CInvoiceDetails");

            migrationBuilder.DropTable(
                name: "CInvoiceJournal");

            migrationBuilder.DropTable(
                name: "CPayments");

            migrationBuilder.DropTable(
                name: "CProducts");

            migrationBuilder.DropTable(
                name: "CreditNoteDetails");

            migrationBuilder.DropTable(
                name: "CreditNoteJournals");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "DefferredExpenseModels");

            migrationBuilder.DropTable(
                name: "DefferredRevenueModels");

            migrationBuilder.DropTable(
                name: "DepreciationBoards");

            migrationBuilder.DropTable(
                name: "ExpenseBoards");

            migrationBuilder.DropTable(
                name: "IncoTerms");

            migrationBuilder.DropTable(
                name: "IPaymentFollowupLevels");

            migrationBuilder.DropTable(
                name: "IPaymentTerms");

            migrationBuilder.DropTable(
                name: "JournalEntries");

            migrationBuilder.DropTable(
                name: "Journals");

            migrationBuilder.DropTable(
                name: "LockDates");

            migrationBuilder.DropTable(
                name: "OriginalAccounts");

            migrationBuilder.DropTable(
                name: "ProductCategories");

            migrationBuilder.DropTable(
                name: "ReconciliationModels");

            migrationBuilder.DropTable(
                name: "RefundDetails");

            migrationBuilder.DropTable(
                name: "RefundJournals");

            migrationBuilder.DropTable(
                name: "RevenueBoards");

            migrationBuilder.DropTable(
                name: "Settings");

            migrationBuilder.DropTable(
                name: "Taxes");

            migrationBuilder.DropTable(
                name: "TransferredToAccounts");

            migrationBuilder.DropTable(
                name: "Venders");

            migrationBuilder.DropTable(
                name: "VPayments");

            migrationBuilder.DropTable(
                name: "VProducts");

            migrationBuilder.DropTable(
                name: "Bills");

            migrationBuilder.DropTable(
                name: "CInvoices");

            migrationBuilder.DropTable(
                name: "CreditNotes");

            migrationBuilder.DropTable(
                name: "Assets");

            migrationBuilder.DropTable(
                name: "DefferredExpenses");

            migrationBuilder.DropTable(
                name: "Refunds");

            migrationBuilder.DropTable(
                name: "DefferredRevenues");

            migrationBuilder.DropTable(
                name: "AutoTransfers");
        }
    }
}

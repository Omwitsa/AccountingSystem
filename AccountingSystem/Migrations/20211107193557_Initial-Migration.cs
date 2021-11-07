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
                    Id = table.Column<Guid>(nullable: false),
                    Code = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    AllowReconciliation = table.Column<bool>(nullable: true),
                    DefaultTax = table.Column<string>(nullable: true),
                    AllowJournal = table.Column<string>(nullable: true),
                    Tag = table.Column<string>(nullable: true),
                    Closed = table.Column<bool>(nullable: true),
                    Personnel = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountCharts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AssetModels",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    GlAccount = table.Column<string>(nullable: true),
                    DepreciationMethod = table.Column<string>(nullable: true),
                    DepreciationDuration = table.Column<string>(nullable: true),
                    DepreciationGlAccount = table.Column<string>(nullable: true),
                    ExpenseGlAccount = table.Column<string>(nullable: true),
                    Journal = table.Column<string>(nullable: true),
                    Personnel = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Assets",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    OriginalValue = table.Column<decimal>(nullable: true),
                    AcquisitionDate = table.Column<DateTime>(nullable: true),
                    NotDepreciationValue = table.Column<decimal>(nullable: true),
                    DepreciationValue = table.Column<decimal>(nullable: true),
                    BookValue = table.Column<decimal>(nullable: true),
                    DepreciationMethod = table.Column<string>(nullable: true),
                    DepreciationDuration = table.Column<string>(nullable: true),
                    StartDepreciation = table.Column<DateTime>(nullable: true),
                    AssetGlAccount = table.Column<string>(nullable: true),
                    DepreciationGlAccount = table.Column<string>(nullable: true),
                    ExpenseGlAccount = table.Column<string>(nullable: true),
                    Journal = table.Column<string>(nullable: true),
                    Closed = table.Column<bool>(nullable: true),
                    Personnel = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Audits",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: true),
                    Reference = table.Column<string>(nullable: true),
                    ModuleId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Audits", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AutoTransfers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    From = table.Column<DateTime>(nullable: true),
                    To = table.Column<DateTime>(nullable: true),
                    Journal = table.Column<string>(nullable: true),
                    Frequency = table.Column<string>(nullable: true),
                    Personnel = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutoTransfers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Banks",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AccNo = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    IdentifierCode = table.Column<string>(nullable: true),
                    Closed = table.Column<bool>(nullable: true),
                    Personnel = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bills",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Vender = table.Column<string>(nullable: true),
                    Ref = table.Column<string>(nullable: true),
                    Remarks = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: true),
                    DueDate = table.Column<DateTime>(nullable: true),
                    Journal = table.Column<string>(nullable: true),
                    PaymentReference = table.Column<string>(nullable: true),
                    NetAmount = table.Column<decimal>(nullable: true),
                    Tax = table.Column<decimal>(nullable: true),
                    TotalAmount = table.Column<decimal>(nullable: true),
                    Arrears = table.Column<decimal>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    RecipientBank = table.Column<string>(nullable: true),
                    IncoTerm = table.Column<string>(nullable: true),
                    FiscalPosition = table.Column<string>(nullable: true),
                    Personnel = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bills", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CInvoices",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Customer = table.Column<string>(nullable: true),
                    Ref = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: true),
                    DueDate = table.Column<DateTime>(nullable: true),
                    Journal = table.Column<string>(nullable: true),
                    NetAmount = table.Column<decimal>(nullable: true),
                    Tax = table.Column<decimal>(nullable: true),
                    TotalAmount = table.Column<decimal>(nullable: true),
                    Arrears = table.Column<decimal>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    PaymentReference = table.Column<string>(nullable: true),
                    SalesPerson = table.Column<string>(nullable: true),
                    RecipientBank = table.Column<string>(nullable: true),
                    IncoTerm = table.Column<string>(nullable: true),
                    FiscalPosition = table.Column<string>(nullable: true),
                    Personnel = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CInvoices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CPayments",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Customer = table.Column<string>(nullable: true),
                    GlAccount = table.Column<string>(nullable: true),
                    IsInternalTransfer = table.Column<bool>(nullable: true),
                    Amount = table.Column<decimal>(nullable: true),
                    Date = table.Column<DateTime>(nullable: true),
                    Memo = table.Column<string>(nullable: true),
                    Journal = table.Column<string>(nullable: true),
                    BankAccount = table.Column<string>(nullable: true),
                    Personnel = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CPayments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CProducts",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    Category = table.Column<string>(nullable: true),
                    Ref = table.Column<string>(nullable: true),
                    BarCode = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: true),
                    CustomerTax = table.Column<string>(nullable: true),
                    Cost = table.Column<decimal>(nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    VenderTax = table.Column<string>(nullable: true),
                    ARGlAccount = table.Column<string>(nullable: true),
                    APGlAccount = table.Column<string>(nullable: true),
                    Closed = table.Column<bool>(nullable: true),
                    Personnel = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CProducts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CreditNotes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Customer = table.Column<string>(nullable: true),
                    Ref = table.Column<string>(nullable: true),
                    InvoiceDate = table.Column<DateTime>(nullable: true),
                    DueDate = table.Column<DateTime>(nullable: true),
                    Journal = table.Column<string>(nullable: true),
                    PaymentReference = table.Column<string>(nullable: true),
                    NetAmount = table.Column<decimal>(nullable: true),
                    Tax = table.Column<decimal>(nullable: true),
                    TotalAmount = table.Column<decimal>(nullable: true),
                    Arrears = table.Column<decimal>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    SalesPerson = table.Column<string>(nullable: true),
                    ReceipientBank = table.Column<string>(nullable: true),
                    IncoTerm = table.Column<string>(nullable: true),
                    FiscalPosition = table.Column<string>(nullable: true),
                    Personnel = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditNotes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Street1 = table.Column<string>(nullable: true),
                    Street2 = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    Zip = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    PhoneNo = table.Column<string>(nullable: true),
                    Mobile = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    WebSite = table.Column<string>(nullable: true),
                    SalesPerson = table.Column<string>(nullable: true),
                    PurchasePaymentTerms = table.Column<string>(nullable: true),
                    SalesPaymentTerms = table.Column<string>(nullable: true),
                    FiscalPosition = table.Column<string>(nullable: true),
                    ARGlAccount = table.Column<string>(nullable: true),
                    Bank = table.Column<string>(nullable: true),
                    Tags = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    Closed = table.Column<bool>(nullable: true),
                    Personnel = table.Column<string>(nullable: true),
                    Reference = table.Column<string>(nullable: true),
                    industry = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DefferredExpenseModels",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    GlAccount = table.Column<string>(nullable: true),
                    DepreciationMethod = table.Column<string>(nullable: true),
                    DepreciationDuration = table.Column<string>(nullable: true),
                    DepreciationGlAccount = table.Column<string>(nullable: true),
                    RevenueGlAccount = table.Column<string>(nullable: true),
                    Journal = table.Column<string>(nullable: true),
                    Personnel = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DefferredExpenseModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DefferredExpenses",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    OriginalAmount = table.Column<decimal>(nullable: true),
                    AcquisitionDate = table.Column<DateTime>(nullable: true),
                    ResidualAmount = table.Column<decimal>(nullable: true),
                    DefferredAmount = table.Column<decimal>(nullable: true),
                    RecognitionMonths = table.Column<string>(nullable: true),
                    RecognitionYears = table.Column<string>(nullable: true),
                    FirstRecognitionDate = table.Column<DateTime>(nullable: true),
                    ExpenseGlAccount = table.Column<string>(nullable: true),
                    DeferredGlAccount = table.Column<string>(nullable: true),
                    Journal = table.Column<string>(nullable: true),
                    Personnel = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DefferredExpenses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DefferredRevenueModels",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    GlAccount = table.Column<string>(nullable: true),
                    DepreciationMethod = table.Column<string>(nullable: true),
                    DepreciationDuration = table.Column<string>(nullable: true),
                    DepreciationGlAccount = table.Column<string>(nullable: true),
                    RevenueGlAccount = table.Column<string>(nullable: true),
                    Journal = table.Column<string>(nullable: true),
                    Personnel = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DefferredRevenueModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DefferredRevenues",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    OriginalAmount = table.Column<decimal>(nullable: true),
                    AcquisitionDate = table.Column<DateTime>(nullable: true),
                    ResidualAmount = table.Column<decimal>(nullable: true),
                    DefferredAmount = table.Column<decimal>(nullable: true),
                    RecognitionMonths = table.Column<string>(nullable: true),
                    RecognitionYears = table.Column<string>(nullable: true),
                    FirstRecognitionDate = table.Column<DateTime>(nullable: true),
                    RevenueGlAccount = table.Column<string>(nullable: true),
                    DeferredGlAccount = table.Column<string>(nullable: true),
                    Journal = table.Column<string>(nullable: true),
                    Personnel = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DefferredRevenues", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IncoTerms",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Code = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Personnel = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IncoTerms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IPaymentFollowupLevels",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Level = table.Column<string>(nullable: true),
                    Personnel = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IPaymentFollowupLevels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IPaymentTerms",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Term = table.Column<string>(nullable: true),
                    Personnel = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IPaymentTerms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JournalEntries",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Date = table.Column<DateTime>(nullable: true),
                    No = table.Column<string>(nullable: true),
                    Partner = table.Column<string>(nullable: true),
                    Ref = table.Column<string>(nullable: true),
                    Journal = table.Column<string>(nullable: true),
                    Total = table.Column<decimal>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Personnel = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JournalEntries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Journals",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    Closed = table.Column<bool>(nullable: true),
                    Personnel = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Journals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LockDates",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    NonAdvisor = table.Column<DateTime>(nullable: true),
                    AllUsers = table.Column<DateTime>(nullable: true),
                    Tax = table.Column<DateTime>(nullable: true),
                    Personnel = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LockDates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    ParentCategory = table.Column<string>(nullable: true),
                    IncomeGlAccount = table.Column<string>(nullable: true),
                    ExpenseGlAccount = table.Column<string>(nullable: true),
                    Closed = table.Column<bool>(nullable: true),
                    Personnel = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReconciliationModels",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    Journal = table.Column<string>(nullable: true),
                    Personnel = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReconciliationModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Refunds",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Ref = table.Column<string>(nullable: true),
                    Vendor = table.Column<string>(nullable: true),
                    BillDate = table.Column<DateTime>(nullable: true),
                    DueDate = table.Column<DateTime>(nullable: true),
                    Journal = table.Column<string>(nullable: true),
                    PaymentReference = table.Column<string>(nullable: true),
                    PaymentTerms = table.Column<string>(nullable: true),
                    NetAmount = table.Column<decimal>(nullable: true),
                    Tax = table.Column<decimal>(nullable: true),
                    TotalAmount = table.Column<decimal>(nullable: true),
                    Arrears = table.Column<decimal>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    ReceipientBank = table.Column<string>(nullable: true),
                    IncoTerm = table.Column<string>(nullable: true),
                    FiscalPosition = table.Column<string>(nullable: true),
                    Personnel = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Refunds", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Settings",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    SalesTax = table.Column<string>(nullable: true),
                    PurchaseTax = table.Column<string>(nullable: true),
                    Periodicity = table.Column<string>(nullable: true),
                    Reminder = table.Column<int>(nullable: false),
                    Journal = table.Column<string>(nullable: true),
                    RoundingMethod = table.Column<int>(nullable: false),
                    FiscalCountry = table.Column<string>(nullable: true),
                    MainCurrency = table.Column<string>(nullable: true),
                    MultiCurrency = table.Column<string>(nullable: true),
                    FiscalPeriod = table.Column<string>(nullable: true),
                    Personnel = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Taxes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    Computation = table.Column<string>(nullable: true),
                    GlAccount = table.Column<string>(nullable: true),
                    Rate = table.Column<decimal>(nullable: true),
                    Scope = table.Column<string>(nullable: true),
                    Closed = table.Column<bool>(nullable: true),
                    Personnel = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Taxes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Venders",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Street1 = table.Column<string>(nullable: true),
                    Street2 = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    PhoneNo = table.Column<string>(nullable: true),
                    Mobile = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    WebSite = table.Column<string>(nullable: true),
                    SalesPerson = table.Column<string>(nullable: true),
                    PurchasePaymentTerms = table.Column<string>(nullable: true),
                    SalesPaymentTerms = table.Column<string>(nullable: true),
                    FiscalPosition = table.Column<string>(nullable: true),
                    Ref = table.Column<string>(nullable: true),
                    Industry = table.Column<string>(nullable: true),
                    APGlAccount = table.Column<string>(nullable: true),
                    Bank = table.Column<string>(nullable: true),
                    BankAccount = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    Closed = table.Column<bool>(nullable: true),
                    Personnel = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Venders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VPayments",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    BillRef = table.Column<string>(nullable: true),
                    Vender = table.Column<string>(nullable: true),
                    GlAccount = table.Column<string>(nullable: true),
                    IsInternalTransfer = table.Column<bool>(nullable: true),
                    Amount = table.Column<decimal>(nullable: true),
                    Date = table.Column<DateTime>(nullable: true),
                    Memo = table.Column<string>(nullable: true),
                    Journal = table.Column<string>(nullable: true),
                    BankAccount = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Personnel = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VPayments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VProducts",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    Category = table.Column<string>(nullable: true),
                    Ref = table.Column<string>(nullable: true),
                    BarCode = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: true),
                    CustomerTax = table.Column<string>(nullable: true),
                    Cost = table.Column<decimal>(nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    VenderTax = table.Column<string>(nullable: true),
                    ARGlAccount = table.Column<string>(nullable: true),
                    APGlAccount = table.Column<string>(nullable: true),
                    Closed = table.Column<bool>(nullable: true),
                    Personnel = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VProducts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DepreciationBoards",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AssetId = table.Column<Guid>(nullable: true),
                    Ref = table.Column<string>(nullable: true),
                    DepreciationDate = table.Column<DateTime>(nullable: true),
                    Depreciation = table.Column<decimal>(nullable: true),
                    CumulativeDepreciation = table.Column<decimal>(nullable: true),
                    DepreciableValue = table.Column<decimal>(nullable: true),
                    journalEntry = table.Column<string>(nullable: true)
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
                    Id = table.Column<Guid>(nullable: false),
                    AutoTransferId = table.Column<Guid>(nullable: true),
                    Code = table.Column<string>(nullable: true),
                    GlAccount = table.Column<string>(nullable: true),
                    GlAccountType = table.Column<string>(nullable: true)
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
                    Id = table.Column<Guid>(nullable: false),
                    AutoTransferId = table.Column<Guid>(nullable: true),
                    Percentage = table.Column<string>(nullable: true),
                    Partner = table.Column<string>(nullable: true),
                    GlAccount = table.Column<string>(nullable: true)
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
                    Id = table.Column<Guid>(nullable: false),
                    BillId = table.Column<Guid>(nullable: true),
                    Product = table.Column<string>(nullable: true),
                    Label = table.Column<string>(nullable: true),
                    GlAccount = table.Column<string>(nullable: true),
                    Quantity = table.Column<decimal>(nullable: true),
                    Price = table.Column<decimal>(nullable: true),
                    Tax = table.Column<string>(nullable: true),
                    SubTotal = table.Column<decimal>(nullable: true)
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
                    Id = table.Column<Guid>(nullable: false),
                    BillId = table.Column<Guid>(nullable: true),
                    GlAccount = table.Column<string>(nullable: true),
                    Label = table.Column<string>(nullable: true),
                    Debit = table.Column<decimal>(nullable: true),
                    Credit = table.Column<decimal>(nullable: true)
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
                    Id = table.Column<Guid>(nullable: false),
                    CInvoiceId = table.Column<Guid>(nullable: true),
                    Product = table.Column<string>(nullable: true),
                    Label = table.Column<string>(nullable: true),
                    GlAccount = table.Column<string>(nullable: true),
                    Quantity = table.Column<decimal>(nullable: true),
                    Price = table.Column<decimal>(nullable: true),
                    Tax = table.Column<string>(nullable: true),
                    SubTotal = table.Column<decimal>(nullable: true)
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
                    Id = table.Column<Guid>(nullable: false),
                    CInvoiceId = table.Column<Guid>(nullable: true),
                    GlAccount = table.Column<string>(nullable: true),
                    Label = table.Column<string>(nullable: true),
                    Debit = table.Column<decimal>(nullable: true),
                    Credit = table.Column<decimal>(nullable: true)
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
                    Id = table.Column<Guid>(nullable: false),
                    CreditNoteId = table.Column<Guid>(nullable: true),
                    Product = table.Column<string>(nullable: true),
                    Lable = table.Column<string>(nullable: true),
                    GlAccount = table.Column<string>(nullable: true),
                    Quantity = table.Column<decimal>(nullable: true),
                    Price = table.Column<decimal>(nullable: true),
                    Tax = table.Column<string>(nullable: true),
                    SubTotal = table.Column<decimal>(nullable: true)
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
                    Id = table.Column<Guid>(nullable: false),
                    CreditNoteId = table.Column<Guid>(nullable: true),
                    GlAccount = table.Column<string>(nullable: true),
                    Label = table.Column<string>(nullable: true),
                    Debit = table.Column<decimal>(nullable: true),
                    Credit = table.Column<decimal>(nullable: true)
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
                    Id = table.Column<Guid>(nullable: false),
                    DefferredExpenseId = table.Column<Guid>(nullable: true),
                    Ref = table.Column<string>(nullable: true),
                    ExpenseDate = table.Column<DateTime>(nullable: true),
                    Expense = table.Column<decimal>(nullable: true),
                    CummulativeExpense = table.Column<decimal>(nullable: true),
                    NextPeriodExpense = table.Column<decimal>(nullable: true),
                    JournalEntry = table.Column<string>(nullable: true)
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
                    Id = table.Column<Guid>(nullable: false),
                    DefferredRevenueId = table.Column<Guid>(nullable: true),
                    Ref = table.Column<string>(nullable: true),
                    RevenueDate = table.Column<DateTime>(nullable: true),
                    Revenue = table.Column<decimal>(nullable: true),
                    CummulativeRevenue = table.Column<decimal>(nullable: true),
                    NextPeriodRevenue = table.Column<decimal>(nullable: true),
                    JournalEntry = table.Column<string>(nullable: true)
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
                    Id = table.Column<Guid>(nullable: false),
                    RefundId = table.Column<Guid>(nullable: true),
                    Product = table.Column<string>(nullable: true),
                    Lable = table.Column<string>(nullable: true),
                    GlAccount = table.Column<string>(nullable: true),
                    Quantity = table.Column<decimal>(nullable: true),
                    Price = table.Column<decimal>(nullable: true),
                    Tax = table.Column<string>(nullable: true),
                    SubTotal = table.Column<decimal>(nullable: true)
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
                    Id = table.Column<Guid>(nullable: false),
                    RefundId = table.Column<Guid>(nullable: true),
                    GlAccount = table.Column<string>(nullable: true),
                    Label = table.Column<string>(nullable: true),
                    Debit = table.Column<decimal>(nullable: true),
                    Credit = table.Column<decimal>(nullable: true)
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
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

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
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

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
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

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

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InsuranceSolution.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Insurer",
                columns: table => new
                {
                    InsurerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InsurerName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    InsurerCode = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Insurer", x => x.InsurerId);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DateOfBirth = table.Column<DateOnly>(type: "date", nullable: true),
                    VatNumber = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: true),
                    SocialSecurityNumber = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    GovernmentID = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    Profession = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Nationality = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: true),
                    TaxOffice = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    InsurerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.CustomerId);
                    table.ForeignKey(
                        name: "FK_Customer_Insurer_InsurerId",
                        column: x => x.InsurerId,
                        principalTable: "Insurer",
                        principalColumn: "InsurerId");
                });

            migrationBuilder.CreateTable(
                name: "Insurer_Email",
                columns: table => new
                {
                    InsurerEmailId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    InsurerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Insurer_Email", x => x.InsurerEmailId);
                    table.ForeignKey(
                        name: "FK_Insurer_Email_Insurer_InsurerId",
                        column: x => x.InsurerId,
                        principalTable: "Insurer",
                        principalColumn: "InsurerId",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "Insurer_Phone",
                columns: table => new
                {
                    InsurerTelephoneId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Telephone = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    phoneCategory = table.Column<int>(type: "int", nullable: false),
                    InsurerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Insurer_Phone", x => x.InsurerTelephoneId);
                    table.ForeignKey(
                        name: "FK_Insurer_Phone_Insurer_InsurerId",
                        column: x => x.InsurerId,
                        principalTable: "Insurer",
                        principalColumn: "InsurerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Customer_Address",
                columns: table => new
                {
                    CustomerAddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Prefecture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AddressType = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer_Address", x => x.CustomerAddressId);
                    table.ForeignKey(
                        name: "FK_Customer_Address_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Customer_Email",
                columns: table => new
                {
                    CustomerEmailId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmailType = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer_Email", x => x.CustomerEmailId);
                    table.ForeignKey(
                        name: "FK_Customer_Email_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Customer_Phone",
                columns: table => new
                {
                    CustomerPhoneId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Telephone = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    PhoneType = table.Column<int>(type: "int", nullable: false),
                    PhoneCategory = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer_Phone", x => x.CustomerPhoneId);
                    table.ForeignKey(
                        name: "FK_Customer_Phone_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Policy",
                columns: table => new
                {
                    PolicyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PolicySector = table.Column<int>(type: "int", nullable: false),
                    PolicyNumber = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    RenewalNumber = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    AddendumNumber = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NetPrice = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    GrossPrice = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    IsCanceled = table.Column<bool>(type: "bit", nullable: true),
                    IsExpired = table.Column<bool>(type: "bit", nullable: true),
                    Plates = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Policy", x => x.PolicyId);
                    table.ForeignKey(
                        name: "FK_Policy_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "CustomerId");
                });

            migrationBuilder.CreateTable(
                name: "Claim",
                columns: table => new
                {
                    ClaimId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AnnouncementDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AccidentDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ClaimStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompensationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CompensationAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    AccidentAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccidentRegion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PolicyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Claim", x => x.ClaimId);
                    table.ForeignKey(
                        name: "FK_Claim_Policy_PolicyId",
                        column: x => x.PolicyId,
                        principalTable: "Policy",
                        principalColumn: "PolicyId");
                });

            migrationBuilder.InsertData(
                table: "Insurer",
                columns: new[] { "InsurerId", "CreatedBy", "CreatedDate", "InsurerCode", "InsurerName", "LastModifiedBy", "LastModifiedDate" },
                values: new object[] { new Guid("86e6cbcb-a869-4438-8081-60d8771d1d13"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SLI001", "SafeLife Insurance", null, null });

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "CustomerId", "CreatedBy", "CreatedDate", "DateOfBirth", "FirstName", "Gender", "GovernmentID", "InsurerId", "LastModifiedBy", "LastModifiedDate", "LastName", "Nationality", "Profession", "SocialSecurityNumber", "TaxOffice", "VatNumber" },
                values: new object[] { new Guid("c5198e12-e205-4c62-83b0-b84237063c8b"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateOnly(1985, 5, 20), "John", 1, "AB123456", new Guid("86e6cbcb-a869-4438-8081-60d8771d1d13"), null, null, "Doe", "Greek", "Engineer", "12345678989", "Athens Center", "123456789" });

            migrationBuilder.InsertData(
                table: "Insurer_Email",
                columns: new[] { "InsurerEmailId", "CreatedBy", "CreatedDate", "EmailAddress", "InsurerId", "LastModifiedBy", "LastModifiedDate" },
                values: new object[] { new Guid("4866f931-c4f1-4651-89c4-f7bad696f0fa"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "support@safelife.gr", new Guid("86e6cbcb-a869-4438-8081-60d8771d1d13"), null, null });

            migrationBuilder.InsertData(
                table: "Insurer_Phone",
                columns: new[] { "InsurerTelephoneId", "CreatedBy", "CreatedDate", "InsurerId", "LastModifiedBy", "LastModifiedDate", "Telephone", "phoneCategory" },
                values: new object[] { new Guid("1f906a63-baf2-4bab-af37-0b9967ba2974"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("86e6cbcb-a869-4438-8081-60d8771d1d13"), null, null, "2101234567", 1 });

            migrationBuilder.InsertData(
                table: "Customer_Address",
                columns: new[] { "CustomerAddressId", "Address", "AddressType", "City", "CreatedBy", "CreatedDate", "CustomerId", "LastModifiedBy", "LastModifiedDate", "Prefecture", "ZipCode" },
                values: new object[] { new Guid("c5c6a7e3-20cb-444a-860b-9b9e3f22c77c"), "Ermou 15", 1, "Athens", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("c5198e12-e205-4c62-83b0-b84237063c8b"), null, null, "Attica", "10563" });

            migrationBuilder.InsertData(
                table: "Customer_Email",
                columns: new[] { "CustomerEmailId", "CreatedBy", "CreatedDate", "CustomerId", "EmailAddress", "EmailType", "LastModifiedBy", "LastModifiedDate" },
                values: new object[] { new Guid("f197b8c2-1233-4146-99a5-f2cef9f7fa39"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("c5198e12-e205-4c62-83b0-b84237063c8b"), "john.doe@example.com", 1, null, null });

            migrationBuilder.InsertData(
                table: "Customer_Phone",
                columns: new[] { "CustomerPhoneId", "CreatedBy", "CreatedDate", "CustomerId", "LastModifiedBy", "LastModifiedDate", "PhoneCategory", "PhoneType", "Telephone" },
                values: new object[] { new Guid("f15e5e51-62d9-4d67-9b57-f11517132af3"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("c5198e12-e205-4c62-83b0-b84237063c8b"), null, null, 1, 1, "6981234567" });

            migrationBuilder.InsertData(
                table: "Policy",
                columns: new[] { "PolicyId", "AddendumNumber", "CustomerId", "EndDate", "GrossPrice", "IsCanceled", "IsExpired", "NetPrice", "Plates", "PolicyNumber", "PolicySector", "RenewalNumber", "StartDate" },
                values: new object[] { new Guid("54ad9cc6-96a3-4214-8086-b6ab689ec36d"), "ADD001", new Guid("c5198e12-e205-4c62-83b0-b84237063c8b"), new DateTime(2024, 12, 31, 22, 0, 0, 0, DateTimeKind.Utc), 600m, false, false, 500m, "ΙΝΖ1234", "POL123456", 1, "REN001", new DateTime(2023, 12, 31, 22, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.InsertData(
                table: "Claim",
                columns: new[] { "ClaimId", "AccidentAddress", "AccidentDate", "AccidentRegion", "AnnouncementDate", "ClaimStatus", "CompensationAmount", "CompensationDate", "PolicyId" },
                values: new object[] { new Guid("f53401de-f34f-4cc2-870b-f3feef2936e1"), "Egnatias 100", new DateTime(2025, 4, 3, 21, 0, 0, 0, DateTimeKind.Utc), "Thessaloniki", new DateTime(2025, 4, 4, 21, 0, 0, 0, DateTimeKind.Utc), "Open", 100m, new DateTime(2025, 4, 8, 21, 0, 0, 0, DateTimeKind.Utc), new Guid("54ad9cc6-96a3-4214-8086-b6ab689ec36d") });

            migrationBuilder.CreateIndex(
                name: "IX_Claim_PolicyId",
                table: "Claim",
                column: "PolicyId");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_InsurerId",
                table: "Customer",
                column: "InsurerId");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_VatNumber",
                table: "Customer",
                column: "VatNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_Address_CustomerId",
                table: "Customer_Address",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_Email_CustomerId",
                table: "Customer_Email",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_Phone_CustomerId",
                table: "Customer_Phone",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Insurer_InsurerCode",
                table: "Insurer",
                column: "InsurerCode");

            migrationBuilder.CreateIndex(
                name: "IX_Insurer_Email_InsurerId",
                table: "Insurer_Email",
                column: "InsurerId");

            migrationBuilder.CreateIndex(
                name: "IX_Insurer_Phone_InsurerId",
                table: "Insurer_Phone",
                column: "InsurerId");

            migrationBuilder.CreateIndex(
                name: "IX_Policy_CustomerId",
                table: "Policy",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Policy_PolicyNumber",
                table: "Policy",
                column: "PolicyNumber");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Claim");

            migrationBuilder.DropTable(
                name: "Customer_Address");

            migrationBuilder.DropTable(
                name: "Customer_Email");

            migrationBuilder.DropTable(
                name: "Customer_Phone");

            migrationBuilder.DropTable(
                name: "Insurer_Email");

            migrationBuilder.DropTable(
                name: "Insurer_Phone");

            migrationBuilder.DropTable(
                name: "Policy");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Insurer");
        }
    }
}

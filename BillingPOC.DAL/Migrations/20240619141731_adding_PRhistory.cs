using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BillingPOC.DAL.Migrations
{
    /// <inheritdoc />
    public partial class adding_PRhistory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "26d0d5e6-b5a9-4623-b5db-1fb3a95a4e37");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "441ee350-7a97-4609-8b07-5a878331eac0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d6c2ac78-a5f7-4957-87cf-12f14d63c291");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "db50091f-e1a5-48f9-b83b-8799e53c3703");

            migrationBuilder.CreateTable(
                name: "PatientRuleHistories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RuleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RuleActionData = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientRuleHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PatientRuleHistories_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "PatientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "DisplayName", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0c1f3d24-b32f-496a-a734-5512a7ab5dc3", null, "Insurance Coordinator", "InsuranceCoordinator", "INSURANCECOORDINATOR" },
                    { "661531d6-b6a9-4077-b7bc-132f20e0a027", null, "Auditor", "Auditor", "AUDITOR" },
                    { "78731a57-7103-4af8-9aa1-d207589701ba", null, "Accountant", "Accountant", "ACCOUNTANT" },
                    { "e7b64189-6e03-4a68-8846-497a8564b978", null, "Administrator", "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PatientRuleHistories_PatientId",
                table: "PatientRuleHistories",
                column: "PatientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PatientRuleHistories");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0c1f3d24-b32f-496a-a734-5512a7ab5dc3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "661531d6-b6a9-4077-b7bc-132f20e0a027");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "78731a57-7103-4af8-9aa1-d207589701ba");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e7b64189-6e03-4a68-8846-497a8564b978");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "DisplayName", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "26d0d5e6-b5a9-4623-b5db-1fb3a95a4e37", null, "Insurance Coordinator", "InsuranceCoordinator", "INSURANCECOORDINATOR" },
                    { "441ee350-7a97-4609-8b07-5a878331eac0", null, "Auditor", "Auditor", "AUDITOR" },
                    { "d6c2ac78-a5f7-4957-87cf-12f14d63c291", null, "Accountant", "Accountant", "ACCOUNTANT" },
                    { "db50091f-e1a5-48f9-b83b-8799e53c3703", null, "Administrator", "Administrator", "ADMINISTRATOR" }
                });
        }
    }
}

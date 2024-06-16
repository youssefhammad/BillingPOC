using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BillingPOC.DAL.Migrations
{
    /// <inheritdoc />
    public partial class invoice_models : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PatientMedicalProcedures_Patients_PatientId",
                table: "PatientMedicalProcedures");

            migrationBuilder.DropIndex(
                name: "IX_PatientMedicalProcedures_PatientId",
                table: "PatientMedicalProcedures");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "39fedef0-587d-4f62-8825-b73d3cf2ab88");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4ed35c46-4ac6-4364-b8ac-983caca0a2e8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a75554d7-3b0f-4e82-b6b7-16cf327dff48");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c8aeeeac-61b8-4943-b0f1-3fe33fd902c6");

            migrationBuilder.DropColumn(
                name: "PatientId",
                table: "PatientMedicalProcedures");

            migrationBuilder.AddColumn<int>(
                name: "InvoiceId",
                table: "PatientMedicalProcedures",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "InvoiceStatus",
                columns: table => new
                {
                    InvoiceStatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceStatus", x => x.InvoiceStatusId);
                });

            migrationBuilder.CreateTable(
                name: "Invoice",
                columns: table => new
                {
                    InvoiceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    InvoiceStatusId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoice", x => x.InvoiceId);
                    table.ForeignKey(
                        name: "FK_Invoice_InvoiceStatus_InvoiceStatusId",
                        column: x => x.InvoiceStatusId,
                        principalTable: "InvoiceStatus",
                        principalColumn: "InvoiceStatusId");
                    table.ForeignKey(
                        name: "FK_Invoice_Patients_PatientId",
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
                    { "0911486b-85ac-4c56-9eb1-1d0d4afd9e27", null, "Administrator", "Administrator", "ADMINISTRATOR" },
                    { "84c0d9c1-5b0b-4fd2-a476-fdddefff2682", null, "Accountant", "Accountant", "ACCOUNTANT" },
                    { "8da4bf1f-eb65-4ad8-8f19-6cdb3fb2d3b1", null, "Auditor", "Auditor", "AUDITOR" },
                    { "c27d6059-553b-460f-bcd3-52f7d32183d7", null, "Insurance Coordinator", "InsuranceCoordinator", "INSURANCECOORDINATOR" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PatientMedicalProcedures_InvoiceId",
                table: "PatientMedicalProcedures",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_InvoiceStatusId",
                table: "Invoice",
                column: "InvoiceStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_PatientId",
                table: "Invoice",
                column: "PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_PatientMedicalProcedures_Invoice_InvoiceId",
                table: "PatientMedicalProcedures",
                column: "InvoiceId",
                principalTable: "Invoice",
                principalColumn: "InvoiceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PatientMedicalProcedures_Invoice_InvoiceId",
                table: "PatientMedicalProcedures");

            migrationBuilder.DropTable(
                name: "Invoice");

            migrationBuilder.DropTable(
                name: "InvoiceStatus");

            migrationBuilder.DropIndex(
                name: "IX_PatientMedicalProcedures_InvoiceId",
                table: "PatientMedicalProcedures");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0911486b-85ac-4c56-9eb1-1d0d4afd9e27");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "84c0d9c1-5b0b-4fd2-a476-fdddefff2682");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8da4bf1f-eb65-4ad8-8f19-6cdb3fb2d3b1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c27d6059-553b-460f-bcd3-52f7d32183d7");

            migrationBuilder.DropColumn(
                name: "InvoiceId",
                table: "PatientMedicalProcedures");

            migrationBuilder.AddColumn<int>(
                name: "PatientId",
                table: "PatientMedicalProcedures",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "DisplayName", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "39fedef0-587d-4f62-8825-b73d3cf2ab88", null, "Insurance Coordinator", "InsuranceCoordinator", "INSURANCECOORDINATOR" },
                    { "4ed35c46-4ac6-4364-b8ac-983caca0a2e8", null, "Auditor", "Auditor", "AUDITOR" },
                    { "a75554d7-3b0f-4e82-b6b7-16cf327dff48", null, "Accountant", "Accountant", "ACCOUNTANT" },
                    { "c8aeeeac-61b8-4943-b0f1-3fe33fd902c6", null, "Administrator", "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PatientMedicalProcedures_PatientId",
                table: "PatientMedicalProcedures",
                column: "PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_PatientMedicalProcedures_Patients_PatientId",
                table: "PatientMedicalProcedures",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "PatientId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

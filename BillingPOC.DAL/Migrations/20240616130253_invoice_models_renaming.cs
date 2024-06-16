using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BillingPOC.DAL.Migrations
{
    /// <inheritdoc />
    public partial class invoice_models_renaming : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoice_InvoiceStatus_InvoiceStatusId",
                table: "Invoice");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoice_Patients_PatientId",
                table: "Invoice");

            migrationBuilder.DropForeignKey(
                name: "FK_PatientMedicalProcedures_Invoice_InvoiceId",
                table: "PatientMedicalProcedures");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InvoiceStatus",
                table: "InvoiceStatus");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Invoice",
                table: "Invoice");

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

            migrationBuilder.RenameTable(
                name: "InvoiceStatus",
                newName: "InvoiceStatuses");

            migrationBuilder.RenameTable(
                name: "Invoice",
                newName: "Invoices");

            migrationBuilder.RenameIndex(
                name: "IX_Invoice_PatientId",
                table: "Invoices",
                newName: "IX_Invoices_PatientId");

            migrationBuilder.RenameIndex(
                name: "IX_Invoice_InvoiceStatusId",
                table: "Invoices",
                newName: "IX_Invoices_InvoiceStatusId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InvoiceStatuses",
                table: "InvoiceStatuses",
                column: "InvoiceStatusId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Invoices",
                table: "Invoices",
                column: "InvoiceId");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "DisplayName", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "229e0be5-5b81-4b75-80c9-54c466d33762", null, "Auditor", "Auditor", "AUDITOR" },
                    { "51c6e80e-eba2-401b-91b5-26872bf550ab", null, "Administrator", "Administrator", "ADMINISTRATOR" },
                    { "9650df53-277b-4c93-8177-6a0751481260", null, "Insurance Coordinator", "InsuranceCoordinator", "INSURANCECOORDINATOR" },
                    { "adbbc917-c2df-483c-bc9c-58cf3dddf7d3", null, "Accountant", "Accountant", "ACCOUNTANT" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_InvoiceStatuses_InvoiceStatusId",
                table: "Invoices",
                column: "InvoiceStatusId",
                principalTable: "InvoiceStatuses",
                principalColumn: "InvoiceStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Patients_PatientId",
                table: "Invoices",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "PatientId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PatientMedicalProcedures_Invoices_InvoiceId",
                table: "PatientMedicalProcedures",
                column: "InvoiceId",
                principalTable: "Invoices",
                principalColumn: "InvoiceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_InvoiceStatuses_InvoiceStatusId",
                table: "Invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Patients_PatientId",
                table: "Invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_PatientMedicalProcedures_Invoices_InvoiceId",
                table: "PatientMedicalProcedures");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InvoiceStatuses",
                table: "InvoiceStatuses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Invoices",
                table: "Invoices");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "229e0be5-5b81-4b75-80c9-54c466d33762");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "51c6e80e-eba2-401b-91b5-26872bf550ab");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9650df53-277b-4c93-8177-6a0751481260");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "adbbc917-c2df-483c-bc9c-58cf3dddf7d3");

            migrationBuilder.RenameTable(
                name: "InvoiceStatuses",
                newName: "InvoiceStatus");

            migrationBuilder.RenameTable(
                name: "Invoices",
                newName: "Invoice");

            migrationBuilder.RenameIndex(
                name: "IX_Invoices_PatientId",
                table: "Invoice",
                newName: "IX_Invoice_PatientId");

            migrationBuilder.RenameIndex(
                name: "IX_Invoices_InvoiceStatusId",
                table: "Invoice",
                newName: "IX_Invoice_InvoiceStatusId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InvoiceStatus",
                table: "InvoiceStatus",
                column: "InvoiceStatusId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Invoice",
                table: "Invoice",
                column: "InvoiceId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Invoice_InvoiceStatus_InvoiceStatusId",
                table: "Invoice",
                column: "InvoiceStatusId",
                principalTable: "InvoiceStatus",
                principalColumn: "InvoiceStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoice_Patients_PatientId",
                table: "Invoice",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "PatientId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PatientMedicalProcedures_Invoice_InvoiceId",
                table: "PatientMedicalProcedures",
                column: "InvoiceId",
                principalTable: "Invoice",
                principalColumn: "InvoiceId");
        }
    }
}

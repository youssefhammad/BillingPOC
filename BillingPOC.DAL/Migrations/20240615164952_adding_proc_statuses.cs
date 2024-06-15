using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BillingPOC.DAL.Migrations
{
    /// <inheritdoc />
    public partial class adding_proc_statuses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "67546bab-412d-44dc-9361-e2e29a3cb2d1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a1f7f425-c78b-4fd4-a0bd-b646695733b8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a8ef1a7b-6522-4499-ac0f-ae440a4c21ab");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b26bf1ca-5a97-4215-a87d-e43d00cc0596");

            migrationBuilder.AddColumn<decimal>(
                name: "CoInsurance",
                table: "Patients",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "CoveredAmount",
                table: "PatientMedicalProcedures",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "OutOfPocketCost",
                table: "PatientMedicalProcedures",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "ProcedureStatusId",
                table: "PatientMedicalProcedures",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ProcedureStatuses",
                columns: table => new
                {
                    ProcedureStatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcedureStatuses", x => x.ProcedureStatusId);
                });

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
                name: "IX_PatientMedicalProcedures_ProcedureStatusId",
                table: "PatientMedicalProcedures",
                column: "ProcedureStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_PatientMedicalProcedures_ProcedureStatuses_ProcedureStatusId",
                table: "PatientMedicalProcedures",
                column: "ProcedureStatusId",
                principalTable: "ProcedureStatuses",
                principalColumn: "ProcedureStatusId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PatientMedicalProcedures_ProcedureStatuses_ProcedureStatusId",
                table: "PatientMedicalProcedures");

            migrationBuilder.DropTable(
                name: "ProcedureStatuses");

            migrationBuilder.DropIndex(
                name: "IX_PatientMedicalProcedures_ProcedureStatusId",
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
                name: "CoInsurance",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "CoveredAmount",
                table: "PatientMedicalProcedures");

            migrationBuilder.DropColumn(
                name: "OutOfPocketCost",
                table: "PatientMedicalProcedures");

            migrationBuilder.DropColumn(
                name: "ProcedureStatusId",
                table: "PatientMedicalProcedures");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "DisplayName", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "67546bab-412d-44dc-9361-e2e29a3cb2d1", null, "Insurance Coordinator", "InsuranceCoordinator", "INSURANCECOORDINATOR" },
                    { "a1f7f425-c78b-4fd4-a0bd-b646695733b8", null, "Accountant", "Accountant", "ACCOUNTANT" },
                    { "a8ef1a7b-6522-4499-ac0f-ae440a4c21ab", null, "Auditor", "Auditor", "AUDITOR" },
                    { "b26bf1ca-5a97-4215-a87d-e43d00cc0596", null, "Administrator", "Administrator", "ADMINISTRATOR" }
                });
        }
    }
}

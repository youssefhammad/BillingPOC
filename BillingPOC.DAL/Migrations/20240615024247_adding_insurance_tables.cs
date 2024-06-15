using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BillingPOC.DAL.Migrations
{
    /// <inheritdoc />
    public partial class adding_insurance_tables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7eb30a3c-9232-46c7-8ca4-67de26a4fb15");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "90bbd4be-6e25-4b61-8d60-726070e7b5ed");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ac168751-f501-4390-90fc-94bcdd330622");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dfd62c29-e12b-4360-8512-cb84b626f977");

            migrationBuilder.CreateTable(
                name: "InsuranceCompanies",
                columns: table => new
                {
                    InsuranceCompanyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsuranceCompanies", x => x.InsuranceCompanyId);
                });

            migrationBuilder.CreateTable(
                name: "MedicalProcedures",
                columns: table => new
                {
                    MedicalProcedureId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProcedureName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalProcedures", x => x.MedicalProcedureId);
                });

            migrationBuilder.CreateTable(
                name: "ProcedureConfigurations",
                columns: table => new
                {
                    ProcedureConfigurationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConfigurationName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcedureConfigurations", x => x.ProcedureConfigurationId);
                });

            migrationBuilder.CreateTable(
                name: "Plans",
                columns: table => new
                {
                    PlanId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlanName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InsuranceCompanyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plans", x => x.PlanId);
                    table.ForeignKey(
                        name: "FK_Plans_InsuranceCompanies_InsuranceCompanyId",
                        column: x => x.InsuranceCompanyId,
                        principalTable: "InsuranceCompanies",
                        principalColumn: "InsuranceCompanyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    PatientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PlanId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.PatientId);
                    table.ForeignKey(
                        name: "FK_Patients_Plans_PlanId",
                        column: x => x.PlanId,
                        principalTable: "Plans",
                        principalColumn: "PlanId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProcedurePlanConfigurations",
                columns: table => new
                {
                    ProcedurePlanConfigurationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlanId = table.Column<int>(type: "int", nullable: false),
                    MedicalProcedureId = table.Column<int>(type: "int", nullable: false),
                    ProcedureConfigurationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcedurePlanConfigurations", x => x.ProcedurePlanConfigurationId);
                    table.ForeignKey(
                        name: "FK_ProcedurePlanConfigurations_MedicalProcedures_MedicalProcedureId",
                        column: x => x.MedicalProcedureId,
                        principalTable: "MedicalProcedures",
                        principalColumn: "MedicalProcedureId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProcedurePlanConfigurations_Plans_PlanId",
                        column: x => x.PlanId,
                        principalTable: "Plans",
                        principalColumn: "PlanId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProcedurePlanConfigurations_ProcedureConfigurations_ProcedureConfigurationId",
                        column: x => x.ProcedureConfigurationId,
                        principalTable: "ProcedureConfigurations",
                        principalColumn: "ProcedureConfigurationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PatientMedicalProcedures",
                columns: table => new
                {
                    PatientMedicalProcedureId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    MedicalProcedureId = table.Column<int>(type: "int", nullable: false),
                    ProcedureDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientMedicalProcedures", x => x.PatientMedicalProcedureId);
                    table.ForeignKey(
                        name: "FK_PatientMedicalProcedures_MedicalProcedures_MedicalProcedureId",
                        column: x => x.MedicalProcedureId,
                        principalTable: "MedicalProcedures",
                        principalColumn: "MedicalProcedureId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PatientMedicalProcedures_Patients_PatientId",
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
                    { "072a2afa-4fae-46d4-be02-17c2c5ac44d5", null, "Auditor", "Auditor", "AUDITOR" },
                    { "4ace8573-149a-431a-a717-12ba08f1ba41", null, "Insurance Coordinator", "InsuranceCoordinator", "INSURANCECOORDINATOR" },
                    { "8a623fa2-c626-493b-83f4-992b01e651cd", null, "Accountant", "Accountant", "ACCOUNTANT" },
                    { "b486d030-78b7-4d64-98c8-a6bedf754682", null, "Administrator", "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PatientMedicalProcedures_MedicalProcedureId",
                table: "PatientMedicalProcedures",
                column: "MedicalProcedureId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientMedicalProcedures_PatientId",
                table: "PatientMedicalProcedures",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_PlanId",
                table: "Patients",
                column: "PlanId");

            migrationBuilder.CreateIndex(
                name: "IX_Plans_InsuranceCompanyId",
                table: "Plans",
                column: "InsuranceCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_ProcedurePlanConfigurations_MedicalProcedureId",
                table: "ProcedurePlanConfigurations",
                column: "MedicalProcedureId");

            migrationBuilder.CreateIndex(
                name: "IX_ProcedurePlanConfigurations_PlanId",
                table: "ProcedurePlanConfigurations",
                column: "PlanId");

            migrationBuilder.CreateIndex(
                name: "IX_ProcedurePlanConfigurations_ProcedureConfigurationId",
                table: "ProcedurePlanConfigurations",
                column: "ProcedureConfigurationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PatientMedicalProcedures");

            migrationBuilder.DropTable(
                name: "ProcedurePlanConfigurations");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "MedicalProcedures");

            migrationBuilder.DropTable(
                name: "ProcedureConfigurations");

            migrationBuilder.DropTable(
                name: "Plans");

            migrationBuilder.DropTable(
                name: "InsuranceCompanies");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "072a2afa-4fae-46d4-be02-17c2c5ac44d5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4ace8573-149a-431a-a717-12ba08f1ba41");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8a623fa2-c626-493b-83f4-992b01e651cd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b486d030-78b7-4d64-98c8-a6bedf754682");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "DisplayName", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7eb30a3c-9232-46c7-8ca4-67de26a4fb15", null, "Insurance Coordinator", "InsuranceCoordinator", "INSURANCECOORDINATOR" },
                    { "90bbd4be-6e25-4b61-8d60-726070e7b5ed", null, "Administrator", "Administrator", "ADMINISTRATOR" },
                    { "ac168751-f501-4390-90fc-94bcdd330622", null, "Auditor", "Auditor", "AUDITOR" },
                    { "dfd62c29-e12b-4360-8512-cb84b626f977", null, "Accountant", "Accountant", "ACCOUNTANT" }
                });
        }
    }
}

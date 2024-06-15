using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BillingPOC.DAL.Migrations
{
    /// <inheritdoc />
    public partial class adding_prices : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "MedicalProcedures",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Price",
                table: "MedicalProcedures");

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
        }
    }
}

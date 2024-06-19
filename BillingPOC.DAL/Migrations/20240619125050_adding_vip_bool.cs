using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BillingPOC.DAL.Migrations
{
    /// <inheritdoc />
    public partial class adding_vip_bool : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "10951752-b84c-4e0c-ab0d-be93e24924ff");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "364724ea-f9fb-4f5a-bd3b-d4e1351a772f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "82730100-2c8b-4653-ab4b-9ae6baa9da25");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "864ea804-c944-490d-a9f3-f9be4566436f");

            migrationBuilder.AddColumn<bool>(
                name: "IsVIP",
                table: "Patients",
                type: "bit",
                nullable: false,
                defaultValue: false);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "IsVIP",
                table: "Patients");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "DisplayName", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "10951752-b84c-4e0c-ab0d-be93e24924ff", null, "Insurance Coordinator", "InsuranceCoordinator", "INSURANCECOORDINATOR" },
                    { "364724ea-f9fb-4f5a-bd3b-d4e1351a772f", null, "Auditor", "Auditor", "AUDITOR" },
                    { "82730100-2c8b-4653-ab4b-9ae6baa9da25", null, "Accountant", "Accountant", "ACCOUNTANT" },
                    { "864ea804-c944-490d-a9f3-f9be4566436f", null, "Administrator", "Administrator", "ADMINISTRATOR" }
                });
        }
    }
}

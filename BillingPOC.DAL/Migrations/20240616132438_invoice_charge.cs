using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BillingPOC.DAL.Migrations
{
    /// <inheritdoc />
    public partial class invoice_charge : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<decimal>(
                name: "Charge",
                table: "Invoices",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Discount",
                table: "Invoices",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Charge",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "Discount",
                table: "Invoices");

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
        }
    }
}

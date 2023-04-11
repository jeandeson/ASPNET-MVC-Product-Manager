using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication2.Migrations
{
    /// <inheritdoc />
    public partial class Seed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
             table: "Manufacturers",
             columns: new[] { "ManufacturerId", "Name"},
             values: new object[] {1, "Philips" }
            );
            migrationBuilder.InsertData(
             table: "Manufacturers",
             columns: new[] { "ManufacturerId", "Name" },
             values: new object[] { 2, "Samsumg" }
            );
            migrationBuilder.InsertData(
             table: "Manufacturers",
             columns: new[] { "ManufacturerId", "Name" },
             values: new object[] { 3, "Redragon" }
            );
            migrationBuilder.InsertData(
             table: "Categories",
             columns: new[] { "CategoryId", "CategoryName" },
             values: new object[] { 1, "Notebooks" }
            );
            migrationBuilder.InsertData(
             table: "Categories",
             columns: new[] { "CategoryId", "CategoryName" },
             values: new object[] { 2, "Monitors" }
            );
            migrationBuilder.InsertData(
             table: "Categories",
             columns: new[] { "CategoryId", "CategoryName" },
             values: new object[] { 3, "Keyboard" }
            );
            migrationBuilder.InsertData(table: "Products",
            columns: new[] { "productId", "Name", "CategoryId", "ManufacturerId" },
            values: new object[] {1,"Essentials E30",1, 2});
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(table: "Manufacturers", keyColumn: "ManufacturerId", keyValue: 1);
            migrationBuilder.DeleteData(table: "Manufacturers", keyColumn: "ManufacturerId", keyValue: 2);
            migrationBuilder.DeleteData(table: "Manufacturers", keyColumn: "ManufacturerId", keyValue: 3); 
            migrationBuilder.DeleteData(table: "Categories", keyColumn: "CategoryId", keyValue: 1);
            migrationBuilder.DeleteData(table: "Categories", keyColumn: "CategoryId", keyValue: 2);
            migrationBuilder.DeleteData(table: "Categories", keyColumn: "CategoryId", keyValue: 3);
            migrationBuilder.DeleteData(table: "Products", keyColumn: "ProductId", keyValue: 1);
        }
    }
}

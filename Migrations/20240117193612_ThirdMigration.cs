using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ccse_cw1.Migrations
{
    /// <inheritdoc />
    public partial class ThirdMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "20a181d8-e395-4d9b-9aac-b1c2f7100d82");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "53bfaa6c-ebe2-479e-97e0-76501b95be13");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ba0db40c-ec90-4000-90a4-d5db2b0b1f66");

            migrationBuilder.AddColumn<string>(
                name: "UserID",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "431e69a9-4eb6-4b86-8019-4a36481237ec", null, "client", "client" },
                    { "5a32678c-57df-4f98-af71-915ce0293571", null, "seller", "seller" },
                    { "7135c159-4072-44aa-a16f-2e2d64b0bca9", null, "admin", "admin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "431e69a9-4eb6-4b86-8019-4a36481237ec");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5a32678c-57df-4f98-af71-915ce0293571");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7135c159-4072-44aa-a16f-2e2d64b0bca9");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "20a181d8-e395-4d9b-9aac-b1c2f7100d82", null, "seller", "seller" },
                    { "53bfaa6c-ebe2-479e-97e0-76501b95be13", null, "admin", "admin" },
                    { "ba0db40c-ec90-4000-90a4-d5db2b0b1f66", null, "client", "client" }
                });
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ccse_cw1.Migrations
{
    /// <inheritdoc />
    public partial class TheHotelMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "295ef908-796a-4785-b440-10922a121260");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9ce96706-49fa-4f1c-922d-7854d409473a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "caf61b75-f4ff-4b6e-becc-4ead3b0016b9");

            migrationBuilder.AddColumn<DateTime>(
                name: "TourEnd",
                table: "Tours",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "TourStart",
                table: "Tours",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "AvailableDouble",
                table: "Hotels",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AvailableFamily",
                table: "Hotels",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AvailableSingle",
                table: "Hotels",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "TourID",
                table: "Booking",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "RoomNumber",
                table: "Booking",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "HotelID",
                table: "Booking",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2025ae78-1a2d-4964-abfb-485cafeefe4f", null, "admin", "admin" },
                    { "89a59882-ab84-4282-b3c9-be758813c88e", null, "seller", "seller" },
                    { "9c3a8516-d3f5-4b0c-9cc5-e1dc63ac1a99", null, "client", "client" }
                });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "HotelID", "AvailableDouble", "AvailableFamily", "AvailableSingle", "DoublePrice", "FamilyPrice", "HotelLocation", "HotelName", "SinglePrice" },
                values: new object[,]
                {
                    { 1, 20, 20, 20, 775, 950, "London", "Hilton London Hotel", 375 },
                    { 2, 20, 20, 20, 500, 900, "London", "London Marriott Hotel", 300 },
                    { 3, 20, 20, 20, 120, 150, "Brighton", "Travelodge Brighton Seafront", 80 },
                    { 4, 20, 20, 20, 400, 520, "Brighton", "Kings Hotel Brighton", 180 },
                    { 5, 20, 20, 20, 400, 520, "Brighton", "Leonardo Hotel Brighton", 180 },
                    { 6, 20, 20, 20, 100, 155, "Fort William", "Nevis Bank Inn, Fort William", 90 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2025ae78-1a2d-4964-abfb-485cafeefe4f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "89a59882-ab84-4282-b3c9-be758813c88e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9c3a8516-d3f5-4b0c-9cc5-e1dc63ac1a99");

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "HotelID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "HotelID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "HotelID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "HotelID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "HotelID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "HotelID",
                keyValue: 6);

            migrationBuilder.DropColumn(
                name: "TourEnd",
                table: "Tours");

            migrationBuilder.DropColumn(
                name: "TourStart",
                table: "Tours");

            migrationBuilder.DropColumn(
                name: "AvailableDouble",
                table: "Hotels");

            migrationBuilder.DropColumn(
                name: "AvailableFamily",
                table: "Hotels");

            migrationBuilder.DropColumn(
                name: "AvailableSingle",
                table: "Hotels");

            migrationBuilder.AlterColumn<int>(
                name: "TourID",
                table: "Booking",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RoomNumber",
                table: "Booking",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "HotelID",
                table: "Booking",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "295ef908-796a-4785-b440-10922a121260", null, "seller", "seller" },
                    { "9ce96706-49fa-4f1c-922d-7854d409473a", null, "client", "client" },
                    { "caf61b75-f4ff-4b6e-becc-4ead3b0016b9", null, "admin", "admin" }
                });
        }
    }
}

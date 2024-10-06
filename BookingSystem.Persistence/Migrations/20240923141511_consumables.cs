using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookingSystem.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class consumables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Consumables",
                columns: new[] { "ConsumableId", "ConsumableCategoryId", "Created", "CreatedBy", "Description", "LastModified", "LastModifiedBy", "Name" },
                values: new object[,]
                {
                    { new Guid("ee18f549-e790-5e9f-aa15-18c2292a2ee9"), new Guid("ee58f549-e790-5e9f-aa15-18c2292a2ee9"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "", null, null, "Pen" },
                    { new Guid("ee38f549-e790-5e9f-aa15-18c2292a2ee9"), new Guid("ee58f549-e790-5e9f-aa15-18c2292a2ee9"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "", null, null, "Pencil" },
                    { new Guid("ee98f549-e790-5e9f-aa15-18c2292a2ee8"), new Guid("ee48f549-e790-5e9f-aa15-18c2292a2ee9"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "", null, null, "Marker" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Consumables",
                keyColumn: "ConsumableId",
                keyValue: new Guid("ee18f549-e790-5e9f-aa15-18c2292a2ee9"));

            migrationBuilder.DeleteData(
                table: "Consumables",
                keyColumn: "ConsumableId",
                keyValue: new Guid("ee38f549-e790-5e9f-aa15-18c2292a2ee9"));

            migrationBuilder.DeleteData(
                table: "Consumables",
                keyColumn: "ConsumableId",
                keyValue: new Guid("ee98f549-e790-5e9f-aa15-18c2292a2ee8"));
        }
    }
}

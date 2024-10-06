using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookingSystem.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class conDes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Consumables",
                keyColumn: "ConsumableId",
                keyValue: new Guid("ee18f549-e790-5e9f-aa15-18c2292a2ee9"),
                column: "Description",
                value: "s simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's ");

            migrationBuilder.UpdateData(
                table: "Consumables",
                keyColumn: "ConsumableId",
                keyValue: new Guid("ee38f549-e790-5e9f-aa15-18c2292a2ee9"),
                column: "Description",
                value: "s simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's ");

            migrationBuilder.UpdateData(
                table: "Consumables",
                keyColumn: "ConsumableId",
                keyValue: new Guid("ee98f549-e790-5e9f-aa15-18c2292a2ee8"),
                column: "Description",
                value: "s simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Consumables",
                keyColumn: "ConsumableId",
                keyValue: new Guid("ee18f549-e790-5e9f-aa15-18c2292a2ee9"),
                column: "Description",
                value: "");

            migrationBuilder.UpdateData(
                table: "Consumables",
                keyColumn: "ConsumableId",
                keyValue: new Guid("ee38f549-e790-5e9f-aa15-18c2292a2ee9"),
                column: "Description",
                value: "");

            migrationBuilder.UpdateData(
                table: "Consumables",
                keyColumn: "ConsumableId",
                keyValue: new Guid("ee98f549-e790-5e9f-aa15-18c2292a2ee8"),
                column: "Description",
                value: "");
        }
    }
}

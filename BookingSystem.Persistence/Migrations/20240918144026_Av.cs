using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookingSystem.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Av : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAvailable",
                table: "ConferenceRooms",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "ConferenceRooms",
                keyColumn: "ConferenceRoomId",
                keyValue: new Guid("ee98f549-e790-5e9f-aa15-11c2292a1ee0"),
                column: "IsAvailable",
                value: true);

            migrationBuilder.UpdateData(
                table: "ConferenceRooms",
                keyColumn: "ConferenceRoomId",
                keyValue: new Guid("ee98f549-e790-5e9f-aa15-11c2292a1ee1"),
                column: "IsAvailable",
                value: true);

            migrationBuilder.UpdateData(
                table: "ConferenceRooms",
                keyColumn: "ConferenceRoomId",
                keyValue: new Guid("ee98f549-e790-5e9f-aa15-11c2292a1ee2"),
                column: "IsAvailable",
                value: true);

            migrationBuilder.UpdateData(
                table: "ConferenceRooms",
                keyColumn: "ConferenceRoomId",
                keyValue: new Guid("ee98f549-e790-5e9f-aa15-11c2292a1ee3"),
                column: "IsAvailable",
                value: true);

            migrationBuilder.UpdateData(
                table: "ConferenceRooms",
                keyColumn: "ConferenceRoomId",
                keyValue: new Guid("ee98f549-e790-5e9f-aa15-11c2292a1ee4"),
                column: "IsAvailable",
                value: true);

            migrationBuilder.UpdateData(
                table: "ConferenceRooms",
                keyColumn: "ConferenceRoomId",
                keyValue: new Guid("ee98f549-e790-5e9f-aa15-11c2292a1ee5"),
                column: "IsAvailable",
                value: true);

            migrationBuilder.UpdateData(
                table: "ConferenceRooms",
                keyColumn: "ConferenceRoomId",
                keyValue: new Guid("ee98f549-e790-5e9f-aa15-11c2292a1ee6"),
                column: "IsAvailable",
                value: true);

            migrationBuilder.UpdateData(
                table: "ConferenceRooms",
                keyColumn: "ConferenceRoomId",
                keyValue: new Guid("ee98f549-e790-5e9f-aa15-18c2292a1ee1"),
                column: "IsAvailable",
                value: true);

            migrationBuilder.UpdateData(
                table: "ConferenceRooms",
                keyColumn: "ConferenceRoomId",
                keyValue: new Guid("ee98f549-e790-5e9f-aa15-18c2292a2ee0"),
                column: "IsAvailable",
                value: true);

            migrationBuilder.UpdateData(
                table: "ConferenceRooms",
                keyColumn: "ConferenceRoomId",
                keyValue: new Guid("ee98f549-e790-5e9f-aa15-18c2292a2ee2"),
                column: "IsAvailable",
                value: true);

            migrationBuilder.UpdateData(
                table: "ConferenceRooms",
                keyColumn: "ConferenceRoomId",
                keyValue: new Guid("ee98f549-e790-5e9f-aa15-18c2292a2ee3"),
                column: "IsAvailable",
                value: true);

            migrationBuilder.UpdateData(
                table: "ConferenceRooms",
                keyColumn: "ConferenceRoomId",
                keyValue: new Guid("ee98f549-e790-5e9f-aa15-18c2292a2ee4"),
                column: "IsAvailable",
                value: true);

            migrationBuilder.UpdateData(
                table: "ConferenceRooms",
                keyColumn: "ConferenceRoomId",
                keyValue: new Guid("ee98f549-e790-5e9f-aa15-18c2292a2ee5"),
                column: "IsAvailable",
                value: true);

            migrationBuilder.UpdateData(
                table: "ConferenceRooms",
                keyColumn: "ConferenceRoomId",
                keyValue: new Guid("ee98f549-e790-5e9f-aa15-18c2292a2ee6"),
                column: "IsAvailable",
                value: true);

            migrationBuilder.UpdateData(
                table: "ConferenceRooms",
                keyColumn: "ConferenceRoomId",
                keyValue: new Guid("ee98f549-e790-5e9f-aa15-18c2292a2ee7"),
                column: "IsAvailable",
                value: true);

            migrationBuilder.UpdateData(
                table: "ConferenceRooms",
                keyColumn: "ConferenceRoomId",
                keyValue: new Guid("ee98f549-e790-5e9f-aa15-18c2292a2ee8"),
                column: "IsAvailable",
                value: true);

            migrationBuilder.UpdateData(
                table: "ConferenceRooms",
                keyColumn: "ConferenceRoomId",
                keyValue: new Guid("ee98f549-e790-5e9f-aa15-18c2292a2ee9"),
                column: "IsAvailable",
                value: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAvailable",
                table: "ConferenceRooms");
        }
    }
}

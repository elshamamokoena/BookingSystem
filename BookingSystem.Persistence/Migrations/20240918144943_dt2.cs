using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookingSystem.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class dt2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("ee11f549-e190-5e9f-aa15-18c2292a2ee1"),
                columns: new[] { "End", "Start" },
                values: new object[] { new DateTime(2024, 9, 23, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 9, 23, 8, 30, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("ee98f549-e190-5e9f-aa15-18c2292a2ee1"),
                columns: new[] { "End", "Start" },
                values: new object[] { new DateTime(2024, 9, 23, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 9, 23, 8, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("ee11f549-e190-5e9f-aa15-18c2292a2ee1"),
                columns: new[] { "End", "Start" },
                values: new object[] { new DateTime(2024, 9, 23, 14, 0, 30, 791, DateTimeKind.Local), new DateTime(2024, 9, 23, 12, 30, 30, 791, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("ee98f549-e190-5e9f-aa15-18c2292a2ee1"),
                columns: new[] { "End", "Start" },
                values: new object[] { new DateTime(2024, 9, 23, 13, 0, 30, 791, DateTimeKind.Local), new DateTime(2024, 9, 23, 12, 0, 30, 791, DateTimeKind.Local) });
        }
    }
}

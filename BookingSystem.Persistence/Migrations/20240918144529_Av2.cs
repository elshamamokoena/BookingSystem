using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookingSystem.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Av2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("ee11f549-e190-5e9f-aa15-18c2292a2ee1"),
                columns: new[] { "End", "Start" },
                values: new object[] { new DateTime(2024, 9, 23, 12, 0, 30, 791, DateTimeKind.Local), new DateTime(2024, 9, 23, 10, 30, 30, 791, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("ee98f549-e190-5e9f-aa15-18c2292a2ee1"),
                columns: new[] { "End", "Start" },
                values: new object[] { new DateTime(2024, 9, 23, 12, 0, 30, 791, DateTimeKind.Local), new DateTime(2024, 9, 23, 10, 30, 30, 791, DateTimeKind.Local) });
        }
    }
}

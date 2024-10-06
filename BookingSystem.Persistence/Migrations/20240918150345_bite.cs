using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookingSystem.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class bite : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("ee98f540-e790-5e9f-aa15-18c2292a2ee2"),
                columns: new[] { "End", "Start" },
                values: new object[] { new DateTime(2024, 9, 24, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 9, 24, 10, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("ee98f541-e790-5e9f-aa15-18c2292a2ee8"),
                columns: new[] { "End", "Start" },
                values: new object[] { new DateTime(2024, 9, 26, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 9, 26, 8, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("ee98f542-e790-5e9f-aa15-18c2292a2ee9"),
                columns: new[] { "End", "Start" },
                values: new object[] { new DateTime(2024, 9, 25, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 9, 26, 14, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("ee98f543-e790-5e9f-aa15-18c2292a1ee9"),
                columns: new[] { "End", "Start" },
                values: new object[] { new DateTime(2024, 9, 25, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 9, 25, 15, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("ee98f544-e790-5e9f-aa15-18c1292a2ee7"),
                columns: new[] { "End", "Start" },
                values: new object[] { new DateTime(2024, 9, 25, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 9, 25, 16, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("ee98f545-e790-5e9f-aa15-18c2292a2ee6"),
                columns: new[] { "End", "Start" },
                values: new object[] { new DateTime(2024, 9, 25, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 9, 25, 12, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("ee98f546-e790-5e9f-aa15-18c2292a2ee5"),
                columns: new[] { "End", "Start" },
                values: new object[] { new DateTime(2024, 9, 25, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 9, 25, 16, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("ee98f547-e790-5e9f-aa15-18c2292a2ee4"),
                columns: new[] { "End", "Start" },
                values: new object[] { new DateTime(2024, 9, 25, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 9, 25, 16, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("ee98f548-e790-5e9f-aa15-18c2292a2ee3"),
                columns: new[] { "End", "Start" },
                values: new object[] { new DateTime(2024, 9, 24, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 9, 24, 14, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("ee98f540-e790-5e9f-aa15-18c2292a2ee2"),
                columns: new[] { "End", "Start" },
                values: new object[] { new DateTime(2024, 9, 13, 14, 0, 30, 791, DateTimeKind.Local), new DateTime(2024, 9, 13, 12, 30, 30, 791, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("ee98f541-e790-5e9f-aa15-18c2292a2ee8"),
                columns: new[] { "End", "Start" },
                values: new object[] { new DateTime(2024, 9, 9, 1, 0, 30, 791, DateTimeKind.Local), new DateTime(2024, 9, 9, 0, 30, 30, 791, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("ee98f542-e790-5e9f-aa15-18c2292a2ee9"),
                columns: new[] { "End", "Start" },
                values: new object[] { new DateTime(2024, 8, 24, 2, 0, 30, 791, DateTimeKind.Local), new DateTime(2024, 8, 24, 1, 30, 30, 791, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("ee98f543-e790-5e9f-aa15-18c2292a1ee9"),
                columns: new[] { "End", "Start" },
                values: new object[] { new DateTime(2024, 8, 24, 4, 0, 30, 791, DateTimeKind.Local), new DateTime(2024, 8, 24, 2, 30, 30, 791, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("ee98f544-e790-5e9f-aa15-18c1292a2ee7"),
                columns: new[] { "End", "Start" },
                values: new object[] { new DateTime(2024, 9, 11, 0, 0, 30, 791, DateTimeKind.Local), new DateTime(2024, 9, 10, 22, 30, 30, 791, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("ee98f545-e790-5e9f-aa15-18c2292a2ee6"),
                columns: new[] { "End", "Start" },
                values: new object[] { new DateTime(2024, 8, 29, 22, 0, 30, 791, DateTimeKind.Local), new DateTime(2024, 8, 29, 20, 30, 30, 791, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("ee98f546-e790-5e9f-aa15-18c2292a2ee5"),
                columns: new[] { "End", "Start" },
                values: new object[] { new DateTime(2024, 10, 23, 20, 0, 30, 791, DateTimeKind.Local), new DateTime(2024, 10, 23, 18, 30, 30, 791, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("ee98f547-e790-5e9f-aa15-18c2292a2ee4"),
                columns: new[] { "End", "Start" },
                values: new object[] { new DateTime(2024, 9, 23, 18, 0, 30, 791, DateTimeKind.Local), new DateTime(2024, 9, 23, 16, 30, 30, 791, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("ee98f548-e790-5e9f-aa15-18c2292a2ee3"),
                columns: new[] { "End", "Start" },
                values: new object[] { new DateTime(2024, 8, 23, 16, 0, 30, 791, DateTimeKind.Local), new DateTime(2024, 8, 23, 14, 30, 30, 791, DateTimeKind.Local) });
        }
    }
}

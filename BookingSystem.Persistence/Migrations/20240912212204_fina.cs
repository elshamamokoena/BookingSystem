using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookingSystem.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class fina : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AmenityCategories",
                columns: table => new
                {
                    AmenityCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AmenityCategories", x => x.AmenityCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "ConferenceRooms",
                columns: table => new
                {
                    ConferenceRoomId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tags = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConferenceRooms", x => x.ConferenceRoomId);
                });

            migrationBuilder.CreateTable(
                name: "ConsumableCategories",
                columns: table => new
                {
                    ConsumableCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AmountOfConsumables = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsumableCategories", x => x.ConsumableCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    EventId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Label = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Start = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    End = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.EventId);
                });

            migrationBuilder.CreateTable(
                name: "Stocks",
                columns: table => new
                {
                    StockId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stocks", x => x.StockId);
                });

            migrationBuilder.CreateTable(
                name: "Amenities",
                columns: table => new
                {
                    AmenityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AmenityCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ConferenceRoomId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Amenities", x => x.AmenityId);
                    table.ForeignKey(
                        name: "FK_Amenities_AmenityCategories_AmenityCategoryId",
                        column: x => x.AmenityCategoryId,
                        principalTable: "AmenityCategories",
                        principalColumn: "AmenityCategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Amenities_ConferenceRooms_ConferenceRoomId",
                        column: x => x.ConferenceRoomId,
                        principalTable: "ConferenceRooms",
                        principalColumn: "ConferenceRoomId");
                });

            migrationBuilder.CreateTable(
                name: "Consumables",
                columns: table => new
                {
                    ConsumableId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConsumableCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consumables", x => x.ConsumableId);
                    table.ForeignKey(
                        name: "FK_Consumables_ConsumableCategories_ConsumableCategoryId",
                        column: x => x.ConsumableCategoryId,
                        principalTable: "ConsumableCategories",
                        principalColumn: "ConsumableCategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    BookingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EventId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ConferenceRoomId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.BookingId);
                    table.ForeignKey(
                        name: "FK_Bookings_ConferenceRooms_ConferenceRoomId",
                        column: x => x.ConferenceRoomId,
                        principalTable: "ConferenceRooms",
                        principalColumn: "ConferenceRoomId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bookings_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "EventId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StockItems",
                columns: table => new
                {
                    StockItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StockNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StockId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ConsumableId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockItems", x => x.StockItemId);
                    table.ForeignKey(
                        name: "FK_StockItems_Consumables_ConsumableId",
                        column: x => x.ConsumableId,
                        principalTable: "Consumables",
                        principalColumn: "ConsumableId");
                    table.ForeignKey(
                        name: "FK_StockItems_Stocks_StockId",
                        column: x => x.StockId,
                        principalTable: "Stocks",
                        principalColumn: "StockId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StockEnquiries",
                columns: table => new
                {
                    StockEnquiryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BookingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsApproved = table.Column<bool>(type: "bit", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockEnquiries", x => x.StockEnquiryId);
                    table.ForeignKey(
                        name: "FK_StockEnquiries_Bookings_BookingId",
                        column: x => x.BookingId,
                        principalTable: "Bookings",
                        principalColumn: "BookingId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StockItemEnquiries",
                columns: table => new
                {
                    StockItemEnquiryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StockEnquiryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ConsumableId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    IsApproved = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockItemEnquiries", x => x.StockItemEnquiryId);
                    table.ForeignKey(
                        name: "FK_StockItemEnquiries_StockEnquiries_StockEnquiryId",
                        column: x => x.StockEnquiryId,
                        principalTable: "StockEnquiries",
                        principalColumn: "StockEnquiryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ConferenceRooms",
                columns: new[] { "ConferenceRoomId", "Capacity", "Created", "CreatedBy", "Description", "IsAvailable", "LastModified", "LastModifiedBy", "Name", "Tags" },
                values: new object[,]
                {
                    { new Guid("ee98f549-e790-5e9f-aa15-11c2292a1ee0"), 110, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Conference Room 11 Description", false, null, null, "Conference Room 11", "" },
                    { new Guid("ee98f549-e790-5e9f-aa15-11c2292a1ee1"), 120, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Conference Room 12 Description", false, null, null, "Conference Room 12", "" },
                    { new Guid("ee98f549-e790-5e9f-aa15-11c2292a1ee2"), 130, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Conference Room 13 Description", false, null, null, "Conference Room 13", "" },
                    { new Guid("ee98f549-e790-5e9f-aa15-11c2292a1ee3"), 140, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Conference Room 14 Description", false, null, null, "Conference Room 14", "" },
                    { new Guid("ee98f549-e790-5e9f-aa15-11c2292a1ee4"), 150, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Conference Room 15 Description", false, null, null, "Conference Room 15", "" },
                    { new Guid("ee98f549-e790-5e9f-aa15-11c2292a1ee5"), 160, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Conference Room 16 Description", false, null, null, "Conference Room 16", "" },
                    { new Guid("ee98f549-e790-5e9f-aa15-11c2292a1ee6"), 170, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Conference Room 17 Description", false, null, null, "Conference Room 17", "" },
                    { new Guid("ee98f549-e790-5e9f-aa15-18c2292a1ee1"), 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Conference Room 1 Description", true, null, null, "Conference Room 1", "" },
                    { new Guid("ee98f549-e790-5e9f-aa15-18c2292a2ee0"), 100, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Conference Room 10 Description", false, null, null, "Conference Room 10", "" },
                    { new Guid("ee98f549-e790-5e9f-aa15-18c2292a2ee2"), 20, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Conference Room 2 Description", true, null, null, "Conference Room 2", "" },
                    { new Guid("ee98f549-e790-5e9f-aa15-18c2292a2ee3"), 30, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Conference Room 3 Description", false, null, null, "Conference Room 3", "" },
                    { new Guid("ee98f549-e790-5e9f-aa15-18c2292a2ee4"), 40, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Conference Room 4 Description", true, null, null, "Conference Room 4", "" },
                    { new Guid("ee98f549-e790-5e9f-aa15-18c2292a2ee5"), 50, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Conference Room 5 Description", false, null, null, "Conference Room 5", "" },
                    { new Guid("ee98f549-e790-5e9f-aa15-18c2292a2ee6"), 60, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Conference Room 6 Description", false, null, null, "Conference Room 6", "" },
                    { new Guid("ee98f549-e790-5e9f-aa15-18c2292a2ee7"), 70, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Conference Room 7 Description", false, null, null, "Conference Room 7", "" },
                    { new Guid("ee98f549-e790-5e9f-aa15-18c2292a2ee8"), 80, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Conference Room 8 Description", false, null, null, "Conference Room 8", "" },
                    { new Guid("ee98f549-e790-5e9f-aa15-18c2292a2ee9"), 90, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Conference Room 9 Description", false, null, null, "Conference Room 9", "" }
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "EventId", "Created", "CreatedBy", "Description", "End", "Label", "LastModified", "LastModifiedBy", "Start", "Title" },
                values: new object[,]
                {
                    { new Guid("ee98f540-e790-5e9f-aa15-18c2292a2ee2"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "", new DateTimeOffset(new DateTime(2024, 9, 13, 12, 0, 30, 791, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "primary", null, null, new DateTimeOffset(new DateTime(2024, 9, 13, 10, 30, 30, 791, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Conference 2" },
                    { new Guid("ee98f541-e790-5e9f-aa15-18c2292a2ee8"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "", new DateTimeOffset(new DateTime(2024, 9, 8, 23, 0, 30, 791, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "success", null, null, new DateTimeOffset(new DateTime(2024, 9, 8, 22, 30, 30, 791, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Conference 8" },
                    { new Guid("ee98f542-e790-5e9f-aa15-18c2292a2ee9"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "", new DateTimeOffset(new DateTime(2024, 8, 24, 0, 0, 30, 791, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "danger", null, null, new DateTimeOffset(new DateTime(2024, 8, 23, 23, 30, 30, 791, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Conference 9" },
                    { new Guid("ee98f543-e790-5e9f-aa15-18c2292a1ee9"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "", new DateTimeOffset(new DateTime(2024, 8, 24, 2, 0, 30, 791, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "primary", null, null, new DateTimeOffset(new DateTime(2024, 8, 24, 0, 30, 30, 791, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Conference 10" },
                    { new Guid("ee98f544-e790-5e9f-aa15-18c1292a2ee7"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "", new DateTimeOffset(new DateTime(2024, 9, 10, 22, 0, 30, 791, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "warning", null, null, new DateTimeOffset(new DateTime(2024, 9, 10, 20, 30, 30, 791, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Conference 7" },
                    { new Guid("ee98f545-e790-5e9f-aa15-18c2292a2ee6"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "", new DateTimeOffset(new DateTime(2024, 8, 29, 20, 0, 30, 791, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "warning", null, null, new DateTimeOffset(new DateTime(2024, 8, 29, 18, 30, 30, 791, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Conference 6" },
                    { new Guid("ee98f546-e790-5e9f-aa15-18c2292a2ee5"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "", new DateTimeOffset(new DateTime(2024, 10, 23, 18, 0, 30, 791, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "warning", null, null, new DateTimeOffset(new DateTime(2024, 10, 23, 16, 30, 30, 791, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Conference 5" },
                    { new Guid("ee98f547-e790-5e9f-aa15-18c2292a2ee4"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "", new DateTimeOffset(new DateTime(2024, 9, 23, 16, 0, 30, 791, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "warning", null, null, new DateTimeOffset(new DateTime(2024, 9, 23, 14, 30, 30, 791, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Conference 4" },
                    { new Guid("ee98f548-e790-5e9f-aa15-18c2292a2ee3"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "", new DateTimeOffset(new DateTime(2024, 8, 23, 14, 0, 30, 791, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "primary", null, null, new DateTimeOffset(new DateTime(2024, 8, 23, 12, 30, 30, 791, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Conference 3" },
                    { new Guid("ee98f549-e190-5e9f-aa15-18c2292a2ee1"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Conference 1 Description", new DateTimeOffset(new DateTime(2024, 9, 23, 10, 0, 30, 791, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "primary", null, null, new DateTimeOffset(new DateTime(2024, 9, 23, 8, 30, 30, 791, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Conference 1" }
                });

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "BookingId", "ConferenceRoomId", "Created", "CreatedBy", "EventId", "LastModified", "LastModifiedBy" },
                values: new object[,]
                {
                    { new Guid("ee08f549-e790-5e9f-aa15-18c2292a2ee4"), new Guid("ee98f549-e790-5e9f-aa15-11c2292a1ee0"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("ee98f549-e190-5e9f-aa15-18c2292a2ee1"), null, null },
                    { new Guid("ee28f549-e790-5e9f-aa15-18c2292a2ee2"), new Guid("ee98f549-e790-5e9f-aa15-18c2292a2ee8"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("ee98f549-e190-5e9f-aa15-18c2292a2ee1"), null, null },
                    { new Guid("ee38f549-e790-5e9f-aa15-18c2292a2ee3"), new Guid("ee98f549-e790-5e9f-aa15-18c2292a2ee9"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("ee98f549-e190-5e9f-aa15-18c2292a2ee1"), null, null },
                    { new Guid("ee48f549-e790-5e9f-aa15-18c2292a2ee5"), new Guid("ee98f549-e790-5e9f-aa15-11c2292a1ee1"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("ee98f549-e190-5e9f-aa15-18c2292a2ee1"), null, null },
                    { new Guid("ee58f549-e790-5e9f-aa15-18c2292a2ee6"), new Guid("ee98f549-e790-5e9f-aa15-11c2292a1ee2"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("ee98f549-e190-5e9f-aa15-18c2292a2ee1"), null, null },
                    { new Guid("ee68f549-e790-5e9f-aa15-18c2292a2ee7"), new Guid("ee98f549-e790-5e9f-aa15-11c2292a1ee3"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("ee98f543-e790-5e9f-aa15-18c2292a1ee9"), null, null },
                    { new Guid("ee78f549-e790-5e9f-aa15-18c2292a2ee8"), new Guid("ee98f549-e790-5e9f-aa15-11c2292a1ee4"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("ee98f545-e790-5e9f-aa15-18c2292a2ee6"), null, null },
                    { new Guid("ee88f549-e790-5e9f-aa15-18c2292a2ee9"), new Guid("ee98f549-e790-5e9f-aa15-11c2292a1ee5"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("ee98f548-e790-5e9f-aa15-18c2292a2ee3"), null, null },
                    { new Guid("ee91f549-e790-5e9f-aa15-18c2292a1ee9"), new Guid("ee98f549-e790-5e9f-aa15-11c2292a1ee6"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("ee98f540-e790-5e9f-aa15-18c2292a2ee2"), null, null },
                    { new Guid("ee98f549-e790-5e9f-aa15-18c2292a1ee9"), new Guid("ee98f549-e790-5e9f-aa15-18c2292a2ee7"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("ee98f549-e190-5e9f-aa15-18c2292a2ee1"), null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Amenities_AmenityCategoryId",
                table: "Amenities",
                column: "AmenityCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Amenities_ConferenceRoomId",
                table: "Amenities",
                column: "ConferenceRoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_ConferenceRoomId",
                table: "Bookings",
                column: "ConferenceRoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_EventId",
                table: "Bookings",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Consumables_ConsumableCategoryId",
                table: "Consumables",
                column: "ConsumableCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_StockEnquiries_BookingId",
                table: "StockEnquiries",
                column: "BookingId");

            migrationBuilder.CreateIndex(
                name: "IX_StockItemEnquiries_StockEnquiryId",
                table: "StockItemEnquiries",
                column: "StockEnquiryId");

            migrationBuilder.CreateIndex(
                name: "IX_StockItems_ConsumableId",
                table: "StockItems",
                column: "ConsumableId");

            migrationBuilder.CreateIndex(
                name: "IX_StockItems_StockId",
                table: "StockItems",
                column: "StockId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Amenities");

            migrationBuilder.DropTable(
                name: "StockItemEnquiries");

            migrationBuilder.DropTable(
                name: "StockItems");

            migrationBuilder.DropTable(
                name: "AmenityCategories");

            migrationBuilder.DropTable(
                name: "StockEnquiries");

            migrationBuilder.DropTable(
                name: "Consumables");

            migrationBuilder.DropTable(
                name: "Stocks");

            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "ConsumableCategories");

            migrationBuilder.DropTable(
                name: "ConferenceRooms");

            migrationBuilder.DropTable(
                name: "Events");
        }
    }
}

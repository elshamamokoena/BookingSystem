using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookingSystem.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class bookin3 : Migration
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
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
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
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                name: "InternalCarts",
                columns: table => new
                {
                    CartId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InternalCarts", x => x.CartId);
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
                name: "Events",
                columns: table => new
                {
                    EventId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Label = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Start = table.Column<DateTime>(type: "datetime2", nullable: false),
                    End = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.EventId);
                    table.ForeignKey(
                        name: "FK_Events_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
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
                        principalColumn: "ConferenceRoomId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ConferenceRoomChangeEvents",
                columns: table => new
                {
                    ConferenceRoomChangeEventId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ConferenceRoomId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    ChangeType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConferenceRoomChangeEvents", x => x.ConferenceRoomChangeEventId);
                    table.ForeignKey(
                        name: "FK_ConferenceRoomChangeEvents_ConferenceRooms_ConferenceRoomId",
                        column: x => x.ConferenceRoomId,
                        principalTable: "ConferenceRooms",
                        principalColumn: "ConferenceRoomId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Consumables",
                columns: table => new
                {
                    ConsumableId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tags = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsVisible = table.Column<bool>(type: "bit", nullable: false),
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
                    BookingNumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ConferenceRoomId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                name: "CartItems",
                columns: table => new
                {
                    CartItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CartId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ConsumableId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => x.CartItemId);
                    table.ForeignKey(
                        name: "FK_CartItems_Consumables_ConsumableId",
                        column: x => x.ConsumableId,
                        principalTable: "Consumables",
                        principalColumn: "ConsumableId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartItems_InternalCarts_CartId",
                        column: x => x.CartId,
                        principalTable: "InternalCarts",
                        principalColumn: "CartId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StockItems",
                columns: table => new
                {
                    StockItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Sku = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConsumableId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    EnableStockManagement = table.Column<bool>(type: "bit", nullable: false),
                    StockId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                        principalColumn: "ConsumableId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StockItems_Stocks_StockId",
                        column: x => x.StockId,
                        principalTable: "Stocks",
                        principalColumn: "StockId");
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
                table: "AmenityCategories",
                columns: new[] { "AmenityCategoryId", "Created", "CreatedBy", "Description", "LastModified", "LastModifiedBy", "Name" },
                values: new object[,]
                {
                    { new Guid("ee18f129-e790-5e9f-aa15-18c2292a2ee8"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Amenity Category 2 Description", null, null, "WiFi" },
                    { new Guid("ee28f139-e790-5e9f-aa15-18c2292a2ee8"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Amenity Category 3 Description", null, null, "Digital Projectors" },
                    { new Guid("ee98f119-e790-5e9f-aa15-18c2292a2ee8"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Amenity Category 1 Description", null, null, "Video conferencing" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Created", "CreatedBy", "LastModified", "LastModifiedBy", "Name" },
                values: new object[,]
                {
                    { new Guid("ee98f549-e110-5e9f-aa15-18c2292a2ee1"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "Class, Training or Workshop" },
                    { new Guid("ee98f549-e120-5e9f-aa15-18c2292a2ee2"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "Conference" },
                    { new Guid("ee98f549-e130-5e9f-aa15-18c2292a2ee3"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "Meeting" },
                    { new Guid("ee98f549-e140-5e9f-aa15-18c2292a2ee4"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "Convention" },
                    { new Guid("ee98f549-e150-5e9f-aa15-18c2292a2ee5"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "Dinner or Gala" }
                });

            migrationBuilder.InsertData(
                table: "ConferenceRooms",
                columns: new[] { "ConferenceRoomId", "Capacity", "Created", "CreatedBy", "Description", "IsAvailable", "LastModified", "LastModifiedBy", "Name", "Status", "Tags" },
                values: new object[,]
                {
                    { new Guid("ee98f549-e790-5e9f-aa15-11c2292a1ee0"), 110, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Conference Room 11 Description", false, null, null, "Conference Room 11", "VacantAndNotBooked", "" },
                    { new Guid("ee98f549-e790-5e9f-aa15-11c2292a1ee1"), 120, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Conference Room 12 Description", false, null, null, "Conference Room 12", "VacantAndNotBooked", "" },
                    { new Guid("ee98f549-e790-5e9f-aa15-11c2292a1ee2"), 130, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Conference Room 13 Description", false, null, null, "Conference Room 13", "VacantAndNotBooked", "" },
                    { new Guid("ee98f549-e790-5e9f-aa15-11c2292a1ee3"), 140, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Conference Room 14 Description", false, null, null, "Conference Room 14", "VacantAndNotBooked", "" },
                    { new Guid("ee98f549-e790-5e9f-aa15-11c2292a1ee4"), 150, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Conference Room 15 Description", false, null, null, "Conference Room 15", "VacantAndNotBooked", "" },
                    { new Guid("ee98f549-e790-5e9f-aa15-11c2292a1ee5"), 160, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Conference Room 16 Description", false, null, null, "Conference Room 16", "VacantAndNotBooked", "" },
                    { new Guid("ee98f549-e790-5e9f-aa15-11c2292a1ee6"), 170, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Conference Room 17 Description", false, null, null, "Conference Room 17", "VacantAndNotBooked", "" },
                    { new Guid("ee98f549-e790-5e9f-aa15-18c2292a1ee1"), 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Conference Room 1 Description", false, null, null, "Conference Room 1", "VacantAndNotBooked", "" },
                    { new Guid("ee98f549-e790-5e9f-aa15-18c2292a2ee0"), 100, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Conference Room 10 Description", false, null, null, "Conference Room 10", "VacantAndNotBooked", "" },
                    { new Guid("ee98f549-e790-5e9f-aa15-18c2292a2ee2"), 20, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Conference Room 2 Description", false, null, null, "Conference Room 2", "VacantAndNotBooked", "" },
                    { new Guid("ee98f549-e790-5e9f-aa15-18c2292a2ee3"), 30, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Conference Room 3 Description", false, null, null, "Conference Room 3", "VacantAndNotBooked", "" },
                    { new Guid("ee98f549-e790-5e9f-aa15-18c2292a2ee4"), 40, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Conference Room 4 Description", false, null, null, "Conference Room 4", "VacantAndNotBooked", "" },
                    { new Guid("ee98f549-e790-5e9f-aa15-18c2292a2ee5"), 50, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Conference Room 5 Description", false, null, null, "Conference Room 5", "VacantAndNotBooked", "" },
                    { new Guid("ee98f549-e790-5e9f-aa15-18c2292a2ee6"), 60, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Conference Room 6 Description", false, null, null, "Conference Room 6", "VacantAndNotBooked", "" },
                    { new Guid("ee98f549-e790-5e9f-aa15-18c2292a2ee7"), 70, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Conference Room 7 Description", false, null, null, "Conference Room 7", "VacantAndNotBooked", "" },
                    { new Guid("ee98f549-e790-5e9f-aa15-18c2292a2ee8"), 80, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Conference Room 8 Description", false, null, null, "Conference Room 8", "VacantAndNotBooked", "" },
                    { new Guid("ee98f549-e790-5e9f-aa15-18c2292a2ee9"), 90, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Conference Room 9 Description", false, null, null, "Conference Room 9", "VacantAndNotBooked", "" }
                });

            migrationBuilder.InsertData(
                table: "ConsumableCategories",
                columns: new[] { "ConsumableCategoryId", "AmountOfConsumables", "Created", "CreatedBy", "Description", "LastModified", "LastModifiedBy", "Name" },
                values: new object[,]
                {
                    { new Guid("ee48f549-e790-5e9f-aa15-18c2292a2ee9"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "", null, null, "Markers & Highlighters" },
                    { new Guid("ee58f549-e790-5e9f-aa15-18c2292a2ee9"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "", null, null, "Pens & Refills" },
                    { new Guid("ee68f549-e790-5e9f-aa15-18c2292a2ee9"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "", null, null, "Technical instruments" }
                });

            migrationBuilder.InsertData(
                table: "Amenities",
                columns: new[] { "AmenityId", "AmenityCategoryId", "Amount", "ConferenceRoomId", "Created", "CreatedBy", "Description", "IsAvailable", "LastModified", "LastModifiedBy", "Name" },
                values: new object[,]
                {
                    { new Guid("ee98f149-e790-5e9f-aa15-18c2292a2ee8"), new Guid("ee98f119-e790-5e9f-aa15-18c2292a2ee8"), 1, new Guid("ee98f549-e790-5e9f-aa15-18c2292a1ee1"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Video Conferencing Description", true, null, null, "Video Conferencing Equipment 1" },
                    { new Guid("ee98f159-e790-5e9f-aa15-18c2292a2ee8"), new Guid("ee98f119-e790-5e9f-aa15-18c2292a2ee8"), 1, new Guid("ee98f549-e790-5e9f-aa15-18c2292a1ee1"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Video Conferencing Description", true, null, null, "Video Conferencing Equipment 3" },
                    { new Guid("ee98f169-e790-5e9f-aa15-18c2292a2ee8"), new Guid("ee98f119-e790-5e9f-aa15-18c2292a2ee8"), 1, new Guid("ee98f549-e790-5e9f-aa15-18c2292a1ee1"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Video Conferencing Description", true, null, null, "Video Conferencing Equipment 1" },
                    { new Guid("ee98f179-e790-5e9f-aa15-18c2292a2ee8"), new Guid("ee28f139-e790-5e9f-aa15-18c2292a2ee8"), 1, new Guid("ee98f549-e790-5e9f-aa15-18c2292a1ee1"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "The best projector ever", true, null, null, "Projector 1" },
                    { new Guid("ee98f189-e790-5e9f-aa15-18c2292a2ee8"), new Guid("ee18f129-e790-5e9f-aa15-18c2292a2ee8"), 1, new Guid("ee98f549-e790-5e9f-aa15-18c2292a1ee1"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "That 6G router", true, null, null, "Router 1" }
                });

            migrationBuilder.InsertData(
                table: "Consumables",
                columns: new[] { "ConsumableId", "ConsumableCategoryId", "Created", "CreatedBy", "Description", "ImageUrl", "IsVisible", "LastModified", "LastModifiedBy", "Name", "Tags" },
                values: new object[,]
                {
                    { new Guid("ee18f549-e790-5e9f-aa15-18c2292a2ee9"), new Guid("ee58f549-e790-5e9f-aa15-18c2292a2ee9"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "s simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's ", "", false, null, null, "Pen", "" },
                    { new Guid("ee38f549-e790-5e9f-aa15-18c2292a2ee9"), new Guid("ee58f549-e790-5e9f-aa15-18c2292a2ee9"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "s simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's ", "", false, null, null, "Pencil", "" },
                    { new Guid("ee98f549-e790-5e9f-aa15-18c2292a2ee8"), new Guid("ee48f549-e790-5e9f-aa15-18c2292a2ee9"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "s simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's ", "", false, null, null, "Marker", "" }
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "EventId", "CategoryId", "Created", "CreatedBy", "Description", "End", "Label", "LastModified", "LastModifiedBy", "Start", "Title" },
                values: new object[,]
                {
                    { new Guid("ee11f549-e190-5e9f-aa15-18c2292a2ee1"), new Guid("ee98f549-e150-5e9f-aa15-18c2292a2ee5"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Conference 1 copy Description", new DateTime(2024, 9, 23, 12, 0, 0, 0, DateTimeKind.Unspecified), "primary", null, null, new DateTime(2024, 9, 23, 8, 30, 0, 0, DateTimeKind.Unspecified), "Conference 1 Copy" },
                    { new Guid("ee98f540-e790-5e9f-aa15-18c2292a2ee2"), new Guid("ee98f549-e150-5e9f-aa15-18c2292a2ee5"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "", new DateTime(2024, 9, 24, 12, 0, 0, 0, DateTimeKind.Unspecified), "primary", null, null, new DateTime(2024, 9, 24, 10, 0, 0, 0, DateTimeKind.Unspecified), "Conference 2" },
                    { new Guid("ee98f541-e790-5e9f-aa15-18c2292a2ee8"), new Guid("ee98f549-e130-5e9f-aa15-18c2292a2ee3"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "", new DateTime(2024, 9, 26, 12, 0, 0, 0, DateTimeKind.Unspecified), "success", null, null, new DateTime(2024, 9, 26, 8, 0, 0, 0, DateTimeKind.Unspecified), "Conference 8" },
                    { new Guid("ee98f542-e790-5e9f-aa15-18c2292a2ee9"), new Guid("ee98f549-e130-5e9f-aa15-18c2292a2ee3"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "", new DateTime(2024, 9, 25, 16, 0, 0, 0, DateTimeKind.Unspecified), "danger", null, null, new DateTime(2024, 9, 26, 14, 0, 0, 0, DateTimeKind.Unspecified), "Conference 9" },
                    { new Guid("ee98f543-e790-5e9f-aa15-18c2292a1ee9"), new Guid("ee98f549-e130-5e9f-aa15-18c2292a2ee3"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "", new DateTime(2024, 9, 25, 16, 0, 0, 0, DateTimeKind.Unspecified), "primary", null, null, new DateTime(2024, 9, 25, 15, 0, 0, 0, DateTimeKind.Unspecified), "Conference 10" },
                    { new Guid("ee98f544-e790-5e9f-aa15-18c1292a2ee7"), new Guid("ee98f549-e130-5e9f-aa15-18c2292a2ee3"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "", new DateTime(2024, 9, 25, 17, 0, 0, 0, DateTimeKind.Unspecified), "warning", null, null, new DateTime(2024, 9, 25, 16, 0, 0, 0, DateTimeKind.Unspecified), "Conference 7" },
                    { new Guid("ee98f545-e790-5e9f-aa15-18c2292a2ee6"), new Guid("ee98f549-e130-5e9f-aa15-18c2292a2ee3"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "", new DateTime(2024, 9, 25, 14, 0, 0, 0, DateTimeKind.Unspecified), "warning", null, null, new DateTime(2024, 9, 25, 12, 0, 0, 0, DateTimeKind.Unspecified), "Conference 6" },
                    { new Guid("ee98f546-e790-5e9f-aa15-18c2292a2ee5"), new Guid("ee98f549-e140-5e9f-aa15-18c2292a2ee4"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "", new DateTime(2024, 9, 25, 16, 0, 0, 0, DateTimeKind.Unspecified), "warning", null, null, new DateTime(2024, 9, 25, 16, 0, 0, 0, DateTimeKind.Unspecified), "Conference 5" },
                    { new Guid("ee98f547-e790-5e9f-aa15-18c2292a2ee4"), new Guid("ee98f549-e140-5e9f-aa15-18c2292a2ee4"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "", new DateTime(2024, 9, 25, 18, 0, 0, 0, DateTimeKind.Unspecified), "warning", null, null, new DateTime(2024, 9, 25, 16, 0, 0, 0, DateTimeKind.Unspecified), "Conference 4" },
                    { new Guid("ee98f548-e790-5e9f-aa15-18c2292a2ee3"), new Guid("ee98f549-e150-5e9f-aa15-18c2292a2ee5"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "", new DateTime(2024, 9, 24, 15, 0, 0, 0, DateTimeKind.Unspecified), "primary", null, null, new DateTime(2024, 9, 24, 14, 0, 0, 0, DateTimeKind.Unspecified), "Conference 3" },
                    { new Guid("ee98f549-e190-5e9f-aa15-18c2292a2ee1"), new Guid("ee98f549-e150-5e9f-aa15-18c2292a2ee5"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Conference 1 Description", new DateTime(2024, 9, 23, 10, 0, 0, 0, DateTimeKind.Unspecified), "primary", null, null, new DateTime(2024, 9, 23, 8, 0, 0, 0, DateTimeKind.Unspecified), "Conference 1" }
                });

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "BookingId", "ConferenceRoomId", "Created", "CreatedBy", "EventId", "LastModified", "LastModifiedBy", "Status" },
                values: new object[,]
                {
                    { new Guid("ee08f549-e790-5e9f-aa15-18c2292a2ee4"), new Guid("ee98f549-e790-5e9f-aa15-11c2292a1ee0"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("ee98f549-e190-5e9f-aa15-18c2292a2ee1"), null, null, "Cancelled" },
                    { new Guid("ee28f549-e790-5e9f-aa15-18c2292a2ee2"), new Guid("ee98f549-e790-5e9f-aa15-18c2292a1ee1"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("ee98f549-e190-5e9f-aa15-18c2292a2ee1"), null, null, "Pending" },
                    { new Guid("ee38f549-e790-5e9f-aa15-18c2292a2ee3"), new Guid("ee98f549-e790-5e9f-aa15-18c2292a1ee1"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("ee98f549-e190-5e9f-aa15-18c2292a2ee1"), null, null, "Pending" },
                    { new Guid("ee48f549-e790-5e9f-aa15-18c2292a2ee5"), new Guid("ee98f549-e790-5e9f-aa15-11c2292a1ee1"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("ee98f549-e190-5e9f-aa15-18c2292a2ee1"), null, null, "Pending" },
                    { new Guid("ee58f549-e790-5e9f-aa15-18c2292a2ee6"), new Guid("ee98f549-e790-5e9f-aa15-11c2292a1ee2"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("ee98f549-e190-5e9f-aa15-18c2292a2ee1"), null, null, "Approved" },
                    { new Guid("ee68f549-e790-5e9f-aa15-18c2292a2ee7"), new Guid("ee98f549-e790-5e9f-aa15-11c2292a1ee3"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("ee98f549-e190-5e9f-aa15-18c2292a2ee1"), null, null, "Cancelled" },
                    { new Guid("ee78f549-e790-5e9f-aa15-18c2292a2ee8"), new Guid("ee98f549-e790-5e9f-aa15-11c2292a1ee4"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("ee98f549-e190-5e9f-aa15-18c2292a2ee1"), null, null, "Approved" },
                    { new Guid("ee88f549-e790-5e9f-aa15-18c2292a2ee9"), new Guid("ee98f549-e790-5e9f-aa15-11c2292a1ee5"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("ee98f549-e190-5e9f-aa15-18c2292a2ee1"), null, null, "Pending" },
                    { new Guid("ee91f549-e790-5e9f-aa15-18c2292a1ee9"), new Guid("ee98f549-e790-5e9f-aa15-11c2292a1ee6"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("ee98f549-e190-5e9f-aa15-18c2292a2ee1"), null, null, "Approved" },
                    { new Guid("ee98f549-e790-5e9f-aa15-18c2292a1ee9"), new Guid("ee98f549-e790-5e9f-aa15-18c2292a1ee1"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("ee98f549-e190-5e9f-aa15-18c2292a2ee1"), null, null, "Pending" }
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
                name: "IX_CartItems_CartId",
                table: "CartItems",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_ConsumableId",
                table: "CartItems",
                column: "ConsumableId");

            migrationBuilder.CreateIndex(
                name: "IX_ConferenceRoomChangeEvents_ConferenceRoomId",
                table: "ConferenceRoomChangeEvents",
                column: "ConferenceRoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Consumables_ConsumableCategoryId",
                table: "Consumables",
                column: "ConsumableCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_CategoryId",
                table: "Events",
                column: "CategoryId");

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
                name: "CartItems");

            migrationBuilder.DropTable(
                name: "ConferenceRoomChangeEvents");

            migrationBuilder.DropTable(
                name: "StockItemEnquiries");

            migrationBuilder.DropTable(
                name: "StockItems");

            migrationBuilder.DropTable(
                name: "AmenityCategories");

            migrationBuilder.DropTable(
                name: "InternalCarts");

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

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}

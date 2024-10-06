using BookingSystem.Application.Contracts.Services;
using BookingSystem.Domain.Common;
using BookingSystem.Domain.Entities.Amenities;
using BookingSystem.Domain.Entities.ConferenceRooms;
using BookingSystem.Domain.Entities.Consumables;
using BookingSystem.Domain.Entities.Events;
using BookingSystem.Domain.Entities.Inventory;
using BookingSystem.Domain.Entities.Bookings;
using BookingSystem.Persistence.Configurations.Bookings;
using BookingSystem.Persistence.Configurations.Stock;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Persistence.DbContexts
{
    public class BookingSystemDbContext: DbContext
    {
        private readonly IAuthenticatedUserService ?_authenticatedUserService;
        public BookingSystemDbContext(DbContextOptions<BookingSystemDbContext> options) : base( options) { }
        public BookingSystemDbContext(DbContextOptions<BookingSystemDbContext> options, 
            IAuthenticatedUserService authenticatedUserService) : base(options)
        {
            _authenticatedUserService = authenticatedUserService;
        }

        // Any instance of this DbContext tracks changes made to the following entities from the domain

        public DbSet<Event> Events { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<ConferenceRoom> ConferenceRooms { get; set; }
        public DbSet<Amenity> Amenities { get; set; }
        public DbSet<AmenityCategory> AmenityCategories { get; set; }
        public DbSet<Consumable> Consumables { get; set; }
        public DbSet<ConsumableCategory> ConsumableCategories { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<StockItem> StockItems { get; set; }
        public DbSet<StockEnquiry> StockEnquiries { get; set; }

        public DbSet<StockItemEnquiry> StockItemEnquiries { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BookingSystemDbContext).Assembly);
            modelBuilder.ApplyConfiguration(new BookingConfiguration());
            modelBuilder.ApplyConfiguration(new StockConfiguration());



            modelBuilder.Entity<ConferenceRoom>().HasData(
                new ConferenceRoom
                {
                    ConferenceRoomId = Guid.Parse("EE98F549-E790-5E9F-AA15-18C2292A1EE1"),
                    Name = "Conference Room 1",
                    Description = "Conference Room 1 Description",
                    Capacity = 10,
                },
                new ConferenceRoom
                {
                    ConferenceRoomId = Guid.Parse("EE98F549-E790-5E9F-AA15-18C2292A2EE2"),
                    Name = "Conference Room 2",
                    Description = "Conference Room 2 Description",
                    Capacity = 20,
                },
                new ConferenceRoom
                {
                    ConferenceRoomId = Guid.Parse("EE98F549-E790-5E9F-AA15-18C2292A2EE3"),
                    Name = "Conference Room 3",
                    Description = "Conference Room 3 Description",
                    Capacity = 30,
                },
                new ConferenceRoom
                {
                    ConferenceRoomId = Guid.Parse("EE98F549-E790-5E9F-AA15-18C2292A2EE4"),
                    Name = "Conference Room 4",
                    Description = "Conference Room 4 Description",
                    Capacity = 40,
                },
                new ConferenceRoom
                {
                    ConferenceRoomId = Guid.Parse("EE98F549-E790-5E9F-AA15-18C2292A2EE5"),
                    Name = "Conference Room 5",
                    Description = "Conference Room 5 Description",
                    Capacity = 50,
                }, 
                new ConferenceRoom
                {
                    ConferenceRoomId = Guid.Parse("EE98F549-E790-5E9F-AA15-18C2292A2EE6"),
                    Name = "Conference Room 6",
                    Description = "Conference Room 6 Description",
                    Capacity = 60,
                },
                new ConferenceRoom
                {
                    ConferenceRoomId = Guid.Parse("EE98F549-E790-5E9F-AA15-18C2292A2EE7"),
                    Name = "Conference Room 7",
                    Description = "Conference Room 7 Description",
                    Capacity = 70,
                },
                new ConferenceRoom
                {
                    ConferenceRoomId = Guid.Parse("EE98F549-E790-5E9F-AA15-18C2292A2EE8"),
                    Name = "Conference Room 8",
                    Description = "Conference Room 8 Description",
                    Capacity = 80,
                },
                new ConferenceRoom
                {
                    ConferenceRoomId = Guid.Parse("EE98F549-E790-5E9F-AA15-18C2292A2EE9"),
                    Name = "Conference Room 9",
                    Description = "Conference Room 9 Description",
                    Capacity = 90,
                },
                new ConferenceRoom
                {
                    ConferenceRoomId = Guid.Parse("EE98F549-E790-5E9F-AA15-18C2292A2EE0"),
                    Name = "Conference Room 10",
                    Description = "Conference Room 10 Description",
                    Capacity = 100,
                },
                new ConferenceRoom
                {
                    ConferenceRoomId = Guid.Parse("EE98F549-E790-5E9F-AA15-11C2292A1EE0"),
                    Name = "Conference Room 11",
                    Description = "Conference Room 11 Description",
                    Capacity = 110,
                },
                new ConferenceRoom
                {
                    ConferenceRoomId = Guid.Parse("EE98F549-E790-5E9F-AA15-11C2292A1EE1"),
                    Name = "Conference Room 12",
                    Description = "Conference Room 12 Description",
                    Capacity = 120,
                },
                new ConferenceRoom
                {
                    ConferenceRoomId = Guid.Parse("EE98F549-E790-5E9F-AA15-11C2292A1EE2"),
                    Name = "Conference Room 13",
                    Description = "Conference Room 13 Description",
                    Capacity = 130,
                },
                new ConferenceRoom
                {
                    ConferenceRoomId = Guid.Parse("EE98F549-E790-5E9F-AA15-11C2292A1EE3"),
                    Name = "Conference Room 14",
                    Description = "Conference Room 14 Description",
                    Capacity = 140,
                },
                new ConferenceRoom
                {
                    ConferenceRoomId = Guid.Parse("EE98F549-E790-5E9F-AA15-11C2292A1EE4"),
                    Name = "Conference Room 15",
                    Description = "Conference Room 15 Description",
                    Capacity = 150,
                },
                new ConferenceRoom
                {
                    ConferenceRoomId = Guid.Parse("EE98F549-E790-5E9F-AA15-11C2292A1EE5"),
                    Name = "Conference Room 16",
                    Description = "Conference Room 16 Description",
                    Capacity = 160,
                },
                    new ConferenceRoom
                    {
                        ConferenceRoomId = Guid.Parse("EE98F549-E790-5E9F-AA15-11C2292A1EE6"),
                        Name = "Conference Room 17",
                        Description = "Conference Room 17 Description",
                        Capacity = 170,
                    }

                );

modelBuilder.Entity<Category>().HasData(
    new Category
{
    CategoryId = Guid.Parse("EE98F549-E110-5E9F-AA15-18C2292A2EE1"),
    Name = "Class, Training or Workshop"
},
new Category
{
    CategoryId = Guid.Parse("EE98F549-E120-5E9F-AA15-18C2292A2EE2"),
    Name = "Conference"
},
new Category
{
    CategoryId = Guid.Parse("EE98F549-E130-5E9F-AA15-18C2292A2EE3"),
    Name = "Meeting"
},
new Category
{
    CategoryId = Guid.Parse("EE98F549-E140-5E9F-AA15-18C2292A2EE4"),
    Name = "Convention"
},
new Category
{
    CategoryId = Guid.Parse("EE98F549-E150-5E9F-AA15-18C2292A2EE5"),
    Name = "Dinner or Gala"
});


            modelBuilder.Entity<Event>().HasData(
                new Event
                {
                    EventId = Guid.Parse("EE98F549-E190-5E9F-AA15-18C2292A2EE1"),
                    Title = "Conference 1",
                    Start= DateTime.Parse("2024/09/23 08:00:00"),

                    End = DateTime.Parse("2024/09/23 10:00:00"),

                    Label = "primary",
                    Description = "Conference 1 Description",
                    CategoryId = Guid.Parse("EE98F549-E150-5E9F-AA15-18C2292A2EE5"),

                }, 
                new Event
                {
                    EventId = Guid.Parse("EE11F549-E190-5E9F-AA15-18C2292A2EE1"),
                    Title = "Conference 1 Copy",
                    Start = DateTime.Parse("2024/09/23 08:30:00"),

                    End = DateTime .Parse("2024/09/23 12:00:00"),
                    Label = "primary",
                    Description = "Conference 1 copy Description",
                    CategoryId = Guid.Parse("EE98F549-E150-5E9F-AA15-18C2292A2EE5"),
                },
                new Event
                {

                    EventId = Guid.Parse("EE98F540-E790-5E9F-AA15-18C2292A2EE2"),
                    Title = "Conference 2",
                    Start = DateTime.Parse("2024/09/24 10:00:00"),
                    End = DateTime.Parse("2024/09/24 12:00:00"),
                    Label = "primary",
                    CategoryId = Guid.Parse("EE98F549-E150-5E9F-AA15-18C2292A2EE5"),

                },
                new Event
                {
                    EventId = Guid.Parse("EE98F548-E790-5E9F-AA15-18C2292A2EE3"),
                    Title = "Conference 3",
                    Start = DateTime.Parse("2024/09/24 14:00:00"),
                    End = DateTime.Parse("2024/09/24 15:00:00"),
                    Label = "primary",
                    CategoryId = Guid.Parse("EE98F549-E150-5E9F-AA15-18C2292A2EE5"),

                },
                new Event
                {
                    EventId = Guid.Parse("EE98F547-E790-5E9F-AA15-18C2292A2EE4"),
                    Title = "Conference 4",
                    Start = DateTime.Parse("2024/09/25 16:00:00"),
                    End= DateTime.Parse("2024/09/25 18:00:00"),
                    Label = "warning",
                    CategoryId = Guid.Parse("EE98F549-E140-5E9F-AA15-18C2292A2EE4"),

                },
                new Event
                {
                    EventId = Guid.Parse("EE98F546-E790-5E9F-AA15-18C2292A2EE5"),
                    Title = "Conference 5",
                    Start = DateTime.Parse("2024/09/25 16:00:00"),
                    End = DateTime.Parse("2024/09/25 16:00:00"),
                    Label = "warning",
                    CategoryId = Guid.Parse("EE98F549-E140-5E9F-AA15-18C2292A2EE4"),

                },
                new Event
                {
                    EventId = Guid.Parse("EE98F545-E790-5E9F-AA15-18C2292A2EE6"),
                    Title = "Conference 6",
                    Start = DateTime.Parse("2024/09/25 12:00:00"),
                    End = DateTime.Parse("2024/09/25 14:00:00"),
                    Label = "warning",
                    CategoryId = Guid.Parse("EE98F549-E130-5E9F-AA15-18C2292A2EE3"),

                },
                new Event
                {
                    EventId = Guid.Parse("EE98F544-E790-5E9F-AA15-18C1292A2EE7"),
                    Title = "Conference 7",
                    Start = DateTime.Parse("2024/09/25 16:00:00"),
                    End = DateTime.Parse("2024/09/25 17:00:00"),
                    Label = "warning",
                    CategoryId = Guid.Parse("EE98F549-E130-5E9F-AA15-18C2292A2EE3"),
                },
                new Event
                {
                    EventId = Guid.Parse("EE98F541-E790-5E9F-AA15-18C2292A2EE8"),
                    Title = "Conference 8",
                    Start = DateTime.Parse("2024/09/26 08:00:00"),
                    End = DateTime.Parse("2024/09/26 12:00:00"),
                    Label = "success",

                    CategoryId = Guid.Parse("EE98F549-E130-5E9F-AA15-18C2292A2EE3"),

                },
                new Event
                {
                    EventId = Guid.Parse("EE98F542-E790-5E9F-AA15-18C2292A2EE9"),
                    Title = "Conference 9",
                    Start = DateTime.Parse("2024/09/26 14:00:00"),
                    End = DateTime.Parse("2024/09/25 16:00:00"),
                    Label = "danger",
                    CategoryId = Guid.Parse("EE98F549-E130-5E9F-AA15-18C2292A2EE3"),

                },
                new Event
                {
                    EventId = Guid.Parse("EE98F543-E790-5E9F-AA15-18C2292A1EE9"),
                    Title = "Conference 10",
                    Start = DateTime.Parse("2024/09/25 15:00:00"),
                    End = DateTime.Parse("2024/09/25 16:00:00"),
                    Label = "primary",
                    CategoryId = Guid.Parse("EE98F549-E130-5E9F-AA15-18C2292A2EE3"),
                }
            );

            modelBuilder.Entity<Booking>().HasData(

                //an event can have multiple bookings
                //but each booking is for a single event and a single conference room

                // Conference 5 will be hosted in 5 different rooms
                new Booking
                {
                    BookingId = Guid.Parse("EE98F549-E790-5E9F-AA15-18C2292A1EE9"),
                    EventId = Guid.Parse("EE98F549-E190-5E9F-AA15-18C2292A2EE1"),
                    ConferenceRoomId = Guid.Parse("EE98F549-E790-5E9F-AA15-18C2292A2EE7"),
                    Status = nameof(BookingStatus.Pending)
                },
                new Booking
                {
                    BookingId = Guid.Parse("EE28F549-E790-5E9F-AA15-18C2292A2EE2"),
                    EventId = Guid.Parse("EE98F549-E190-5E9F-AA15-18C2292A2EE1"),
                    ConferenceRoomId = Guid.Parse("EE98F549-E790-5E9F-AA15-18C2292A2EE8"),
                    Status = nameof(BookingStatus.Pending)

                },
                new Booking
                {
                    BookingId = Guid.Parse("EE38F549-E790-5E9F-AA15-18C2292A2EE3"),
                    EventId = Guid.Parse("EE98F549-E190-5E9F-AA15-18C2292A2EE1"),
                    ConferenceRoomId = Guid.Parse("EE98F549-E790-5E9F-AA15-18C2292A2EE9"),
                    Status = nameof(BookingStatus.Pending)
                },
                new Booking
                {
                    BookingId = Guid.Parse("EE08F549-E790-5E9F-AA15-18C2292A2EE4"),
                    EventId = Guid.Parse("EE98F549-E190-5E9F-AA15-18C2292A2EE1"),
                    ConferenceRoomId = Guid.Parse("EE98F549-E790-5E9F-AA15-11C2292A1EE0"),
                    Status = nameof(BookingStatus.Cancelled)
                },
                new Booking
                {
                    BookingId = Guid.Parse("EE48F549-E790-5E9F-AA15-18C2292A2EE5"),
                    EventId = Guid.Parse("EE98F549-E190-5E9F-AA15-18C2292A2EE1"),
                    ConferenceRoomId = Guid.Parse("EE98F549-E790-5E9F-AA15-11C2292A1EE1"),
                    Status = nameof(BookingStatus.Pending)
                },
                new Booking
                {
                    BookingId = Guid.Parse("EE58F549-E790-5E9F-AA15-18C2292A2EE6"),
                    EventId = Guid.Parse("EE98F549-E190-5E9F-AA15-18C2292A2EE1"),
                    ConferenceRoomId = Guid.Parse("EE98F549-E790-5E9F-AA15-11C2292A1EE2"),
                    Status = nameof(BookingStatus.Approved)
                },
                new Booking
                {
                    BookingId = Guid.Parse("EE68F549-E790-5E9F-AA15-18C2292A2EE7"),
                    EventId = Guid.Parse("EE98F549-E190-5E9F-AA15-18C2292A2EE1"),
                    ConferenceRoomId = Guid.Parse("EE98F549-E790-5E9F-AA15-11C2292A1EE3"),
                    Status = nameof(BookingStatus.Cancelled)
                },
                new Booking
                {
                    BookingId = Guid.Parse("EE78F549-E790-5E9F-AA15-18C2292A2EE8"),
                    EventId = Guid.Parse("EE98F549-E190-5E9F-AA15-18C2292A2EE1"),
                    ConferenceRoomId = Guid.Parse("EE98F549-E790-5E9F-AA15-11C2292A1EE4"),
                    Status = nameof(BookingStatus.Approved)

                },
                new Booking
                {
                    BookingId = Guid.Parse("EE88F549-E790-5E9F-AA15-18C2292A2EE9"),
                    EventId = Guid.Parse("EE98F549-E190-5E9F-AA15-18C2292A2EE1"),
                    ConferenceRoomId = Guid.Parse("EE98F549-E790-5E9F-AA15-11C2292A1EE5"),
                    Status = nameof(BookingStatus.Pending)
                },
                new Booking
                {
                    BookingId = Guid.Parse("EE91F549-E790-5E9F-AA15-18C2292A1EE9"),
                    EventId = Guid.Parse("EE98F549-E190-5E9F-AA15-18C2292A2EE1"),
                    ConferenceRoomId = Guid.Parse("EE98F549-E790-5E9F-AA15-11C2292A1EE6"),
                    Status = nameof(BookingStatus.Approved)
                }
           );


            modelBuilder.Entity<ConsumableCategory>().HasData(
                new ConsumableCategory
                {
                    ConsumableCategoryId = Guid.Parse("EE48F549-E790-5E9F-AA15-18C2292A2EE9"),
                    Name = "Markers"
                },
                new ConsumableCategory
                {
                    ConsumableCategoryId = Guid.Parse("EE58F549-E790-5E9F-AA15-18C2292A2EE9"),
                    Name = "Pens"
                }
                );

            //modelBuilder.Entity<StockEnquiry>().HasData(
            //    new StockEnquiry
            //    {
            //        StockEnquiryId = Guid.Parse("EE98F549-E790-5E9F-AA15-18C2292A2EE6"),
            //        BookingId = Guid.Parse("EE98F549-E790-5E9F-AA15-18C2292A2EE1")
            //    }
            //);

            //modelBuilder.Entity<StockItemEnquiry>().HasData(
            //    new StockItemEnquiry
            //    {
            //        StockItemEnquiryId = Guid.Parse("EE98F549-E790-5E9F-AA15-18C2292A2EE7"),
            //        StockEnquiryId = Guid.Parse("EE98F549-E790-5E9F-AA15-18C2292A2EE6"),
            //        ConsumableId = Guid.Parse("EE98F549-E790-5E9F-AA15-18C2292A2EE8"),
            //        Quantity = 5,
            //    },
            //    new StockItemEnquiry
            //    {
            //        StockItemEnquiryId = Guid.Parse("EE98F549-E790-5E9F-AA15-18C2292A2EE9"),
            //        StockEnquiryId = Guid.Parse("EE98F549-E790-5E9F-AA15-18C2292A2EE6"),
            //        ConsumableId = Guid.Parse("EE18F549-E790-5E9F-AA15-18C2292A2EE9"),
            //        Quantity = 10,
            //    },
            //    new StockItemEnquiry
            //    {
            //        StockItemEnquiryId = Guid.Parse("EE28F549-E790-5E9F-AA15-18C2292A2EE9"),
            //        StockEnquiryId = Guid.Parse("EE98F549-E790-5E9F-AA15-18C2292A2EE6"),
            //        ConsumableId = Guid.Parse("EE38F549-E790-5E9F-AA15-18C2292A2EE9"),
            //        Quantity = 15,
            //    }
            //);
            modelBuilder.Entity<Consumable>().HasData(
                new Consumable
                {
                    ConsumableId = Guid.Parse("EE98F549-E790-5E9F-AA15-18C2292A2EE8"),
                    Name = "Marker",
                    ConsumableCategoryId = Guid.Parse("EE48F549-E790-5E9F-AA15-18C2292A2EE9"),
                    Description = "s simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's "
                },
                new Consumable
                {
                    ConsumableId = Guid.Parse("EE18F549-E790-5E9F-AA15-18C2292A2EE9"),
                    Name = "Pen",
                    ConsumableCategoryId = Guid.Parse("EE58F549-E790-5E9F-AA15-18C2292A2EE9"),
                    Description = "s simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's "

                },
                new Consumable
                {
                    ConsumableId = Guid.Parse("EE38F549-E790-5E9F-AA15-18C2292A2EE9"),
                    Name = "Pencil",
                    ConsumableCategoryId = Guid.Parse("EE58F549-E790-5E9F-AA15-18C2292A2EE9"),
                    Description = "s simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's "
                }
                );


            //modelBuilder.Entity<StockItem>().HasData(
            //    new StockItem
            //    {
            //        StockItemId = Guid.Parse("EE78F549-E790-5E9F-AA15-18C2292A2EE9"),
            //        ConsumableId = Guid.Parse("EE98F549-E790-5E9F-AA15-18C2292A2EE8"),
            //        Name = "Stock Item 1",
            //        Description = "Stock Item 1 Description",
            //        Quantity = 10,
            //        StockId = Guid.Parse("EE68F549-E790-5E9F-AA15-18C2292A2EE9")
            //    },
            //    new StockItem
            //    {
            //        StockItemId = Guid.Parse("EE88F549-E790-5E9F-AA15-18C2292A2EE9"),
            //        ConsumableId = Guid.Parse("EE18F549-E790-5E9F-AA15-18C2292A2EE9"),
            //        Name = "Stock Item 2",
            //        Description = "Stock Item 2 Description",
            //        Quantity = 2,
            //        StockId = Guid.Parse("EE68F549-E790-5E9F-AA15-18C2292A2EE9")
            //    },
            //    new StockItem
            //    {
            //        StockItemId = Guid.Parse("EE91F549-E790-5E9F-AA15-18C2292A2EE9"),
            //        ConsumableId = Guid.Parse("EE38F549-E790-5E9F-AA15-18C2292A2EE9"),
            //        Name = "Stock Item 3",
            //        Description = "Stock Item 3 Description",
            //        Quantity = 15,
            //        StockId = Guid.Parse("EE68F549-E790-5E9F-AA15-18C2292A2EE9")
            //    }

            //    );


            //modelBuilder.Entity<Stock>().HasData(
            //    new Stock
            //    {
            //        StockId = Guid.Parse("EE68F549-E790-5E9F-AA15-18C2292A2EE9"),
            //        Name = "Stock 1",
            //        Description = "Stock 1 Description"
            //    }
            //    );







            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach(var entry in ChangeTracker.Entries<Auditable>())
            {
                switch(entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedBy = _authenticatedUserService.UserId;
                        entry.Entity.Created = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedBy = _authenticatedUserService.UserId;
                        entry.Entity.LastModified = DateTime.Now;
                        break;

                }

            }
            return base.SaveChangesAsync(cancellationToken);
        }

    }
}

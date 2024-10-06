using AutoMapper;
using BookingSystem.Application.Features.Bookings.Commands.CreateBooking;
using BookingSystem.Application.Features.Bookings.Queries.GetBookings;
using BookingSystem.Domain.Entities.Bookings;
using BookingSystem.Domain.Entities.ConferenceRooms;
using BookingSystem.Domain.Entities.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.Profiles
{
    public class BookingProfile:Profile
    {
        public BookingProfile()
        {
            CreateMap<Booking, BookingVm>();
            CreateMap<ConferenceRoom, ConferenceRoomForBookingDto>();
            CreateMap<Event, EventForBookingDto>();
            CreateMap<CreateBookingCommand, Booking>();
        }
    }
}

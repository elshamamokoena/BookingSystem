using AutoMapper;
using BookingSystem.Shared.Models.Booking;
using BookingSystem.Shared.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Shared.Profiles
{
    public class BookingProfile:Profile
    {
        public BookingProfile()
        {
            CreateMap<Services.ConferenceRoom, Models.Booking.ConferenceRoomDto>();
            CreateMap<BookingVm, BookingViewModel>();
        }
    }
}

using AutoMapper;
using BookingSystem.Shared.Models.Bookings;
using BookingSystem.Shared.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Shared.Profiles
{
    class BookingProfile:Profile
    {
        public BookingProfile()
        {
            CreateMap<BookingVm, BookingViewModel>();
        }
    }
}

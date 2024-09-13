using AutoMapper;
using BookingSystem.Shared.Models.Rooms;
using BookingSystem.Shared.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Shared.Profiles
{
    public class ConferenceRoomProfile:Profile
    {
        public ConferenceRoomProfile()
        {
            CreateMap<ConferenceRoomVm, RoomViewModel>().ReverseMap();

        }
    }
}

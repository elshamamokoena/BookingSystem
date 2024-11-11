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
            CreateMap<RoomViewModel, CreateConferenceRoomCommand>();
            CreateMap<RoomViewModel, UpdateConferenceRoomCommand>();
            CreateMap<ConferenceRoomListDto, RoomViewModel>();
            CreateMap<ConferenceRoomDto, RoomViewModel>();

            CreateMap<ConferenceRoomListVm, ConferenceRoomListViewModel>();
        }
    }
}

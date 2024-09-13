using AutoMapper;
using BookingSystem.Application.Features.ConferenceRooms.Commands.CreateConferenceRoom;
using BookingSystem.Application.Features.ConferenceRooms.Commands.UpdateConferenceRoom.UpdateConferenceRoom;
using BookingSystem.Application.Features.ConferenceRooms.Queries.GetConferenceRoom;
using BookingSystem.Application.Features.ConferenceRooms.Queries.GetConferenceRooms;
using BookingSystem.Domain.Entities.ConferenceRooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.Profiles
{
    public class ConferenceRoomProfile:Profile
    {
        public ConferenceRoomProfile()
        {
            CreateMap<CreateConferenceRoomCommand, ConferenceRoom>();
            CreateMap<ConferenceRoom, CreateConferenceRoomCommandResponse>()
                .ForMember(dest => dest.ConferenceRoom, opt => opt.MapFrom(src => src));
            CreateMap<ConferenceRoom, CreateConferenceRoomDto>();
            CreateMap<ConferenceRoom, ForListConferenceRoomdto>();
            CreateMap<ConferenceRoom, ConferenceRoomVm>();
            CreateMap<ConferenceRoom, UpdatedConferenceRoomDto>();
            CreateMap<UpdateConferenceRoomCommand, ConferenceRoom>();


        }
    }
}

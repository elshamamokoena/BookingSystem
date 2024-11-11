using AutoMapper;
using BookingSystem.Application.Features.RoomBookingEvents.Queries.GetRoomBookingEvents;
using BookingSystem.Domain.Entities.RoomBookingEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.Profiles
{
    public class ChangeEventsProfile:Profile
    {
        public ChangeEventsProfile() { 
        
            CreateMap<ConferenceRoomChangeEvent, ConferenceRoomChangeEventListDto>();
        
        }
    }
}

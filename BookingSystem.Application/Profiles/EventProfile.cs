using AutoMapper;
using BookingSystem.Application.Features.Events.Commands.CreateEvent;
using BookingSystem.Application.Features.Events.Commands.UpdateEvent;
using BookingSystem.Application.Features.Events.Queries.GetEvent;
using BookingSystem.Domain.Entities.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.Profiles
{
    public class EventProfile:Profile
    {
        public EventProfile()
        {             
            CreateMap<CreateEventCommand, Event>();
            CreateMap<Event, EventVm>();
            CreateMap<Event, EventDto>();
            CreateMap<UpdateEventCommand, Event>();
        }
    }
}

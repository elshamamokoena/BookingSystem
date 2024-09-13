using AutoMapper;
using BookingSystem.Shared.Models.Events;
using BookingSystem.Shared.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Shared.Profiles
{
    public class EventProfile : Profile
    {
        public EventProfile()
        {
            CreateMap<CreateEventCommand, EventViewModel>()
                .ReverseMap();
            CreateMap<EventViewModel, UpdateEventCommand>();
            CreateMap<EventVm, EventViewModel>();
        }
    }
}

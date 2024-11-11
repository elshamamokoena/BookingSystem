using AutoMapper;
using BookingSystem.Shared.Components.Pages.Dashboard;
using BookingSystem.Shared.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Shared.Profiles
{
    public class ChangeEventsProfile:Profile
    {
        public ChangeEventsProfile()
        {
            CreateMap<ConferenceRoomChangeEventListVm, ConferenceRoomChangeEventListViewModel>();
            CreateMap<ConferenceRoomChangeEventListDto, ConferenceRoomChangeEventViewModel>();
        }
    }
}

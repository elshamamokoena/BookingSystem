using AutoMapper;
using BookingSystem.Shared.Components.Pages.ConferenceRooms;
using BookingSystem.Shared.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Shared.Profiles
{
    public class AmenityProfile:Profile
    {
        public AmenityProfile()
        {
            CreateMap<AmenityVm, AmenityViewModel>();
            CreateMap<AmenityViewModel, CreateAmenityCommand>();
            CreateMap<AmenityViewModel, UpdateAmenityCommand>();
            CreateMap<AmenityCategoryListVm, AmenityCategoryViewModel>();
            CreateMap<AmenityListVm, AmenityViewModel>();
        }
    }
}

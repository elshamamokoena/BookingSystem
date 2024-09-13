using AutoMapper;
using BookingSystem.Application.Features.Amenities.Commands.AddAmenityToRoom;
using BookingSystem.Application.Features.Amenities.Commands.CreateAmenity;
using BookingSystem.Application.Features.Amenities.Commands.CreateAmenityCategory;
using BookingSystem.Domain.Entities.Amenities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.Profiles
{
    public class AmenityProfile:Profile
    {
        public AmenityProfile()
        {
            CreateMap<CreateAmenityCategoryCommand, AmenityCategory>();
            CreateMap<AmenityCategory, CreateAmenityCategoryCommandResponse>()
                .ForMember(dest => dest.AmenityCategory, opt => opt.MapFrom(src => src));
            CreateMap<AmenityCategory, AmenityCategoryDto>();
            CreateMap<Amenity, AmenityDto>();
            CreateMap<Amenity, AmenityWithRoomDto>();

            CreateMap<CreateAmenityCommand, Amenity>();

        }
    }
}

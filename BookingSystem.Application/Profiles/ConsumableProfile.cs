using AutoMapper;
using BookingSystem.Application.Features.Consumables.Commands.CreateConsumable;
using BookingSystem.Application.Features.Consumables.Commands.CreateConsumableCategory;
using BookingSystem.Domain.Entities.Consumables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.Profiles
{
    public class ConsumableProfile:Profile
    {
        public ConsumableProfile()
        {
            CreateMap<CreateConsumableCommand, Consumable>();
            CreateMap<Consumable, CreateConsumableCommandResponse>()
                .ForMember(dest => dest.Consumable, opt => opt.MapFrom(src => src));
            CreateMap<Consumable, ConsumableDto>();

            CreateMap<CreateConsumableCategoryCommand, ConsumableCategory>();
            CreateMap<ConsumableCategory, CreateConsumableCategoryCommandResponse>()
                .ForMember(dest => dest.ConsumableCategory, opt => opt.MapFrom(src => src));
            CreateMap<ConsumableCategory, ConsumableCategoryDto>();

        }

    }
}

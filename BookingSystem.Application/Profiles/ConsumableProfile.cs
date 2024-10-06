using AutoMapper;
using BookingSystem.Application.Features.ConsumableCategories.Queries.GetConsumableCategories;
using BookingSystem.Application.Features.Consumables.Commands.CreateConsumable;
using BookingSystem.Application.Features.Consumables.Commands.CreateConsumableCategory;
using BookingSystem.Application.Features.Consumables.Queries.GetConsumables;
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
            CreateMap<ConsumableCategory, ConsumableCategoryListVm>();
            CreateMap<Consumable, ConsumableListVm>();
            CreateMap<ConsumableCategory, ConsumableCategoryForListDto>();
        }

    }
}

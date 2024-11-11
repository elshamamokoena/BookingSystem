using AutoMapper;
using BookingSystem.Application.Features.ConsumableCategories.Commands;
using BookingSystem.Application.Features.ConsumableCategories.Queries.GetConsumableCategories;
using BookingSystem.Application.Features.Consumables.Commands.CreateConsumable;
using BookingSystem.Application.Features.Consumables.Queries.GetConsumable;
using BookingSystem.Application.Features.Consumables.Queries.GetConsumables;
using BookingSystem.Application.Features.Inventory.Queries.GetStockItem;
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
            CreateMap<Consumable, ConsumableListDto>();
            CreateMap<CreateConsumableCategoryCommand, ConsumableCategory>();
            CreateMap<ConsumableCategory, ConsumableCategoryListVm>();
            CreateMap<Consumable, ConsumableListVm>();
            CreateMap<Consumable, ConsumableVm>();
            CreateMap<ConsumableCategory, ConsumableListCategoryDto>();
            CreateMap<ConsumableCategory, ConsumableCategoryDto>();
            CreateMap<Consumable, ConsumableDto>();

        }

    }
}

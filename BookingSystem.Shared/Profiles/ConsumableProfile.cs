using AutoMapper;
using BookingSystem.Shared.Components.Pages.Consumables;
using BookingSystem.Shared.Components.Pages.Events.EditEvents;
using BookingSystem.Shared.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Shared.Profiles
{
    public class ConsumableProfile: Profile
    {
        public ConsumableProfile()
        {
            CreateMap<ConsumableCategoryListVm, ConsumableCategoryViewModel>();
            CreateMap<ConsumableListVm, ConsumableViewModel>();
            //CreateMap<ConsumableCategoryForListDto, ConsumableCategoryViewModel>();
        }
    }
}

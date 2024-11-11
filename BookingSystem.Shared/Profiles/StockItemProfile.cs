using AutoMapper;
using BookingSystem.Shared.Components.Pages.Consumables.EditConsumablePage.EditConsumablePageComponents;
using BookingSystem.Shared.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Shared.Profiles
{
    public class StockItemProfile:Profile
    {
        public StockItemProfile()
        {
            CreateMap<StockItemVm, StockItemViewModel>();
        }
    }
}

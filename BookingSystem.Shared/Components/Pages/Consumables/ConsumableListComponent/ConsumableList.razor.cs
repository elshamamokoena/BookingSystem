using BookingSystem.ClassLibrary;
using BookingSystem.Shared.Components.Base;
using BookingSystem.Shared.Models.Bookings;
using BookingSystem.Shared.Models.Consumables;
using BookingSystem.Shared.Models.Rooms;
using BookingSystem.Shared.Services.Base;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Shared.Components.Pages.Consumables.ConsumableListComponent
{
    public partial class ConsumableList : BaseComponent
    {


        public PagedList<ConsumableViewModel> PagedConsumables { get; set; }
            = new PagedList<ConsumableViewModel>();

        public ObservableCollection<ConsumableViewModel> ConsumablesList
            = new ObservableCollection<ConsumableViewModel>();

        protected override async Task OnInitializedAsync()
        {
            await FetchConsumables();
            await base.OnInitializedAsync();
        }

        protected async Task FetchConsumables()
        {
            PagedConsumables = await ConsumableDataService!.GetConsumablesAsync(null, true, 1, 50);

            ConsumablesList = new ObservableCollection<ConsumableViewModel>(PagedConsumables);
        }
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            //await JsRuntime!.LoadModule("choicesInit");+
            await JsRuntime!.LoadModule("swiperInit");
            await base.OnAfterRenderAsync(firstRender);
        }

    }
}

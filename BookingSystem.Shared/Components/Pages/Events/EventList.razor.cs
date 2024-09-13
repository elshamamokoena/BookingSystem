using BookingSystem.Shared.Components.Base;
using BookingSystem.Shared.Contracts;
using BookingSystem.Shared.Models.Events;
using BookingSystem.Shared.Models.Rooms;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Shared.Components.Pages.Events
{
    public partial class EventList : BaseComponent
    {
        public IEnumerable<EventViewModel> Bookings { get; set; } = new List<EventViewModel>();
        protected override async Task OnInitializedAsync()
        {
            Bookings = await EventDataService!.GetEventsAsync(null, null, 1, 20);
            await base.OnInitializedAsync();
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (!firstRender)
            {
                await JsRuntime!.InitDataTables(firstRender);
                await JsRuntime!.InitBulkSelect(firstRender);
            }
            await base.OnAfterRenderAsync(firstRender);
        }
    }
}

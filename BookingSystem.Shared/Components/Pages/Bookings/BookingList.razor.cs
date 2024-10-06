using BookingSystem.Shared.Components.Base;
using BookingSystem.Shared.Models.Bookings;
using BookingSystem.Shared.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Shared.Components.Pages.Bookings
{
    public partial class BookingList:BaseComponent
    {

        [Parameter]
        public Guid EventId { get; set; } = Guid.Parse("EE98F549-E190-5E9F-AA15-18C2292A2EE1");

        public IEnumerable<BookingViewModel>? Bookings { get; set; } 

        protected override async Task OnInitializedAsync()
        {
            Bookings = await BookingDataService!.GetBookingsAsync(EventId, 1, 10);
            await base.OnInitializedAsync();
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (Bookings != null)
                await JsRuntime!.InitiAdvanceAjaxTable(firstRender, Bookings, this);

            await base.OnAfterRenderAsync(firstRender);
        }
    }
}

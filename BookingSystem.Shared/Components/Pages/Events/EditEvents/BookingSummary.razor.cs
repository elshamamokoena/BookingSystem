using BookingSystem.Shared.Components.Base;
using BookingSystem.Shared.Models.Bookings;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Shared.Components.Pages.Events.EditEvents
{
    public partial class BookingSummary:BaseComponent
    {
        [Parameter]
        public string EventId { get; set; }
        public Guid SelectedEventId = Guid.Empty;

        public ICollection<BookingViewModel> Bookings 
            = new List<BookingViewModel>();

        protected override async Task OnInitializedAsync()
        {
            if(Guid.TryParse(EventId, out SelectedEventId))
            {
                Bookings = await FetchBookings();
            }
            await base.OnInitializedAsync();
        }

        private async Task<List<BookingViewModel>> FetchBookings()
        {
            return new List<BookingViewModel>(await BookingDataService!.GetBookingsAsync(SelectedEventId, 1, 20));
        }

        //protected override async Task OnAfterRenderAsync(bool firstRender)
        //{
        //    if (!firstRender)
        //        Bookings = await FetchBookings();

        //    await JsRuntime!.InitiAdvanceAjaxTable(firstRender, Bookings, this);
        //    await base.OnAfterRenderAsync(firstRender);
        //}

    }
}

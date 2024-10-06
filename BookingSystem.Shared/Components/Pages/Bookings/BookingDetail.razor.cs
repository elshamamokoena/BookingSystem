using BookingSystem.Shared.Components.Base;
using BookingSystem.Shared.Models.Bookings;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Shared.Components.Pages.Bookings
{
    public partial class BookingDetail: BaseComponent
    {
        [Parameter]
        public string BookingId { get; set; }
        public Guid SelectedBookingId = Guid.Empty;
        public BookingViewModel Booking { get; set; }
        protected override async Task OnParametersSetAsync()
        {
            if (Guid.TryParse(BookingId, out SelectedBookingId))
            {
                Booking = await BookingDataService!.GetBookingAsync(SelectedBookingId,true,true);
            }
            await base.OnParametersSetAsync();
        }
        public void GoToStock()
        {
            NavigateTo($"/consumable-list?bookingId={SelectedBookingId}");
        }
    }
}
